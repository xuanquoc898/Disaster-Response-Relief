using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace D2R.Views
{
    /// <summary>
    /// Interaction logic for InfoManagementPage.xaml
    /// </summary>
    public partial class DonorManagementPage : Page
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
