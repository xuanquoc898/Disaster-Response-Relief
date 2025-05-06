using System.Windows;
using System.Windows.Controls;
namespace D2R.Views.Users
{
    /// <summary>
    /// Interaction logic for DonorManagerment.xaml
    /// </summary>
    public partial class DonorManagerment : UserControl
    {
        public DonorManagerment()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Content = new AddDonorView();
        }
    }
}
