using System.Windows;
using System.Windows.Controls;
using D2R.Models;
using D2R.ViewModels;

namespace D2R.Views.UserControls
{
    public partial class NotificationDetailView : UserControl
    {
        private readonly NotificationDetailViewModel _viewModel;

        public NotificationDetailView(Notification notification)
        {
            InitializeComponent();

            _viewModel = new NotificationDetailViewModel(notification);

            NotificationContentText.Text = _viewModel.Notification.Content;
            CreatedAtText.Text = _viewModel.Notification.CreatedAt?.ToString("dd/MM/yyyy") ?? "Không rõ";

            if (_viewModel.Campaign != null)
            {
                CampaignDetailPanel.Visibility = Visibility.Visible;

                CampaignNoteText.Text = _viewModel.Campaign.Note;
                CampaignStatusText.Text = _viewModel.Campaign.Status;

                if (_viewModel.Campaign.Status == "Approved")
                {
                    CampaignApprovedOrRejectedAtText.Text = _viewModel.Campaign.ApprovedAt?.ToString("dd/MM/yyyy") ?? "Không rõ";
                    ConfirmButton.Visibility = Visibility.Visible;
                }
                else if (_viewModel.Campaign.Status == "Rejected")
                {
                    CampaignApprovedOrRejectedAtText.Text = _viewModel.Campaign.RejectedAt?.ToString("dd/MM/yyyy") ?? "Không rõ";
                    ConfirmButton.Visibility = Visibility.Collapsed;
                }
                else if (_viewModel.Campaign.Status == "Completed")
                {
                    CampaignApprovedOrRejectedAtText.Text = _viewModel.Campaign.CompletedAt?.ToString("dd/MM/yyyy") ?? "Không rõ";
                    ConfirmButton.Visibility = Visibility.Collapsed;
                }
            }

            _viewModel.MarkNotificationAsRead();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_viewModel.CanConfirm())
            {
                MessageBox.Show("Chiến dịch này không thể xác nhận nhận hàng.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _viewModel.ConfirmReceived();

            MessageBox.Show("Xác nhận thành công. Hàng hóa đã được cộng vào kho của bạn.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            ConfirmButton.IsEnabled = false;
            ConfirmButton.Content = "Đã xác nhận";
        }
    }
}
