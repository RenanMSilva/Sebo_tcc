using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Sebo_tcc.DTO
{
    public class BookDTO
    {
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        [MaxLength(100)]
        public string Author { get; set; } = "";
        [Precision(16, 2)]
        public decimal Price { get; set; }
        public string YearPublication { get; set; } = "";
        public IFormFile? ImageBook { get; set; }
        public string LiteraryGenre { get; set; } = "";
        public int Quantity { get; set; } = 1;
    }
}
