using System.Windows;
using System.Windows.Controls;
using D2R.Models;
using D2R.ViewModels;

namespace D2R.Views;

public partial class UserManagermentView : UserControl
{
    
    private readonly UserManagementViewModel _viewModel = new UserManagementViewModel();

    public UserManagermentView()
    {
        InitializeComponent();
        DataGridUsers.ItemsSource = _viewModel.Users;

    }
    
    // private void BtnRefresh_Click(object sender, RoutedEventArgs e)
    // {
    //     _viewModel.LoadUsers();
    //     DataGridUsers.ItemsSource = _viewModel.Users;
    // }
    
    private void DataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var user = DataGridUsers.SelectedItem as User;
        _viewModel.SelectUser(user);
    }

    private void BtnAddUser_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.AddUser(
            TxtUsername.Text.Trim(),
            PwdPassword.Password,
            ((ComboBoxItem)CbxRole.SelectedItem).Content.ToString(),
            TxtWarehouseName.Text.Trim(),
            TxtWarehouseLocation.Text.Trim()
        );
        DataGridUsers.ItemsSource = _viewModel.Users;
        BtnClearForm_Click(sender, e);
    }

    private void BtnClearForm_Click(object sender, RoutedEventArgs e)
    {
        TxtUsername.Clear();
        PwdPassword.Clear();
        CbxRole.SelectedIndex = -1;
        TxtWarehouseName.Clear();
        TxtWarehouseLocation.Clear();
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
