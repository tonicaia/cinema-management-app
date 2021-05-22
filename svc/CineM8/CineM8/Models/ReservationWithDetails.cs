using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineM8.Models
{
    public class ReservationWithDetails
    {
        int reservationId;
        string movieName;
        int hallNumber;
        DateTime startTime;
        DateTime endTime;
        int numberOfSeats;

        public ReservationWithDetails(string movieName, int hallNumber, DateTime startTime, DateTime endTime, int numberOfSeats)
        {
            this.MovieName = movieName;
            this.HallNumber = hallNumber;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.NumberOfSeats = numberOfSeats;
        }

        public string MovieName { get => movieName; set => movieName = value; }
        public int HallNumber { get => hallNumber; set => hallNumber = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public int ReservationId { get => reservationId; set => reservationId = value; }
        public int NumberOfSeats { get => numberOfSeats; set => numberOfSeats = value; }
    }
}