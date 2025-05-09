using System.Windows;
using System.Windows.Controls;
using D2R.ViewModels;
namespace D2R.Views.Users
{
    /// <summary>
    /// Interaction logic for DonorManagerment.xaml
    /// </summary>
    public partial class DonorManagerment : UserControl
    {
        private readonly AddDonorViewModel _donorVM;
        
        public DonorManagerment()
        {
            InitializeComponent();
            _donorVM = new AddDonorViewModel();
            LoadDonor();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Content = new AddDonorView();
        }

        private void LoadDonor()
        {
            DonorMgDataGrid.ItemsSource = _donorVM.GetAllDonors();
        }
    }
}
