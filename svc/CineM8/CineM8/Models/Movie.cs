namespace CineM8.Models
{
    public class Movie
    {
        private int id;
        private string name;
        private string description;
        private float length;
        private bool isRunning;
        private string imageURL;
        private string videoURL;

    public Movie(string name, string description, float length, bool isRunning, string imageURL, string videoURL)
        {
            this.name = name;
            this.description = description;
            this.length = length;
            this.isRunning = isRunning;
            this.imageURL = imageURL;
            this.videoURL = videoURL;

        }
    
        //TODO : more fields such as length, actor, rating... construtors, getters and setters
        // DONE : constructors, getters and setters
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }
        public float Length
        {
            get => length;
            set => length = value;
        }
        public bool IsRunning
        {
            get => isRunning;
            set => isRunning = value;
        }

        public string ImageURL
        {
            get => imageURL;
            set => imageURL = value;
        }

        public string VideoURL
        {
            get => videoURL;
            set => videoURL = value;
        }
    }
}
