using D2R.Models;
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace D2R.Views.Users
{
    public partial class CampaignCategoryGroupControl : UserControl
    {
        private readonly CreateCampaignViewModel _viewModel;
        private List<WarehouseItem> _items = new();

        public CampaignCategoryGroupControl(CreateCampaignViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            CategoryComboBox.ItemsSource = _viewModel.GetCategories();
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemEntryPanel.Items.Clear();

            if (CategoryComboBox.SelectedItem is ItemCategory category)
            {
                _items = _viewModel.GetItemsByCategory(category.CategoryId);
                AddItemEntry();
            }
        }

        private void AddItemEntry_Click(object sender, RoutedEventArgs e)
        {
            AddItemEntry();
        }

        private void AddItemEntry()
        {
            var panel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 0) };

            var itemBox = new ComboBox
            {
                Width = 200,
                Margin = new Thickness(0, 0, 5, 0),
                DisplayMemberPath = "Name",
                ItemsSource = _items
            };

            var qtyBox = new TextBox
            {
                Width = 80,
                Margin = new Thickness(0, 0, 5, 0)
            };

            var unitText = new TextBlock
            {
                Margin = new Thickness(5, 0, 5, 0),
                VerticalAlignment = VerticalAlignment.Center,
                Text = "",
                Width = 50
            };

            itemBox.SelectionChanged += (s, e) =>
            {
                if (itemBox.SelectedItem is WarehouseItem selectedItem)
                {
                    unitText.Text = selectedItem.Unit ?? "";
                }
                else
                {
                    unitText.Text = "";
                }
            };

            var deleteButton = new Button
            {
                Content = "❌",
                Margin = new Thickness(5, 0, 0, 0),
                Background = Brushes.Transparent,
                Foreground = Brushes.Red,
                BorderThickness = new Thickness(0),
                Tag = panel
            };

            deleteButton.Click += DeleteItemEntry_Click;

            panel.Children.Add(itemBox);
            panel.Children.Add(qtyBox);
            panel.Children.Add(unitText);
            panel.Children.Add(deleteButton);

            ItemEntryPanel.Items.Add(panel);
        }

        private void DeleteItemEntry_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is StackPanel panel)
            {
                ItemEntryPanel.Items.Remove(panel);
            }
        }

        public List<CampaignItemRequestModel> GetRequestedItems()
        {
            var result = new List<CampaignItemRequestModel>();

            foreach (var element in ItemEntryPanel.Items)
            {
                if (element is StackPanel panel &&
                    panel.Children[0] is ComboBox itemBox &&
                    panel.Children[1] is TextBox qtyBox &&
                    itemBox.SelectedItem is WarehouseItem item &&
                    int.TryParse(qtyBox.Text, out int quantity))
                {
                    result.Add(new CampaignItemRequestModel
                    {
                        CategoryId = item.CategoryId,
                        ItemId = item.ItemId,
                        QuantityRequested = quantity
                    });
                }
            }

            return result;
        }
    }
}
