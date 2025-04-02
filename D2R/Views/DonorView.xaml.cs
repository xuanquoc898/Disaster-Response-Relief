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
            try
            {
                string name = txtName.Text.Trim();
                string phone = txtPhone.Text.Trim();

                _donorVM.AddDonor(name, phone);
                var allDonors = _donorVM.GetAllDonors();
                _currentDonorId = allDonors[^1].Id; 

                MessageBox.Show("Đã thêm donor. Tiếp tục thêm vật phẩm.");
                ClearDonorFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (_currentDonorId == -1)
            {
                MessageBox.Show("Vui lòng thêm donor trước.");
                return;
            }

            try
            {
                string itemName = txtItemName.Text.Trim();
                if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity))
                {
                    MessageBox.Show("Số lượng không hợp lệ!");
                    return;
                }
                _itemVM.AddItem(_currentDonorId, itemName, quantity);
                LoadItems();
                ClearItemFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private void BtnShowDonors_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadDonors(); // Gọi 1 lần là đủ
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}");
            }
        }


        private void LoadDonors()
        {
            lvDonors.ItemsSource = null;
            lvDonors.ItemsSource = _donorVM.GetAllDonors();
        }

        private void LoadItems()
        {
            lvItems.ItemsSource = _itemVM.GetItemsByDonor(_currentDonorId);
        }

        private void ClearDonorFields()
        {
            txtName.Text = "";
            txtPhone.Text = "";
        }

        private void ClearItemFields()
        {
            txtItemName.Text = "";
            txtQuantity.Text = "";
        }


        private void lvDonors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDonors.SelectedItem is Donor selectedDonor)
            {
                _currentDonorId = selectedDonor.Id;
                LoadItems(); // tự động hiển thị item khi chọn donor
            }
        }

    }
}
