using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineM8.Models
{
    public class Movie
    {
        private int id;
        private string name;
        private string description;
        private float length;
        private bool isRunning;

        public Movie()
        {
            this.name = "Shrek";
            this.description = "ok";
        }
        //TODO : more fields such as length, actor, rating... construtors, getters and setters


    }
}