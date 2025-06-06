using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.UserControls
{
    public partial class WarehouseLocalView : UserControl
    {
        private readonly WarehouseLocalViewModel _viewModel;
        private List<WarehouseStockDisplay> _allStock;

        public WarehouseLocalView(int? warehouseId)
        {
            InitializeComponent();
            _viewModel = new WarehouseLocalViewModel(warehouseId);
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            _allStock = _viewModel.GetGroupedStock();
            StockListView.ItemsSource = _allStock;
            NoItemsText.Visibility = _allStock.Count == 0 ? Visibility.Visible : Visibility.Collapsed;

            CategoryComboBox.ItemsSource = _viewModel.GetAllCategories();
            CategoryComboBox.SelectedIndex = 0;
            ItemComboBox.ItemsSource = _viewModel.GetItemNamesByCategory("Tất cả");
            ItemComboBox.SelectedIndex = 0;
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCategory = CategoryComboBox.SelectedItem?.ToString() ?? "Tất cả";
            ItemComboBox.ItemsSource = _viewModel.GetItemNamesByCategory(selectedCategory);
            ItemComboBox.SelectedIndex = 0;
            ApplyFilter();
        }

        private void ItemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string selectedCategory = CategoryComboBox.SelectedItem?.ToString() ?? "Tất cả";
            string selectedItem = ItemComboBox.SelectedItem?.ToString() ?? "Tất cả";

            var filtered = _viewModel.GetFilteredStock(selectedCategory, selectedItem);
            StockListView.ItemsSource = filtered;
            NoItemsText.Visibility = filtered.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

    }
}