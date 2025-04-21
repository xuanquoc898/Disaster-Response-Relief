
using D2R.Models;
using D2R.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.UserControls
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

            panel.Children.Add(itemBox);
            panel.Children.Add(qtyBox);
            ItemEntryPanel.Items.Add(panel);
        }

        public List<CampaignItemRequestModel> GetRequestedItems()
        {
            var result = new List<CampaignItemRequestModel>();

            foreach (StackPanel panel in ItemEntryPanel.Items)
            {
                var itemBox = panel.Children[0] as ComboBox;
                var qtyBox = panel.Children[1] as TextBox;

                if (itemBox?.SelectedItem is WarehouseItem item && int.TryParse(qtyBox?.Text, out int quantity))
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
