﻿using D2R.Models;
using D2R.Services;
using System.Globalization;
namespace D2R.ViewModels
{
    public class AddDonorViewModel
    {
        private DonorService _service = new();
        private List<Donor> _donors = new();

        public bool AddDonorSuccess { get; set; }

        public void AddDonor(string name, string cccd, string phone, string email)
        {
            TextInfo textInfo = new CultureInfo("vi-VN", false).TextInfo;
            name = textInfo.ToTitleCase(name.ToLower()); // chuyen doi chuoi vua hoa vua thuong ve dinh dang Họ Và Tên
            var donor = new Donor
            {
                FullName = name,
                Cccd = cccd,
                Phone = phone,
                Email = email
            };
            _service.Add(donor);
            AddDonorSuccess = _service.AddDonorSuccess;
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
                if (donor.FullName.ToLower().Contains(name.ToLower()))
                {
                    donorsTmp.Add(donor);
                }
            }
            return donorsTmp;
        }

    }
}
