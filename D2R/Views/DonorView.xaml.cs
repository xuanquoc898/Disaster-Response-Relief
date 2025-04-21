using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using D2R.Models;
using D2R.Repositories;
using D2R.Services;
using Microsoft.EntityFrameworkCore;

namespace D2R.Views
{
    public partial class DonorView : UserControl
    {
        // private readonly DonorViewModel _donorVM = new();
        // private readonly ItemViewModel _itemVM = new();

        //private int _currentDonorId = -1;
        
        public DonorView()
        {
            InitializeComponent();
        }

        private void BtnAddDonor_Click(object sender, RoutedEventArgs e)
        {
            //new DonorService().Add(new Donor(){FullName = txtName.Text, Email = txtEmail.Text, Phone = txtPhone.Text});
            //dgDonors.Columns.Add();
            //dgDonors.UpdateLayout();
        }
    }
}
