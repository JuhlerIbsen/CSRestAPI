namespace MovieAppEntity.Movie
{
    public class Movie
    {

        private static int _id;

        public Movie()
        {
            // TODO: Find a work around.
            // Entity frameworks initialize a new Movie on every operation.
            // So each time I read/update/delete this will count 1 up 
            // for each of the Movies inside the list.
            _id++;
            Id = _id;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public long Duration { get; set; }
    }
}