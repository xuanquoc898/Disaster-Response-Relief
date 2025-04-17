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
using D2R.Views.UserControls;
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
        public Action<UserControl> Navigate;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Content = new AddDonorView();
            // Navigate?.Invoke(new AddDonorView());
        }
    }
}
