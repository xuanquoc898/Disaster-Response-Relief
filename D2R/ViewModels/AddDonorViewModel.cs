using System.Windows.Documents;
using D2R.Models;
using D2R.Services;
namespace D2R.ViewModels
{
    public class AddDonorViewModel
    {
        private DonorService _service = new();

        public void AddDonor(string name, string cccd, string phone, string email)
        {
            var donor = new Donor
            {
                FullName = name,
                Cccd = cccd,
                Phone = phone,
                Email = email
            };
            _service.Add(donor);
            return;
        }

        public List<Donor> GetAllDonors()
        {
            return _service.GetAllDonors();
        }
    }
}
