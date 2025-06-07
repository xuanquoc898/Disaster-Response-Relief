using D2R.Models;
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace D2R.Views.Users
{
    public partial class DonationView : UserControl
    {
        private readonly DonationViewModel _viewModel;

        public DonationView(int warehouseId)
        {
            InitializeComponent();
            _viewModel = new DonationViewModel(warehouseId);
            AddCategoryGroup();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryGroup();
        }

        private void AddCategoryGroup()
        {
            var group = new DonationCategoryGroupControl(_viewModel);

            var wrapper = new StackPanel();

            // Nút xoá danh mục
            var deleteButton = new Button
            {
                Content = "❌",
                Margin = new Thickness(0, 0, 0, 5),
                Foreground = Brushes.Red,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Right
            };

            //k xóa danh mục đầu tiên
            deleteButton.Click += (s, e) =>
            {
                if (CategoryGroupsPanel.Items.Count <= 1)
                {
                    MessageBox.Show("Không thể xoá danh mục cuối cùng.");
                    return;
                }

                // Xoá chính `wrapper` này khỏi danh sách
                CategoryGroupsPanel.Items.Remove(wrapper);
            };

            wrapper.Children.Add(deleteButton);
            wrapper.Children.Add(group);

            CategoryGroupsPanel.Items.Add(wrapper);
        }



        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedDonor == null)
            {
                MessageBox.Show("Vui lòng chọn mạnh thường quân.");
                return;
            }

            var groups = CategoryGroupsPanel.Items
                          .OfType<StackPanel>()
                          .Select(sp => sp.Children
                              .OfType<DonationCategoryGroupControl>()
                              .FirstOrDefault())
                          .Where(g => g != null)
                          .ToList();


            // check tất cả các dòng trong tất cả nhóm phải hợp lệ
            if (groups.Count == 0 || !groups.All(g => g.IsValid()))
            {
                MessageBox.Show("Tất cả các mặt hàng nhập phải hợp lệ (đã chọn và số lượng > 0).");
                return;
            }

            var success = _viewModel.ConfirmDonation(groups);
            if (success)
            {
                MessageBox.Show("Ủng hộ thành công!");
                CategoryGroupsPanel.Items.Clear();
                AddCategoryGroup();
            }
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = SearchBox.Text.Trim();
            DonorListBox.ItemsSource = _viewModel.SearchDonors(keyword);
        }

        private void DonorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DonorListBox.SelectedItem is Donor donor)
            {
                _viewModel.SetSelectedDonor(donor);
                SearchBox.Text = donor.FullName;
                DonorListBox.ItemsSource = null;
            }
        }

    }
}