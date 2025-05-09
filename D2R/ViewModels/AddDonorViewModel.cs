using System.Windows.Documents;
using D2R.Models;
using D2R.Services;
namespace D2R.ViewModels
{
    public class AddDonorViewModel
    {
        private DonorService _service = new();
        private List<Donor> _donors = new();
        public IEnumerable<Donor> Donors => _donors;

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
        }

        public List<Donor> GetAllDonors()
        {
            _donors = _service.GetAllDonors();
            return _donors;
        }

        public List<Donor> SearchDonorByName(string name)
        {
            List<Donor> donorsTmp = new();
            foreach (var donor in _donors)
            {
                if (donor.FullName.Contains(name))
                {
                    donorsTmp.Add(donor);
                }
            }
            return donorsTmp;
        }
        
    }
}
