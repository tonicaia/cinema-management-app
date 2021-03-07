using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineM8.Models
{
    public class CinemaHall
    {
        private int id;
        private int capacity;

        public CinemaHall()
        {
        }

        public CinemaHall(int capacity)
        {
            this.capacity = capacity;
        }

        public int Id { get => id; set => id = value; }
        public int Capacity { get => capacity; set => capacity = value; }
    }
}