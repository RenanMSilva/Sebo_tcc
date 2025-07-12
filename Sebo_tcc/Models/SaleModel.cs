using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sebo_tcc.Models
{
    public class SaleModel
    {
        public int Id { get; set; }

        public List<SaleItemModel> SaleItems { get; set; } = new List<SaleItemModel>();
        
        [Required]
        [Display(Name = "Data da compra obrigatoria")]
        public DateTime DateSale { get; set; }
        [Precision(16, 2)]
        [Required(ErrorMessage = "O preço da venda é obrigatório.")]
        public decimal SalePrice { get; set; }
    }
}
