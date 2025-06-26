using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Sebo_tcc.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        [MaxLength(100)]
        public string Author { get; set; } = "";
        [Precision(16,2)]
        public decimal Price { get; set; }
        public string YearPublication { get; set; } = "";
        public string ImageBook { get; set; } = "";
        public string LiteraryGenre { get; set; } = "";

    }
}
