using D2R.Models;
using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views.Admin;

public partial class UserManagermentView : UserControl
{

    private readonly UserManagementViewModel _viewModel = new UserManagementViewModel();

    public UserManagermentView()
    {
        InitializeComponent();
        DataGridUsers.ItemsSource = _viewModel.Users;
        CbbWarehouseName.ItemsSource = _viewModel.Warehouses;
    }
    
    private void CbbWarehouseName_Loaded(object sender, RoutedEventArgs e)
    {
        var textBox = (TextBox)CbbWarehouseName.Template.FindName("PART_EditableTextBox", CbbWarehouseName);
        if (textBox != null)
        {
            textBox.TextChanged += TextBox_TextChanged;
        }
    }
    
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text) && !_viewModel.NameWarehouseIsExist(CbbWarehouseName.Text))
        {
            LocationTextBlock.Visibility = Visibility.Visible;
            LocationGrid.Visibility = Visibility.Visible;
        }
        else
        {
            LocationTextBlock.Visibility = Visibility.Collapsed;
            LocationGrid.Visibility = Visibility.Collapsed;
        }
    }

    private void DataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var user = DataGridUsers.SelectedItem as User;
        _viewModel.SelectUser(user);
    }
    private void BtnAddUser_Click(object sender, RoutedEventArgs e)
    {
        Area area = new Area();
        area.Name = TxtNameLocation.Text;
        area.District = TxtDistrictLocation.Text;
        area.Province = TxtProvinceLocation.Text;

        string warehouseName = CbbWarehouseName.Text;
        
        _viewModel.AddUser(
            TxtUsername.Text.Trim(),
            PwdPassword.Password,
            ((ComboBoxItem)CbxRole.SelectedItem).Content.ToString(),
            warehouseName,
            area
        );
        DataGridUsers.ItemsSource = _viewModel.Users;
        BtnClearForm_Click(sender, e);
    }

    private void BtnClearForm_Click(object sender, RoutedEventArgs e)
    {
        TxtUsername.Clear();
        PwdPassword.Clear();
        CbxRole.SelectedIndex = -1;
        CbbWarehouseName.SelectedIndex = -1;
        CbbWarehouseName.Text = null;
        TxtNameLocation.Clear();
        TxtDistrictLocation.Clear();
        TxtProvinceLocation.Clear();
        LocationTextBlock.Visibility = Visibility.Collapsed;
        LocationGrid.Visibility = Visibility.Collapsed;
        _viewModel.ClearSelection();
        DataGridUsers.UnselectAll();
    }

    private void RowResetPassword_Click(object sender, RoutedEventArgs e)
    {
        User user = null;
        if (sender is MenuItem mi)
            user = mi.DataContext as User;
        else if (sender is Button btn)
            user = btn.DataContext as User;
        if (user != null)
        {
            _viewModel.SelectUser(user);
            var newPass = _viewModel.ResetPassword();
            if (newPass != null)
                MessageBox.Show($"Mật khẩu mới cho {user.Username}");
        }
    }

    private void RowDeleteUser_Click(object sender, RoutedEventArgs e)
    {
        User user = null;
        if (sender is MenuItem mi)
            user = mi.DataContext as User;
        else if (sender is Button btn)
            user = btn.DataContext as User;
        if (user != null)
        {
            if (MessageBox.Show($"Xác nhận xóa {user.Username}?", "Xóa người dùng", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                _viewModel.SelectUser(user);
                if (_viewModel.DeleteUser())
                {
                    DataGridUsers.ItemsSource = _viewModel.Users;
                }
            }
        }
    }

    private void RowActions_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.ContextMenu != null)
        {
            btn.ContextMenu.DataContext = btn.DataContext;
            btn.ContextMenu.PlacementTarget = btn;
            btn.ContextMenu.IsOpen = true;
        }
    }

}
