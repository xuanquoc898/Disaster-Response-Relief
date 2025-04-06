using D2R.Models;
using D2R.Helpers;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace D2R.Repositories;

public class ItemRepository
{
    public void Add(Item item)
    {
        DBHelper.ExecuteNonQuery(
            "INSERT INTO Items (DonorId, ItemName, Quantity, DateReceived) VALUES (@DonorId, @ItemName, @Quantity, @DateReceived)",
            new MySqlParameter("@DonorId", item.DonorId),
            new MySqlParameter("@ItemName", item.ItemName),
            new MySqlParameter("@Quantity", item.Quantity),
            new MySqlParameter("@DateReceived", item.DateReceived)
        );
    }

    public List<Item> GetItemsByDonor(int donorId)
    {
        var items = new List<Item>();
        using var reader = DBHelper.ExecuteReader(
            "SELECT Id, DonorId, ItemName, Quantity, DateReceived FROM Items WHERE DonorId = @DonorId",
            new MySqlParameter("@DonorId", donorId)
        );

        while (reader.Read())
        {
            items.Add(new Item
            {
                Id = (int)reader["Id"],
                DonorId = (int)reader["DonorId"],
                ItemName = reader["ItemName"].ToString(),
                Quantity = (int)reader["Quantity"],
                DateReceived = (DateTime)reader["DateReceived"]
            });
        }

        return items;
    }
}
