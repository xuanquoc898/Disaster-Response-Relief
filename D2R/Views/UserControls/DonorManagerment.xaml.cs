using System.Windows;
using System.Windows.Controls;
namespace D2R.Views.UserControls
{
    /// <summary>
    /// Interaction logic for DonorManagerment.xaml
    /// </summary>
    public partial class DonorManagerment : UserControl
    {
        public DonorManagerment(object Content)
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Content = new AddDonorView();
            // Navigate?.Invoke(new AddDonorView());
        }
    }
}
