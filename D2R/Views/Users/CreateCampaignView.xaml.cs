﻿
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.Users
{
    public partial class CreateCampaignView : UserControl
    {
        private readonly CreateCampaignViewModel _viewModel;

        public CreateCampaignView()
        {
            InitializeComponent();
            _viewModel = new CreateCampaignViewModel();
            LoadDisasterTypes();
            AddCategoryGroup();
        }

        private void LoadDisasterTypes()
        {
            DisasterTypeComboBox.ItemsSource = _viewModel.GetDisasterTypes();
        }

        private void DisasterTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DisasterTypeComboBox.SelectedValue is int typeId)
            {
                DisasterLevelComboBox.ItemsSource = _viewModel.GetDisasterLevelsByType(typeId);
            }
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryGroup();
        }

        private void AddCategoryGroup()
        {
            var group = new CampaignCategoryGroupControl(_viewModel);

            CategoryGroupsPanel.Items.Add(group);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DisasterLevelId = DisasterLevelComboBox.SelectedValue as int?;
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chiến dịch.");
                return;
            }
            _viewModel.Title = TitleTextBox.Text;
            _viewModel.ClearGroups(); // xóa danh sách campaign category cũ
            foreach (var item in CategoryGroupsPanel.Items)
            {
                if (item is CampaignCategoryGroupControl g)
                    _viewModel.AddGroup(g);
            }

            if (_viewModel.SubmitCampaign())
            {
                MessageBox.Show("Chiến dịch đã được gửi thành công!");
                CategoryGroupsPanel.Items.Clear();
                AddCategoryGroup();
                TitleTextBox.Text = "";
                DisasterTypeComboBox.ItemsSource = null;
                DisasterLevelComboBox.ItemsSource = null;
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hoặc Kiểm tra dữ liệu đã nhập!");
            }
        }
    }
}
