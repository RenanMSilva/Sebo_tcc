using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Sebo_tcc.DTO
{
    public class BookDTO
    {
        [Required(ErrorMessage = "O título do livro é obrigatorio.")]

        public string Title { get; set; } = "";
        public string? Description { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "O autor do livro é obrigatorio.")]
        public string Author { get; set; } = "";
        [Required(ErrorMessage = "O preço do livro é obrigatorio.")]
        [Precision(16, 2)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "O ano de publicação do livro é obrigatorio.")]
        public string YearPublication { get; set; } = "";
        public IFormFile? ImageBook { get; set; }
        [Required(ErrorMessage = "O genero literario do livro é obrigatorio.")]
        public string LiteraryGenre { get; set; } = "";
        public int Quantity { get; set; } = 1;
    }
}
