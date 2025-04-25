using System.Windows;
using System.Windows.Controls;
using D2R.ViewModels;
using D2R.Helpers;

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

            CampaignNoteText.Text = _viewModel.Campaign.Note;
            DisasterTypeText.Text = _viewModel.Campaign.DisasterLevel?.DisasterType?.Name ?? "Không rõ";
            DisasterLevelText.Text = _viewModel.Campaign.DisasterLevel?.Level ?? "Không rõ";

            foreach (var group in _viewModel.GroupedItems)
            {
                var categoryHeader = new TextBlock
                {
                    Text = $"Danh mục: {group.CategoryName}",
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 10, 0, 5)
                };
                CategoryPanel.Children.Add(categoryHeader);

                foreach (var item in group.Items)
                {
                    var row = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 2, 0, 2) };
                    row.Children.Add(new TextBlock { Text = item.ItemName, Width = 250 });
                    row.Children.Add(new TextBlock { Text = $"Yêu cầu: {item.QuantityRequested}", Width = 150 });
                    row.Children.Add(new TextBlock { Text = $"Kho: {item.QuantityAvailable}", Width = 150 });
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
            }
            else
            {
                MessageBox.Show("Không đủ hàng trong kho để phân phối.");
            }
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Reject();
            MessageBox.Show("Chiến dịch đã bị từ chối.");
        }
    }
}
