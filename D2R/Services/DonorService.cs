using D2R.Models;
using D2R.Repositories;
using System.Collections.Generic;

namespace D2R.Services;

public class DonorService
{
    private DonorRepository _repo = new();

    public void AddDonor(Donor donor)
    {
        if (string.IsNullOrWhiteSpace(donor.Name))
            throw new ArgumentException("Tên không được để trống.");

        _repo.Add(donor);
    }

    public List<Donor> GetDonors()
    {
        return _repo.GetAll();
    }

    public Donor GetDonorById(int id)
    {
        return _repo.GetById(id);
    }
}
