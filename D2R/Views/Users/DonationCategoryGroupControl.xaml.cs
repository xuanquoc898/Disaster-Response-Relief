using D2R.Models;
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            var unitText = new TextBlock
            {
                Margin = new Thickness(5, 0, 5, 0),
                VerticalAlignment = VerticalAlignment.Center,
                Text = "",
                Width = 50
            };

            // người dùng chọn mặt hàng => truy xuất và gán Unit
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

            panel.Children.Add(itemBox);    // ComboBox chọn mặt hàng
            panel.Children.Add(qtyBox);     // TextBox số lượng
            panel.Children.Add(unitText);   // TextBlock hiển thị đơn vị
            panel.Children.Add(deleteButton); // Nút xoá

            ItemEntryPanel.Items.Add(panel);
        }

        private void DeleteItemEntry_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is StackPanel panel)
            {
                ItemEntryPanel.Items.Remove(panel);
            }
        }

        public List<DonationItemEntry> GetDonationItems()
        {
            var result = new List<DonationItemEntry>();

            foreach (var element in ItemEntryPanel.Items)
            {
                if (element is StackPanel panel &&
                    panel.Children[0] is ComboBox itemBox &&
                    panel.Children[1] is TextBox qtyBox &&
                    itemBox.SelectedItem is WarehouseItem item &&
                    int.TryParse(qtyBox.Text, out int quantity) &&
                    quantity > 0)
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


        public bool IsValid()
        {
            foreach (var element in ItemEntryPanel.Items)
            {
                // Bỏ qua phần tử không hợp lệ thay vì return false
                if (element is not StackPanel panel) continue;

                if (panel.Children.Count < 2) continue; // không đủ control

                var itemBox = panel.Children[0] as ComboBox;
                var qtyBox = panel.Children[1] as TextBox;

                if (itemBox?.SelectedItem is not WarehouseItem) return false;
                if (!int.TryParse(qtyBox?.Text, out int quantity) || quantity <= 0) return false;
            }

            return true;
        }


    }
}
