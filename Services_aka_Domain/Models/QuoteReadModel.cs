using System.Collections.Generic;

namespace Services_aka_Domain.Models
{
    public class QuoteReadModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int FavoritesCount { get; set; }
        public int UpvotesCount { get; set; }
        public int DownvotesCount { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public List<string> Tags { get; set; }
    }
}
