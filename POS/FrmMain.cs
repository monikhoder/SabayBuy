using KimTools.WinForms;
using POS.ApiServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmMain : KtWindow
    {
        private readonly POSAccountService accountService = new POSAccountService();
        private readonly Timer dateTimeTimer = new Timer();
        private static readonly HttpClient imageClient = new HttpClient();
        public FrmMain()
        {
            InitializeComponent();
            UpdateCurrentUserLabel();
            UpdateDateTimeLabel();
            Shown += FrmMain_Shown;

            dateTimeTimer.Interval = 1000;
            dateTimeTimer.Tick += DateTimeTimer_Tick;
            dateTimeTimer.Start();
        }

        private async void FrmMain_Shown(object sender, EventArgs e)
        {
            await LoadProfilePictureAsync();
        }

        private void DateTimeTimer_Tick(object sender, EventArgs e)
        {
            UpdateDateTimeLabel();
        }

        private void UpdateDateTimeLabel()
        {
            datetime_lbl.Text = DateTime.Now.ToString("dd - MMM - yyyy hh:mm:ss tt");
        }

        private void UpdateCurrentUserLabel()
        {
            var currentUser = POSAccountService.CurrentUser;
            if (currentUser == null)
            {
                username_lbl.Text = "Unknown";
                return;
            }

            var fullName = $"{currentUser.FirstName} {currentUser.LastName}".Trim();
            username_lbl.Text = string.IsNullOrWhiteSpace(fullName) ? currentUser.Email : fullName;
        }

        private async Task LoadProfilePictureAsync()
        {
            var currentUser = POSAccountService.CurrentUser;
            if (currentUser == null || string.IsNullOrWhiteSpace(currentUser.ProfileUrl))
            {
                profile_picture.Image = Properties.Resources.people;
                return;
            }

            try
            {
                var imageBytes = await imageClient.GetByteArrayAsync(currentUser.ProfileUrl);

                using (var memoryStream = new MemoryStream(imageBytes))
                using (var image = Image.FromStream(memoryStream))
                {
                    profile_picture.Image = new Bitmap(image);
                }
            }
            catch
            {
                profile_picture.Image = Properties.Resources.people;
            }
        }

        private async void exit_btn_Click(object sender, EventArgs e)
        {
            exit_btn.Enabled = false;
            dateTimeTimer.Stop();

            var result = await accountService.LogoutAsync();

            if (!result.Success)
            {
                exit_btn.Enabled = true;
                dateTimeTimer.Start();
                MessageBox.Show(result.ErrorMessage, "POS Logout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Application.Exit();
        }
    }
}
