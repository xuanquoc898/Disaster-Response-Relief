using D2R.Helpers;
using D2R.Models;
using D2R.Repositories;
using D2R.ViewModels;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Text.RegularExpressions;
using System.Windows;

namespace D2R.Services
{
    public class DonorService
    {
        private readonly DonorRepository _repository;
        public bool AddDonorSuccess = false;

        public DonorService()
        {
            _repository = new DonorRepository();
        }

        public List<Donor> GetAllByKey(string keyword)
        {
            return _repository.GetAllByKey(keyword);
        }

        public List<Donor> GetAllDonors()
        {
            return _repository.GetAll();
        }
        public void Add(Donor entity, List<Donor> donors)
        {
            try
            {
                string message = "";

                if (!ValidationHelper.CheckName(entity.FullName, out message))
                    throw new ArgumentException(message);

                if (!ValidationHelper.IsValidCanCuocCongDan(entity.Cccd))
                    throw new ArgumentException("Sai kiểu mẫu của căn cước công dân");

                if (!ValidationHelper.IsValidPhoneNumber(entity.Phone))
                    throw new ArgumentException("Sai kiểu mẫu của số điện thoại");

                if (!ValidationHelper.IsValidEmailAddress(entity.Email))
                    throw new ArgumentException("Sai định dạng Email");

                _repository.Add(entity);
                AddDonorSuccess = true;
                donors.Add(entity);
                MessageBox.Show("Đã thêm MTQ thành công!");
            }
            catch (ArgumentException ex)
            {
                AddDonorSuccess = false;
                MessageBox.Show(ex.Message, "Dữ liệu không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (DbUpdateException dbEx)
            {
                AddDonorSuccess = false;
                if (dbEx.InnerException is MySqlException mysqlEx && mysqlEx.Number == 1062)
                {
                    string duplicatedField = "Không xác định";
                    var match = Regex.Match(mysqlEx.Message, @"for key '(.+?)'");
                    if (match.Success)
                    {
                        string keyName = match.Groups[1].Value;
                        if (keyName.Contains("email", StringComparison.OrdinalIgnoreCase))
                            duplicatedField = "Email";
                        else if (keyName.Contains("phone", StringComparison.OrdinalIgnoreCase))
                            duplicatedField = "Số điện thoại";
                        else if (keyName.Contains("cccd", StringComparison.OrdinalIgnoreCase))
                            duplicatedField = "Căn cước công dân";
                        else
                            duplicatedField = keyName;
                    }
                    MessageBox.Show($"Dữ liệu {duplicatedField} bị trùng lặp trong hệ thống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                AddDonorSuccess = false;
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Đã xảy ra lỗi: " + message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<int> GetAvailableYears()
        {
            return _repository.GetAvailableYears();
        }

        // Lấy dữ liệu mạnh thường quân top theo năm và tiêu chí (số lần đóng góp hoặc tổng số lượng)
        public List<DonorRankingModel> GetTopDonors(int year, string criteria)
        {
            return _repository.GetTopDonorsByYearAndCriteria(year, criteria);
        }
    }
}
