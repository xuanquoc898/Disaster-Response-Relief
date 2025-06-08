using D2R.Models;
using D2R.ViewModels;
using System.Windows.Controls;

namespace D2R.Views.Admin
{
    public partial class AdminSyncView : UserControl
    {
        private readonly AdminSyncViewModel _viewModel;

        public AdminSyncView()
        {
            InitializeComponent();
            _viewModel = new AdminSyncViewModel();
            LoadWarehouses();
            LoadLogs();
        }

        private void LoadWarehouses()
        {
            var warehouses = _viewModel.GetAllWarehouses();
            warehouses.Insert(0, new Warehouse { WarehouseId = -1, Name = "Tất cả kho" });
            WarehouseFilterComboBox.ItemsSource = warehouses;
            WarehouseFilterComboBox.DisplayMemberPath = "Name";
            WarehouseFilterComboBox.SelectedIndex = 0;
        }

        private void LoadLogs(int? warehouseId = null)
        {
            var logs = _viewModel.GetLogs(warehouseId);
            SyncLogDataGrid.ItemsSource = logs;
        }

        private void WarehouseFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = WarehouseFilterComboBox.SelectedItem as Warehouse;
            LoadLogs(selected?.WarehouseId == -1 ? null : selected?.WarehouseId);
        }
    }
}
