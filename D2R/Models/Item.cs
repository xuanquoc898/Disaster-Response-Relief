using System;

namespace D2R.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
