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
        private readonly POSProductService productService = new POSProductService();
        private readonly Timer dateTimeTimer = new Timer();
        private readonly Timer searchTimer = new Timer();
        private static readonly HttpClient imageClient = new HttpClient();
        private string selectedCategoryName;

        public FrmMain()
        {
            InitializeComponent();
            ConfigureProductListLayout();

            UpdateCurrentUserLabel();
            UpdateDateTimeLabel();
            Shown += FrmMain_Shown;

            dateTimeTimer.Interval = 1000;
            dateTimeTimer.Tick += DateTimeTimer_Tick;
            dateTimeTimer.Start();

            searchTimer.Interval = 350;
            searchTimer.Tick += SearchTimer_Tick;
            txt_search.TextChanged += txt_search_TextChanged;
        }

        private void ConfigureProductListLayout()
        {
            product_list_flowLayoutPanel.Dock = DockStyle.Fill;
            product_list_flowLayoutPanel.Padding = new Padding(10);
        }

        private async void FrmMain_Shown(object sender, EventArgs e)
        {
           // await LoadProfilePictureAsync();
            await LoadCategoryCardsAsync();
            await LoadProductCardsAsync();
        }

        private void DateTimeTimer_Tick(object sender, EventArgs e)
        {
            UpdateDateTimeLabel();
        }

        private async void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            await LoadProductCardsAsync(selectedCategoryName);
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
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

        //private async void exit_btn_Click(object sender, EventArgs e)
        //{
        //    exit_btn.Enabled = false;
        //    dateTimeTimer.Stop();

        //    var result = await accountService.LogoutAsync();

        //    if (!result.Success)
        //    {
        //        exit_btn.Enabled = true;
        //        dateTimeTimer.Start();
        //        MessageBox.Show(result.ErrorMessage, "POS Logout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    Application.Exit();
        //}

        private async Task LoadProductCardsAsync(string categoryName = null)
        {
            var queryParams = new POSProductQueryParams
            {
                PageIndex = 1,
                PageSize = 100,
                InStockOnly = true,
                Search = txt_search.Text.Trim()
            };

            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                queryParams.Categories.Add(categoryName);
            }

            var result = await productService.GetProductsAsync(queryParams);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Load Products", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var templateCard = productCard1;
          //  var productCardSize = GetProductCardDisplaySize(templateCard);
            var products = result.Data?.Data ?? new List<POSProductVariantDto>();

            product_list_flowLayoutPanel.SuspendLayout();
            product_list_flowLayoutPanel.Controls.Clear();
            product_list_flowLayoutPanel.AutoScroll = true;
            product_list_flowLayoutPanel.WrapContents = true;
            product_list_flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            //product_list_flowLayoutPanel.Padding = new Padding(10);

            foreach (var product in products)
            {
                var card = new ProductCard
                {
                    Name = $"productCard_{product.VariantId}",
                    Margin = templateCard.Margin,
                    Padding = templateCard.Padding,
                    BackColor = templateCard.BackColor,
                    Cursor = Cursors.Hand
                };

                card.SetProduct(product);

                product_list_flowLayoutPanel.Controls.Add(card);
            }

            product_list_flowLayoutPanel.ResumeLayout();
        }

        private async Task LoadCategoryCardsAsync()
        {
            var result = await categoriesService.GetCategoriesWithProductsAsync();

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Load Categories", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var templateCard = categoryCard1;
            var categories = result.Data ?? new List<CategoryDto>();

            PrepareCategoryHorizontalScroll(templateCard.Size, templateCard.Margin);
            categories_flowLayoutPanel.SuspendLayout();
            categories_flowLayoutPanel.Controls.Clear();
            categories_flowLayoutPanel.AutoScroll = true;
            categories_flowLayoutPanel.WrapContents = false;
            categories_flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            categories_flowLayoutPanel.VerticalScroll.Enabled = false;
            categories_flowLayoutPanel.HorizontalScroll.Enabled = true;

            var allCategoryCard = CreateCategoryCard(templateCard, new CategoryDto
            {
                CategoryName = "All Categories",
                ProductCount = categories.Sum(category => category.ProductCount)
            });
            allCategoryCard.SetSelected(true);
            AttachCategoryCardClickHandlers(allCategoryCard);
            categories_flowLayoutPanel.Controls.Add(allCategoryCard);

            foreach (var category in categories)
            {
                var card = CreateCategoryCard(templateCard, category);
                AttachCategoryCardClickHandlers(card);
                categories_flowLayoutPanel.Controls.Add(card);
            }

            categories_flowLayoutPanel.AutoScrollMinSize = new Size(GetCategoryCardsWidth(), 0);
            categories_flowLayoutPanel.ResumeLayout();
        }

        private void AttachCategoryCardClickHandlers(CategoryCard card)
        {
            card.Click += CategoryCard_Click;
            AttachCategoryCardClickHandlers(card, CategoryCard_Click);
        }

        private CategoryCard CreateCategoryCard(CategoryCard templateCard, CategoryDto category)
        {
            var card = new CategoryCard
            {
                Name = category.Id == Guid.Empty ? "categoryCard_all" : $"categoryCard_{category.Id}",
                Size = templateCard.Size,
                Margin = templateCard.Margin,
                Padding = templateCard.Padding,
                BackColor = templateCard.BackColor,
                Cursor = Cursors.Hand
            };

            card.SetCategory(category);

            return card;
        }

        private void AttachCategoryCardClickHandlers(Control parent, EventHandler clickHandler)
        {
            foreach (Control child in parent.Controls)
            {
                child.Click += clickHandler;
                AttachCategoryCardClickHandlers(child, clickHandler);
            }
        }

        private async void CategoryCard_Click(object sender, EventArgs e)
        {
            var categoryCard = GetParentCategoryCard(sender as Control);
            var category = categoryCard?.Tag as CategoryDto;

            if (category == null)
            {
                return;
            }

            SetSelectedCategoryCard(categoryCard);
            selectedCategoryName = category.Id == Guid.Empty ? null : category.CategoryName;

            await LoadProductCardsAsync(selectedCategoryName);
        }

        private void SetSelectedCategoryCard(CategoryCard selectedCard)
        {
            foreach (Control control in categories_flowLayoutPanel.Controls)
            {
                if (control is CategoryCard card)
                {
                    card.SetSelected(card == selectedCard);
                }
            }
        }

        private CategoryCard GetParentCategoryCard(Control control)
        {
            while (control != null && !(control is CategoryCard))
            {
                control = control.Parent;
            }

            return control as CategoryCard;
        }

        private void PrepareCategoryHorizontalScroll(Size cardSize, Padding cardMargin)
        {
            int cardOuterHeight = cardSize.Height + cardMargin.Top + cardMargin.Bottom;
            int neededHeight = categories_panel.Padding.Top
                + category_title_lbl.Height
                + cardOuterHeight
                + SystemInformation.HorizontalScrollBarHeight
                + categories_panel.Padding.Bottom
                + 6;

            if (categories_panel.Height < neededHeight)
            {
                categories_panel.Height = neededHeight;
            }
        }

        private int GetCategoryCardsWidth()
        {
            int width = categories_flowLayoutPanel.Padding.Left + categories_flowLayoutPanel.Padding.Right;

            foreach (Control control in categories_flowLayoutPanel.Controls)
            {
                width += control.Width + control.Margin.Left + control.Margin.Right;
            }

            return width;
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
