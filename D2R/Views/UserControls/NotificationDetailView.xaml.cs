using D2R.Helpers;
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.UserControls
{
    public partial class NotificationDetailView : UserControl
    {
        private readonly NotificationDetailViewModel _viewModel;

        public NotificationDetailView(Notification notification)
        {
            InitializeComponent();
            _viewModel = new NotificationDetailViewModel(notification);
            LoadNotification();
        }

        public void LoadNotification()
        {
            NotificationContentText.Text = _viewModel.Notification.Content;
            CreatedAtText.Text = _viewModel.Notification.CreatedAt?.ToString("dd/MM/yyyy") ?? "Không rõ";

            if (_viewModel.Campaign != null)
            {
                CampaignDetailPanel.Visibility = Visibility.Visible;

                CampaignNoteText.Text = _viewModel.Campaign.Title;
                CampaignStatusText.Text = _viewModel.Campaign.Status;

                string status = _viewModel.Campaign.Status;
                string dateDisplay = status switch
                {
                    "Approved" => _viewModel.Campaign.ApprovedAt?.ToString("dd/MM/yyyy"),
                    "Rejected" => _viewModel.Campaign.RejectedAt?.ToString("dd/MM/yyyy"),
                    "Completed" => _viewModel.Campaign.CompletedAt?.ToString("dd/MM/yyyy"),
                    _ => null
                } ?? "Không rõ";

                CampaignApprovedOrRejectedAtText.Text = dateDisplay;
                if (status == "Rejected" && !string.IsNullOrWhiteSpace(_viewModel.Campaign.Note))
                {
                    NotePanel.Visibility = Visibility.Visible;
                    CampaignNoteReasonText.Text = _viewModel.Campaign.Note;
                }

                bool isStaff = LoginSession.CurrentUser?.Role.RoleName == "Staff";
                ConfirmButton.Visibility = (status == "Approved" && isStaff) ? Visibility.Visible : Visibility.Collapsed;
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

            MessageBox.Show("✅ Xác nhận thành công! Hàng hóa đã được cộng vào kho của bạn.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            ConfirmButton.IsEnabled = false;
            ConfirmButton.Content = "Đã xác nhận";
        }
    }
}
