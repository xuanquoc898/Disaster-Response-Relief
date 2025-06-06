using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;
namespace D2R.Views.Users
{
    public partial class AddDonorView : UserControl
    {
        AddDonorViewModel _addDonorVM = new();
        public AddDonorView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _addDonorVM.AddDonor(txtName.Text, txtCCCD.Text, txtPhone.Text, txtEmail.Text);
            dgDonors.ItemsSource = _addDonorVM.Donors;
        }
    }
}
