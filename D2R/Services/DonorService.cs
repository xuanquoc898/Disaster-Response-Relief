using D2R.Helpers;
using D2R.Models;
using D2R.Repositories;
using System.Windows;
using D2R.ViewModels;
namespace D2R.Services
{
    public class DonorService
    {
        private readonly DonorRepository _repository;

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
        public void Add(Donor entity, List<Donor>? donors)
        {
            try
            {
                String message = "";
                if (ValidationHelper.CheckName(entity.FullName,  out message))
                {
                    throw new ArgumentException(message);
                }
                if (string.IsNullOrWhiteSpace(entity.FullName))
                    throw new ArgumentException("Tên không được để trống.");
                if (!ValidationHelper.IsValidCanCuocCongDan(entity.Cccd))
                    throw new ArgumentException("Sai kiểu mẫu của căn cước công dân");
                if (!ValidationHelper.IsValidPhoneNumber(entity.Phone))
                    throw new ArgumentException("Sai kiểu mẫu của số điện thoại");
                if (!ValidationHelper.IsValidEmailAddress(entity.Email))
                    throw new ArgumentException("Sai định dạng Email");
                _repository.Add(entity);
                donors?.Add(entity);
                MessageBox.Show("Đã thêm MTQ thành công!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Dữ liệu không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
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
