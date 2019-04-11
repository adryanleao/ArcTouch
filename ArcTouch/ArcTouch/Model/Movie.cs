using System;
using System.Collections.Generic;
using System.Text;

namespace ArcTouch.Model
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public string poster_path { get; set; }
        public ICollection<int> genre_ids { get; set; }
        public string release_date { get; set; }
        public string genres { get; set; }
    }
}
