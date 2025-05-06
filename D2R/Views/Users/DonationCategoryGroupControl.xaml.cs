using D2R.Models;
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.Users
{
    public partial class DonationCategoryGroupControl : UserControl
    {
        private readonly DonationViewModel _viewModel;
        private List<WarehouseItem> _items = new();

        public DonationCategoryGroupControl(DonationViewModel viewModel)
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
                AddItemEntry(); // auto add 1 dòng đầu tiên khi chọn danh mục
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
        
        private void DeleteItemEntry_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext != null)
            {
                ItemEntryPanel.Items.Remove(btn.DataContext);
            }
        }

        public List<DonationItemEntry> GetDonationItems()
        {
            var result = new List<DonationItemEntry>();

            foreach (StackPanel panel in ItemEntryPanel.Items)
            {
                var itemBox = panel.Children[0] as ComboBox;
                var qtyBox = panel.Children[1] as TextBox;

                if (itemBox?.SelectedItem is WarehouseItem item && int.TryParse(qtyBox?.Text, out int quantity))
                {
                    result.Add(new DonationItemEntry
                    {
                        Item = item,
                        Quantity = quantity
                    });
                }
            }

            return result;
        }
    }
}
