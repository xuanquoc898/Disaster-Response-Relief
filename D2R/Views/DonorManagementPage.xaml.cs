using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using D2R.Views.UserControls;

namespace D2R.Views
{
    /// <summary>
    /// Interaction logic for DonorManagementPage.xaml
    /// </summary>
    
    public partial class DonorManagementPage : UserControl
    {
        public DonorManagementPage()
        {
            InitializeComponent();
        }
        
        

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to AddDonorPage or show dialog
            // NavigationService?.Navigate(new AddDonorPage());
            Content = new DonorView();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }

        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}
