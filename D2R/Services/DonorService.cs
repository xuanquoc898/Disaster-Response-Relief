using D2R.Helpers;
using D2R.Models;
using D2R.Repositories;
using System.Windows;
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
        public void Add(Donor entity)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(entity.FullName))
                    throw new ArgumentException("Tên không được để trống.");
                if (!ValidationHelper.IsValidCanCuocCongDan(entity.Cccd))
                    throw new ArgumentException("Sai kiểu mẫu của căn cước công dân");
                if (!ValidationHelper.IsValidPhoneNumber(entity.Phone))
                    throw new ArgumentException("Sai kiểu mẫu của số điện thoại");
                if (!ValidationHelper.IsValidEmailAddress(entity.Email))
                    throw new ArgumentException("Sai định dạng Email");
                _repository.Add(entity);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Dữ liệu không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
