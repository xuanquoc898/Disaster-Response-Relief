using System.Windows;
using System.Windows.Controls;
using D2R.Models;
using D2R.ViewModels;

namespace D2R.Views.Admin;

public partial class UserManagermentView : UserControl
{
    
    private readonly UserManagementViewModel _viewModel = new UserManagementViewModel();

    public UserManagermentView()
    {   
        InitializeComponent();
        DataGridUsers.ItemsSource = _viewModel.Users;
        CbbWarehouseName.ItemsSource = _viewModel.Warehouses;
        CbbNameWarehouseLocation.ItemsSource = _viewModel.Areas;
    }
    
    private void DataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var user = DataGridUsers.SelectedItem as User;
        _viewModel.SelectUser(user);
    }
    private void BtnAddUser_Click(object sender, RoutedEventArgs e)
    {
        Area area = new Area();
        area.Name = CbbNameWarehouseLocation.Text==null 
            ? ((ComboBoxItem)CbbNameWarehouseLocation.SelectedItem).Content.ToString() 
            : CbbNameWarehouseLocation.Text;
        area.District = CbbDistrictWarehouseLocation.Text==null 
            ? ((ComboBoxItem)CbbDistrictWarehouseLocation.SelectedItem).Content.ToString() 
            : CbbDistrictWarehouseLocation.Text;
        area.Province = CbbProvinceWarehouseLocation.Text==null 
            ? ((ComboBoxItem)CbbProvinceWarehouseLocation.SelectedItem).Content.ToString()
            : CbbProvinceWarehouseLocation.Text;

        string tmp = CbbWarehouseName.Text == null
            ? ((ComboBoxItem)CbbWarehouseName.SelectedItem).Content.ToString()
            : CbbWarehouseName.Text;
        
        _viewModel.AddUser(
            TxtUsername.Text.Trim(),
            PwdPassword.Password,
            ((ComboBoxItem)CbxRole.SelectedItem).Content.ToString(),
            tmp,
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
        CbbNameWarehouseLocation.SelectedIndex = -1;
        CbbDistrictWarehouseLocation.SelectedIndex = -1;
        CbbProvinceWarehouseLocation.SelectedIndex = -1;
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
