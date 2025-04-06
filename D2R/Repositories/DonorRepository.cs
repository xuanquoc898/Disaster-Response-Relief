using D2R.Models;
using D2R.Helpers;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace D2R.Repositories;

public class DonorRepository
{
    public void Add(Donor donor)
    {
        DBHelper.ExecuteNonQuery(
            "INSERT INTO Donors (Name, Phone) VALUES (@Name, @Phone)",
            new MySqlParameter("@Name", donor.Name),
            new MySqlParameter("@Phone", donor.Phone)
        );
    }

    public List<Donor> GetAll()
    {
        var donors = new List<Donor>();
        using var reader = DBHelper.ExecuteReader("SELECT Id, Name, Phone FROM Donors");

        while (reader.Read())
        {
            donors.Add(new Donor
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Phone = reader["Phone"].ToString()
            });
        }

        return donors;
    }

    public Donor GetById(int id)
    {
        using var reader = DBHelper.ExecuteReader(
            "SELECT Id, Name, Phone FROM Donors WHERE Id = @Id",
            new MySqlParameter("@Id", id)
        );

        if (reader.Read())
        {
            return new Donor
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Phone = reader["Phone"].ToString()
            };
        }

        return null;
    }
}
