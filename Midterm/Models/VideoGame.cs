using System.ComponentModel.DataAnnotations;

namespace Midterm.Models
{
    public class VideoGame
    {
        public int Id { get; set; }

        
        //[Required]
        public string Title { get; set; }
        public string Publisher { get; set; }

        
        //[Required]
        //[StringLength(30)]
        public string Genre { get; set; }

        //[Range(1, 100)]
        //[DataType(DataType.Currency)]
        public decimal MSRP { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Summary { get; set; }

        
        //[Required]
        public double? Rating { get; set; }
    }
}
