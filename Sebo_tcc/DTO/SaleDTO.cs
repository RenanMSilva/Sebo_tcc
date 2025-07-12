using Microsoft.EntityFrameworkCore;
using Sebo_tcc.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sebo_tcc.DTO
{
    public class SaleDTO
    {

        public int IdBook { get; set; }
        [Required]
        [Display(Name = "Nome do livro obrigatorio")]
        public string BookName { get; set; }

        public DateTime DateSale { get; set; }
        [Precision(16, 2)]
        [Required(ErrorMessage = "O preço da venda é obrigatório.")]
        public decimal SalePrice { get; set; }

    }
}
