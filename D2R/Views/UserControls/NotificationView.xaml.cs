using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace D2R.Views.UserControls
{
    public partial class NotificationView : UserControl
    {
        private DispatcherTimer _autoCloseTimer;

        public NotificationView()
        {
            InitializeComponent();

            _autoCloseTimer = new DispatcherTimer();
            _autoCloseTimer.Interval = TimeSpan.FromSeconds(5);
            _autoCloseTimer.Tick += AutoCloseTimer_Tick;
            _autoCloseTimer.Start();
        }

        private void AutoCloseTimer_Tick(object sender, EventArgs e)
        {
            _autoCloseTimer.Stop();
            Visibility = Visibility.Collapsed;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _autoCloseTimer.Stop();
            Visibility = Visibility.Collapsed;
        }
        public void ShowNotification(string title, string message, int seconds = 5)
        {
            TitleTextBlock.Text = title;
            MessageTextBlock.Text = message;
            Visibility = Visibility.Visible;

            _autoCloseTimer.Interval = TimeSpan.FromSeconds(seconds);
            _autoCloseTimer.Stop();
            _autoCloseTimer.Start();
        }
    }
}