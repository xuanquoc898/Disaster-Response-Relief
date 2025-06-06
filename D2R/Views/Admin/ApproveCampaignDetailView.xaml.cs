using D2R.Helpers;
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.Admin
{
    public partial class ApproveCampaignDetailView : UserControl
    {
        private ApproveCampaignDetailViewModel _viewModel;

        public ApproveCampaignDetailView(int campaignId)
        {
            InitializeComponent();

            if (LoginSession.CurrentUser?.RoleId != 1)
            {
                MessageBox.Show("Chức năng này chỉ dành cho Admin!");
                return;
            }

            _viewModel = new ApproveCampaignDetailViewModel();
            _viewModel.LoadGroupedByCategory(campaignId);

            CampaignNoteText.Text = _viewModel.Campaign.Title;
            DisasterTypeText.Text = _viewModel.Campaign.DisasterLevel?.DisasterType?.Name ?? "Không rõ";
            DisasterLevelText.Text = _viewModel.Campaign.DisasterLevel?.Level ?? "Không rõ";

            foreach (var group in _viewModel.GroupedItems)
            {
                var categoryHeader = new TextBlock
                {
                    Text = $"Danh mục: {group.CategoryName}",
                    FontWeight = FontWeights.Bold,
                    FontSize = 18,
                    Margin = new Thickness(0, 10, 0, 5)
                };
                CategoryPanel.Children.Add(categoryHeader);

                foreach (var item in group.Items)
                {
                    var row = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 2, 0, 2) };
                    row.Children.Add(new TextBlock { Text = item.ItemName, Width = 250, FontSize = 16});
                    row.Children.Add(new TextBlock { Text = $"Yêu cầu: {item.QuantityRequested}", Width = 150, FontSize = 16});
                    row.Children.Add(new TextBlock { Text = $"Kho: {item.QuantityAvailable}", Width = 150, FontSize = 16});
                    CategoryPanel.Children.Add(row);
                }
            }
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.CanDistribute())
            {
                _viewModel.Distribute();
                MessageBox.Show("Đã phê duyệt và phân phối thành công.");
                HideButtons();
            }
            else
            {
                MessageBox.Show("Không đủ hàng trong kho để phân phối.");
                // Giữ lại nút để người dùng có thể chọn từ chối
            }
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            RejectSection.Visibility = Visibility.Visible;
        }

        private void ConfirmReject_Click(object sender, RoutedEventArgs e)
        {
            string reason = RejectReasonBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("Vui lòng nhập lý do từ chối.");
                return;
            }

            _viewModel.Reject(reason);
            MessageBox.Show("Chiến dịch đã bị từ chối.");
            HideButtons();
        }

        private void HideButtons()
        {
            ApproveButton.Visibility = Visibility.Collapsed;
            RejectButton.Visibility = Visibility.Collapsed;
            RejectSection.Visibility = Visibility.Collapsed;
        }

    }
}
