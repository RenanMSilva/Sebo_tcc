using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sebo_tcc.Models
{
    public class LoanModel
    {
        public int Id { get; set; }

        // Chave estrangeira para Cliente
        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }
        public CustomerModel Customer { get; set; } = null!;

        // Chave estrangeira para Livro
        [ForeignKey("Book")]
        public int IdBook { get; set; }
        public BookModel Book { get; set; } = null!;

        [Required]
        [Display(Name = "Data do Empréstimo")]
        public DateTime DateLoan { get; set; }

        [Required]
        [Display(Name = "Data da Devolução")]
        public DateTime DateReturn { get; set; }

        [Required]
        [Display(Name = "Valor")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValueRequest { get; set; }
    }
}
