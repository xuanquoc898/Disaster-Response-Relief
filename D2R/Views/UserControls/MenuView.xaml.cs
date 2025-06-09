using D2R.Helpers;
using D2R.Services;
using D2R.ViewModels;
using D2R.Views.Admin;
using D2R.Views.Users;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace D2R.Views.UserControls
{
    public partial class MenuView : UserControl, INotifyPropertyChanged // interface dùng để thông báo thay đổi dữ liệu trong ViewModel đến View
    {
        private bool _isSidebarExpanded = true;
        private bool _isAdminExpanded = true;

        public bool IsSidebarExpanded
        {
            get => _isSidebarExpanded;
            set { _isSidebarExpanded = value; OnPropertyChanged(); // sự kiện gọi khi có sự thay đổi giá trị của biến
            }
        }

        public bool IsAdminExpanded
        {
            get => _isAdminExpanded;
            set { _isAdminExpanded = value; OnPropertyChanged(); }
        }

        public MenuView()
        {
            InitializeComponent();
            MainContent.Content = new StartView();
            CheckPermittedAccess();
            ShowWelcomeNotification();
        }

        private bool IsCurrentUserAdmin() => LoginSession.CurrentUser?.Role.RoleName == "Admin";
        private bool IsCurrentUserStaff() => LoginSession.CurrentUser?.Role.RoleName == "Staff";

        private void ShowWelcomeNotification()
        {
            Noti.VerticalAlignment = VerticalAlignment.Top;
            Noti.HorizontalAlignment = HorizontalAlignment.Left;
            Noti.ShowNotification($"Xin chào {LoginSession.CurrentUser?.Username}!", "Chúc bạn một ngày tốt lành.");
        }
        private void CheckPermittedAccess()
        {
            bool isAdmin = IsCurrentUserAdmin();
            bool isStaff = IsCurrentUserStaff();

            UmButton.Visibility = isStaff ? Visibility.Collapsed : Visibility.Visible;
            DonnorButton.Visibility = isAdmin ? Visibility.Collapsed : Visibility.Visible;
            CvButton.Visibility = isAdmin ? Visibility.Collapsed : Visibility.Visible;
            DonationButton.Visibility = isAdmin ? Visibility.Collapsed : Visibility.Visible;


            DisButton.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            StaCampButton.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            StatisticCampButton.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }
        private void LoadNotifications()
        {
            var service = new NotificationDetailService();
            var notifications = service.GetNotificationsByUserId(LoginSession.CurrentUser.UserId);

            NotificationList.Items.Clear();
            foreach (var noti in notifications)
            {
                var item = new ListBoxItem
                {
                    Content = noti.Content,
                    FontWeight = noti.IsRead.GetValueOrDefault() ? FontWeights.Normal : FontWeights.Bold,
                    Tag = noti
                };
                NotificationList.Items.Add(item);
            }
        }


        private void AnimateSidebar(double from, double to)
        {
            SidebarPanel.BeginAnimation(WidthProperty, new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(100),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            });
        }

        private void SidebarToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            AnimateSidebar(SidebarPanel.ActualWidth, IsCurrentUserStaff() ? 190 : 220);
            IsSidebarExpanded = true;
        }

        private void SidebarToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            AnimateSidebar(SidebarPanel.ActualWidth, 54);
            IsSidebarExpanded = false;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
            => MainContent.Content = new StartView();

        private void ManageAccounts_Click(object sender, RoutedEventArgs e)
        {
            if (LoginSession.CurrentUser.RoleId == 1)
                MainContent.Content = new UserManagermentView();
        }

        private void ManageDonors_Click(object sender, RoutedEventArgs e)
            => MainContent.Content = new DonorManagerment();

        private void ManageDonation_Click(object sender, RoutedEventArgs e)
        {
            int warehouseId = LoginSession.CurrentUser?.WarehouseId ?? 0;
            MainContent.Content = new DonationView(warehouseId);
        }

        private void RequestSupport_Click(object sender, RoutedEventArgs e)
            => MainContent.Content = new CreateCampaignView();

        private void ManageWarehouse_Click(object sender, RoutedEventArgs e)
        {
            int? warehouseId = LoginSession.CurrentUser?.WarehouseId;
            MainContent.Content = new WarehouseLocalView(warehouseId);
        }

        private void Sync_Click(object sender, RoutedEventArgs e)
        {
            var user = LoginSession.CurrentUser;

            if (user.Role.RoleName == "Admin")
            {
                MainContent.Content = new AdminSyncView();
            }
            else
            {
                int warehouseId = user.WarehouseId ?? 0;
                MainContent.Content = new SyncView(warehouseId);
            }
        }


        private void DistributionAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (IsCurrentUserAdmin())
                MainContent.Content = new PlannedCampaignListView();
        }

        private void CheckAdmin_Click(object sender, RoutedEventArgs e)
            => MainContent.Content = new StatusCampaignView();

        private void StatisticCampButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsCurrentUserAdmin())
                MainContent.Content = new AdminStatisticsView();
        }

        private void NotificationButton_Click(object sender, RoutedEventArgs e)
        {
            LoadNotifications();
            NotificationPopup.IsOpen = true;
        }

        private void NotificationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NotificationList.SelectedItem is ListBoxItem item && item.Tag is Notification noti)
            {
                var service = new NotificationDetailService();
                service.MarkNotificationAsRead(noti.NotificationId);

                MainContent.Content = new NotificationDetailView(noti);
                NotificationPopup.IsOpen = false;
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow parentWindow)
            {
                parentWindow.DataContext = new MainWindowViewModel();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
