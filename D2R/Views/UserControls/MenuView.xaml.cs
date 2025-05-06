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
    public partial class MenuView : UserControl, INotifyPropertyChanged
    {
        private bool _isSidebarExpanded = true;

        private bool _isAdminExpanded = true;
        public bool IsSidebarExpanded
        {
            get => _isSidebarExpanded;
            set { _isSidebarExpanded = value; OnPropertyChanged(); }
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
        }

        private void CheckPermittedAccess()
        {
            if (LoginSession.CurrentUser.Role.RoleName == "Staff")
            {
                UmButton.Visibility = Visibility.Collapsed;
                DisButton.Visibility = Visibility.Collapsed;
                StaCampButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                DonnorButton.Visibility = Visibility.Collapsed;
                CvButton.Visibility = Visibility.Collapsed;
                WareHouseButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AnimateSidebar(double from, double to)
        {
            var animation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(100),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            SidebarPanel.BeginAnimation(WidthProperty, animation);
        }

        private void SidebarToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            AnimateSidebar(SidebarPanel.ActualWidth, (LoginSession.CurrentUser.Role.RoleName == "Staff") ? 190 : 220);
            IsSidebarExpanded = true;
        }

        private void SidebarToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            AnimateSidebar(SidebarPanel.ActualWidth, 54);
            IsSidebarExpanded = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StartView();
        }

        private void ManageAccounts_Click(object sender, RoutedEventArgs e)
        {

            if (LoginSession.CurrentUser.RoleId == 1)
            {
                MainContent.Content = new UserManagermentView();
            }
        }

        private void ManageDonors_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new DonorManagerment();
        }

        private void ManageWarehouse_Click(object sender, RoutedEventArgs e)
        {
            int warehouseId = LoginSession.CurrentUser?.WarehouseId ?? 0;
            MainContent.Content = new DonationView(warehouseId);
        }

        private void RequestSupport_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CreateCampaignView();
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            int warehouseId = LoginSession.CurrentUser.WarehouseId ?? 0;
            MainContent.Content = new WarehouseLocalView(warehouseId);
        }

        private void Sync_Click(object sender, RoutedEventArgs e)
        {
            int warehouseId = LoginSession.CurrentUser?.WarehouseId ?? 0;
            var syncView = new SyncView(warehouseId);
            MainContent.Content = syncView;
        }
        private void DistributionAdmin_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new PlannedCampaignListView();
        }

        private void CheckAdmin_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StatusCampaignView();
        }

        private void NotificationButton_Click(object sender, RoutedEventArgs e)
        {
            var service = new NotificationService();
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

            NotificationPopup.IsOpen = true;
        }

        private void NotificationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NotificationList.SelectedItem is ListBoxItem item && item.Tag is Notification noti)
            {
                var service = new NotificationService();
                service.MarkNotificationAsRead(noti.NotificationId);

                var detailView = new NotificationDetailView(noti);
                MainContent.Content = detailView;

                NotificationPopup.IsOpen = false;
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.DataContext = new MainWindowViewModel();
            }
        }
    }
}
