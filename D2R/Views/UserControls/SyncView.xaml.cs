using D2R.Models;
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.UserControls
{
    public partial class SyncView : UserControl
    {
        private readonly SyncViewModel _viewModel;

        public SyncView(int warehouseId)
        {
            InitializeComponent();
            _viewModel = new SyncViewModel(warehouseId);
            LoadHistory();
        }

        private void BtnSync_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Sync();
            MessageBox.Show("Đồng bộ thành công!");
            LoadHistory();
        }

        private void LoadHistory()
        {
            List<SyncLog> logs = _viewModel.GetSyncHistory();
            SyncDataGrid.ItemsSource = logs;
        }
    }
}