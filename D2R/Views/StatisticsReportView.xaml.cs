using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace D2R.Views
{
    public partial class StatisticsReportView : UserControl
    {
        public StatisticsReportView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chuyển đến trang tiếp theo");
        }
    }
}