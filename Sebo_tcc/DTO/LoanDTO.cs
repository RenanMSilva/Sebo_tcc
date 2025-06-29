using System.ComponentModel.DataAnnotations;

namespace Sebo_tcc.DTO
{
    public class LoanDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Selecione o cliente")]
        public string NameCustomer { get; set; }

        [Required(ErrorMessage = "Selecione o livro")]
        public string TittleBook { get; set; } = "";

        [Required(ErrorMessage = "Informe a data do empréstimo")]
        [DataType(DataType.Date)]
        public DateTime DateLoan { get; set; }

        [Required(ErrorMessage = "Informe a data de devolução")]
        [DataType(DataType.Date)]
        public DateTime DateReturn { get; set; }

        [Required(ErrorMessage = "Informe o valor do empréstimo")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor deve ser maior ou igual a zero")]
        public decimal ValueRequest { get; set; }
    }
}
