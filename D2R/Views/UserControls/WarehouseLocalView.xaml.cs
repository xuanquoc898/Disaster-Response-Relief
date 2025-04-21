using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.UserControls
{
    public partial class WarehouseLocalView : UserControl
    {
        private readonly WarehouseLocalViewModel _viewModel;

        public WarehouseLocalView(int warehouseId)
        {
            InitializeComponent();
            _viewModel = new WarehouseLocalViewModel(warehouseId);
            LoadStock();
        }

        private void LoadStock()
        {
            var list = _viewModel.GetGroupedStock();
            StockListView.ItemsSource = list;
            // Hiển thị thông báo nếu rỗng
            NoItemsText.Visibility = list.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}