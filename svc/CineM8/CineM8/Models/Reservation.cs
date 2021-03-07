using System;

namespace CineM8.Models
{
    public class Reservation
    {
        private int id;
        private int userId;
        private int movieId;
        private int cinemaHallId;
        private int numberOfSeats;
        private DateTime startTime;
        private DateTime endTime;

        //TODO constructors, getters and setters
        // DONE : constructors, getters and setters

        public Reservation(int userId, int movieId, int cinemaHallId, int numberOfSeats, DateTime startTime, DateTime endTime)
        {
            this.userId = userId;
            this.cinemaHallId = cinemaHallId;
            this.numberOfSeats = numberOfSeats;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int UserId
        {
            get => userId;
            set => userId = value;
        }
        
        public int MovieId
        {
            get => movieId;
            set => movieId = value;
        }

        public int CinemaHallId
        {
            get => cinemaHallId;
            set => cinemaHallId = value;
        }

        public int NumberOfSeats
        {
            get => numberOfSeats;
            set => numberOfSeats = value;
        }

        public DateTime StartTime
        {
            get => startTime;
            set => startTime = value;
        }

        public DateTime EndTime
        {
            get => endTime;
            set => endTime = value;
        }

    }
}