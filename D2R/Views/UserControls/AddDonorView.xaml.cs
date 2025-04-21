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
using System.Windows.Navigation;
using System.Windows.Shapes;
using D2R.ViewModels;
namespace D2R.Views.UserControls
{
    /// <summary>
    /// Interaction logic for AddDonorView.xaml
    /// </summary>
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
        }
    }
}
