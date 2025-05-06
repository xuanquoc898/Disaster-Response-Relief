using D2R.Models;
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;

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
            CategoryGroupsPanel.Items.Add(group);
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedDonor == null)
            {
                MessageBox.Show("Vui lòng chọn mạnh thường quân.");
                return;
            }

            var groups = new List<DonationCategoryGroupControl>();
            foreach (var item in CategoryGroupsPanel.Items)
                if (item is DonationCategoryGroupControl g) groups.Add(g);

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