namespace CineM8.Models
{
    public class CinemaHall
    {
        private int id;
        private int capacity;

        public CinemaHall(int capacity)
        {
            this.capacity = capacity;
        }

        public int Id { get => id; set => id = value; }
        public int Capacity { get => capacity; set => capacity = value; }
    }
}