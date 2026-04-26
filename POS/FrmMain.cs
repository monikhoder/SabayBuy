using KimTools.WinForms;
using POS.ApiServices;
using POS.Components;
using POS.Dtos;
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
        private readonly CategoriesService categoriesService = new CategoriesService();
        private readonly Timer dateTimeTimer = new Timer();
        private static readonly HttpClient imageClient = new HttpClient();
        private const int CategoryScrollStep = 180;
        private Panel categoriesViewportPanel;

        public FrmMain()
        {
            InitializeComponent();
            LoadTestProductCards();
            SetupCategoryViewport();
            next_category_btn.Click += Next_category_btn_Click;
            Prev_category_btn.Click += Prev_category_btn_Click;
            categories_panel.Resize += Categories_panel_Resize;
            categoriesViewportPanel.Resize += CategoriesViewportPanel_Resize;

            UpdateCurrentUserLabel();
            UpdateDateTimeLabel();
            Shown += FrmMain_Shown;

            dateTimeTimer.Interval = 1000;
            dateTimeTimer.Tick += DateTimeTimer_Tick;
            dateTimeTimer.Start();
        }

        private void SetupCategoryViewport()
        {
            categoriesViewportPanel = new Panel
            {
                Dock = DockStyle.None,
                BackColor = categories_panel.BackColor
            };

            categories_panel.Controls.Remove(categories_flowLayout_panel);
            categories_panel.Controls.Add(categoriesViewportPanel);
            categoriesViewportPanel.Controls.Add(categories_flowLayout_panel);

            LayoutCategoryViewport();
            prev_category_panel.BringToFront();
            next_category_panel.BringToFront();
        }

        private async void FrmMain_Shown(object sender, EventArgs e)
        {
            await LoadProfilePictureAsync();
            await LoadCategoryButtonsAsync();
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

        private void LoadTestProductCards()
        {
            var templateCard = productCard1;

            product_list_flowLayoutPanel.SuspendLayout();
            product_list_flowLayoutPanel.Controls.Clear();
            product_list_flowLayoutPanel.AutoScroll = true;
            product_list_flowLayoutPanel.WrapContents = true;
            product_list_flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;

            for (int i = 1; i <= 30; i++)
            {
                var card = new ProductCard
                {
                    
                    Name = $"productCard{i}",
                    Size = templateCard.Size,
                    Margin = templateCard.Margin,
                    Padding = templateCard.Padding,
                    BackColor = templateCard.BackColor,
                    Tag = i
                };
                

                product_list_flowLayoutPanel.Controls.Add(card);
            }

            product_list_flowLayoutPanel.ResumeLayout();
        }

        private async Task LoadCategoryButtonsAsync()
        {
            var result = await categoriesService.GetCategoriesWithProductsAsync();

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Load Categories", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var templateButton = Category_btn_template;
            templateButton.Visible = true;
            var categories = result.Data ?? new List<CategoryDto>();

            categories_flowLayout_panel.SuspendLayout();
            categories_flowLayout_panel.Controls.Clear();
            categories_flowLayout_panel.Dock = DockStyle.None;
            categories_flowLayout_panel.AutoScroll = false;
            categories_flowLayout_panel.WrapContents = false;
            categories_flowLayout_panel.FlowDirection = FlowDirection.LeftToRight;
            categories_flowLayout_panel.Left = 0;
            categories_flowLayout_panel.Top = 0;
            categories_flowLayout_panel.Height = categoriesViewportPanel.Height;

            foreach (var category in categories)
            {
                var categoryButton = CreateCategoryButton(templateButton, category);
                categories_flowLayout_panel.Controls.Add(categoryButton);
            }

            if (categories_flowLayout_panel.Controls.Count == 0)
            {
                var emptyButton = CreateCategoryButton(templateButton, new CategoryDto
                {
                    CategoryName = "No Categories",
                    ProductCount = 0
                });
                emptyButton.Enabled = false;
                categories_flowLayout_panel.Controls.Add(emptyButton);
            }

            ResizeCategoryFlowPanel();
            categories_flowLayout_panel.ResumeLayout();
        }

        private KtButton CreateCategoryButton(KtButton templateButton, CategoryDto category)
        {
            var button = new KtButton
            {
                Anchor = templateButton.Anchor,
                BackColor = templateButton.BackColor,
                Background = templateButton.Background,
                BorderStyle = templateButton.BorderStyle,
                BorderWidth = templateButton.BorderWidth,
                Font = templateButton.Font,
                ForeColor = templateButton.ForeColor,
                Foreground = templateButton.Foreground,
                Icon = templateButton.Icon,
                IconColor = templateButton.IconColor,
                IconSize = templateButton.IconSize,
                IconStroke = templateButton.IconStroke,
                Margin = templateButton.Margin,
                Padding = templateButton.Padding,
                Size = templateButton.Size,
                Text = category.CategoryName,
                UseVisualStyleBackColor = templateButton.UseVisualStyleBackColor,
                Cursor = Cursors.Hand,
                Tag = category
            };

            button.Click += CategoryButton_Click;

            return button;
        }

        private void Next_category_btn_Click(object sender, EventArgs e)
        {
            ScrollCategories(CategoryScrollStep);
        }

        private void Prev_category_btn_Click(object sender, EventArgs e)
        {
            ScrollCategories(-CategoryScrollStep);
        }

        private void ScrollCategories(int amount)
        {
            int visibleWidth = categoriesViewportPanel.Width;
            int maxLeft = 0;
            int minLeft = maxLeft + visibleWidth - categories_flowLayout_panel.Width;
            int nextLeft = categories_flowLayout_panel.Left - amount;

            if (minLeft > maxLeft)
            {
                minLeft = maxLeft;
            }

            if (nextLeft > maxLeft)
            {
                nextLeft = maxLeft;
            }

            if (nextLeft < minLeft)
            {
                nextLeft = minLeft;
            }

            categories_flowLayout_panel.Left = nextLeft;
        }

        private void CategoriesViewportPanel_Resize(object sender, EventArgs e)
        {
            ResizeCategoryFlowPanel();
        }

        private void Categories_panel_Resize(object sender, EventArgs e)
        {
            LayoutCategoryViewport();
            ResizeCategoryFlowPanel();
        }

        private void LayoutCategoryViewport()
        {
            int left = prev_category_panel.Width;
            int width = categories_panel.Width - prev_category_panel.Width - next_category_panel.Width;

            if (width < 0)
            {
                width = 0;
            }

            categoriesViewportPanel.Bounds = new Rectangle(left, 0, width, categories_panel.Height);
        }

        private void ResizeCategoryFlowPanel()
        {
            int contentWidth = categories_flowLayout_panel.Padding.Left + categories_flowLayout_panel.Padding.Right;

            foreach (Control control in categories_flowLayout_panel.Controls)
            {
                contentWidth += control.Width + control.Margin.Left + control.Margin.Right;
            }

            categories_flowLayout_panel.Width = Math.Max(contentWidth, categoriesViewportPanel.Width);
            categories_flowLayout_panel.Height = categoriesViewportPanel.Height;
            ScrollCategories(0);
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            var button = sender as KtButton;
            if (button == null)
            {
                return;
            }

            var category = button.Tag as CategoryDto;
            if (category == null)
            {
                return;
            }

            MessageBox.Show($"{category.CategoryName} ({category.ProductCount} products)", "Selected Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
