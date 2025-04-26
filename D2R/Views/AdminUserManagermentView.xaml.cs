using System.Windows;
using System.Windows.Controls;

namespace D2R.Views
{
    public partial class AdminUserManagermentView : UserControl
    {
        // Lớp để đại diện cho một tài khoản
        public class Account
        {
            public string TenTaiKhoan { get; set; }
            public string Email { get; set; }
            public string MatKhau { get; set; }
        }

        private List<Account> accounts; // Danh sách lưu tài khoản đã thêm

        public AdminUserManagermentView()
        {
            InitializeComponent();

            // Khởi tạo danh sách rỗng
            accounts = new List<Account>();
            dgAccounts.ItemsSource = accounts;
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            string tenTaiKhoan = txtUsername.Text;
            string email = txtEmail.Text;
            string matKhau = txtPassword.Password;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Tạo tài khoản mới và thêm vào danh sách
            var newAccount = new Account
            {
                TenTaiKhoan = tenTaiKhoan,
                Email = email,
                MatKhau = matKhau
            };
            accounts.Add(newAccount);

            // Cập nhật lại danh sách hiển thị
            dgAccounts.ItemsSource = null;
            dgAccounts.ItemsSource = accounts;

            // Thông báo thành công
            MessageBox.Show($"Thêm tài khoản thành công!\nTên: {tenTaiKhoan}\nEmail: {email}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            // Xóa dữ liệu nhập sau khi thêm
            txtUsername.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Password = string.Empty;
        }
    }
}