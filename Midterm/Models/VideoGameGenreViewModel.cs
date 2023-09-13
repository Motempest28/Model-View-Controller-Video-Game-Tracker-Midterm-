using Microsoft.AspNetCore.Mvc.Rendering;

namespace Midterm.Models
{
    public class VideoGameGenreViewModel
    {
        public List<VideoGame>? VideoGames { get; set; }
        public SelectList? Genres { get; set; }
        public string? VideoGameGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
