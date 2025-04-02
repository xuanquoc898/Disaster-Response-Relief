using D2R.Models;
using D2R.Services;
using System;
using System.Collections.Generic;

namespace D2R.ViewModels;

public class DonorViewModel
{
    private DonorService _service = new();

    public void AddDonor(string name, string phone)
    {
        var donor = new Donor
        {
            Name = name,
            Phone = phone
        };

        _service.AddDonor(donor);
    }

    public List<Donor> GetAllDonors()
    {
        return _service.GetDonors();
    }

    public Donor GetDonorById(int id)
    {
        return _service.GetDonorById(id);
    }
}
