using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using D2R.Models;
using D2R.ViewModels;

namespace D2R.Views
{
    public partial class DonorView : Window
    {
        private readonly DonorViewModel _donorVM = new();
        private readonly ItemViewModel _itemVM = new();

        private int _currentDonorId = -1;

        public DonorView()
        {
            InitializeComponent();
        }

        private void BtnAddDonor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
