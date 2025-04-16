using System;
using System.Windows;
using System.Windows.Input;

namespace D2R.Views
{
    /// <summary>
    /// Interaction logic for DonorManagementPage.xaml
    /// </summary>
    public partial class DonorManagementPage : Window
    {
        public DonorManagementPage()
        {
            InitializeComponent();
        }

        private void AddDonation_Click(object sender, MouseButtonEventArgs e)
        {
            new DonorView().ShowDialog();
        }

        private void UpdateDonation_Click(object sender, MouseButtonEventArgs e)
        {
            // _mainFrame.Navigate(new UpdateDonationPage());
        }

        private void TrackStatus_Click(object sender, MouseButtonEventArgs e)
        {
            // _mainFrame.Navigate(new TrackDonationStatusPage());
        }

        private void ShowDonors_Click(object sender, MouseButtonEventArgs e)
        {
            // _mainFrame.Navigate(new DonorListPage());
        }

        private void CheckHistory_Click(object sender, MouseButtonEventArgs e)
        {
            // _mainFrame.Navigate(new DonationHistoryPage());
        }
    }
}