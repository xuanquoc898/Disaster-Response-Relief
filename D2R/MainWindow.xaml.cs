using D2R.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace D2R
{
    /// <summary>
    /// Interaction logic for TestWin.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isMaximized = false;
        private double lastWidth, lastHeight, lastLeft, lastTop;

        public MainWindow()
        {
            InitializeComponent();
            var Mw = new MainWindowViewModel();
            DataContext = Mw;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(40, 255, 255, 255));
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ((System.Windows.Controls.Button)sender).Background = Brushes.Transparent;
        }
        private void CloseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ((System.Windows.Controls.Button)sender).Background = new SolidColorBrush(Color.FromRgb(200, 0, 0));
        }

        private void CloseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ((System.Windows.Controls.Button)sender).Background = Brushes.Transparent;
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)!.WindowState = WindowState.Minimized;
        }

        private void MaximizeRestore_Click(object sender, RoutedEventArgs e)
        {
            if (isMaximized)
            {
                this.Width = lastWidth;
                this.Height = lastHeight;
                this.Left = lastLeft;
                this.Top = lastTop;
                isMaximized = false;
            }
            else
            {
                lastWidth = this.Width;
                lastHeight = this.Height;
                lastLeft = this.Left;
                lastTop = this.Top;

                this.WindowState = WindowState.Normal;


                this.Width = SystemParameters.WorkArea.Width;
                this.Height = SystemParameters.WorkArea.Height;
                this.Left = SystemParameters.WorkArea.Left;
                this.Top = SystemParameters.WorkArea.Top;
                isMaximized = true;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)!.Close();
        }

        private void ResizeLeft(object sender, DragDeltaEventArgs e)
        {
            double newWidth = Width - e.HorizontalChange;
            if (newWidth >= MinWidth)
            {
                Width = newWidth;
                Left += e.HorizontalChange;
            }
        }

        private void ResizeRight(object sender, DragDeltaEventArgs e)
        {
            double newWidth = Width + e.HorizontalChange;
            if (newWidth >= MinWidth)
            {
                Width = newWidth;
            }
        }

        private void ResizeTop(object sender, DragDeltaEventArgs e)
        {
            double newHeight = Height - e.VerticalChange;
            if (newHeight >= MinHeight)
            {
                Height = newHeight;
                Top += e.VerticalChange;
            }
        }

        private void ResizeBottom(object sender, DragDeltaEventArgs e)
        {
            double newHeight = Height + e.VerticalChange;
            if (newHeight >= MinHeight)
            {
                Height = newHeight;
            }
        }

        private void ResizeTopLeft(object sender, DragDeltaEventArgs e)
        {
            ResizeLeft(sender, e);
            ResizeTop(sender, e);
        }

        private void ResizeTopRight(object sender, DragDeltaEventArgs e)
        {
            ResizeRight(sender, e);
            ResizeTop(sender, e);
        }

        private void ResizeBottomLeft(object sender, DragDeltaEventArgs e)
        {
            ResizeLeft(sender, e);
            ResizeBottom(sender, e);
        }

        private void ResizeBottomRight(object sender, DragDeltaEventArgs e)
        {
            ResizeRight(sender, e);
            ResizeBottom(sender, e);
        }

    }
}
