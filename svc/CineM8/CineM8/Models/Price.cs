using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineM8.Models
{

    public class Price
    {
        private int id;
        private double priceAmount;
        private string description;
        private int weekend;

        public int Id { get => id; set => id = value; }
        public double PriceAmount { get => priceAmount; set => priceAmount = value; }
        public string Description { get => description; set => description = value; }
        public int Weekend { get => weekend; set => weekend = value; }
    }
}