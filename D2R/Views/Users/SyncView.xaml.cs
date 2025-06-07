using D2R.Models;
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.Users
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
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đồng bộ? Tất cả hàng trong kho này sẽ chuyển về kho trung tâm.",
                                          "Xác nhận đồng bộ",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Warning);

            if (confirm == MessageBoxResult.Yes)
            {
                _viewModel.Sync();
                MessageBox.Show("Đồng bộ thành công!");
                LoadHistory();
            }
        }

        private void LoadHistory()
        {
            List<SyncLog> logs = _viewModel.GetSyncHistory();
            SyncDataGrid.ItemsSource = logs;
        }
    }
}