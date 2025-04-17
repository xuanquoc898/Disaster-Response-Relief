using D2R.Views.UserControls;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace D2R.Views
{
    public partial class MainLayout : UserControl, INotifyPropertyChanged
    {
        private bool _isSidebarExpanded = true;

        public bool IsSidebarExpanded
        {
            get => _isSidebarExpanded;
            set { _isSidebarExpanded = value; OnPropertyChanged(); }
        }

        public MainLayout()
        {
            InitializeComponent();
            MainContent.Content = new StartView();
        }

        private void AnimateSidebar(double from, double to)
        {
            var animation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(300),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };
            SidebarPanel.BeginAnimation(WidthProperty, animation);
        }

        private void SidebarToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            AnimateSidebar(SidebarPanel.ActualWidth, 180);
            IsSidebarExpanded = true;
        }

        private void SidebarToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            AnimateSidebar(SidebarPanel.ActualWidth, 55);
            IsSidebarExpanded = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StartView();
        }

        private void ManageAccounts_Click(object sender, RoutedEventArgs e)
        {
            //MainContent.Content = new (); 
        }

        private void ManageDonors_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new DonorManagerment();
        }

        private void ManageWarehouse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RequestSupport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
