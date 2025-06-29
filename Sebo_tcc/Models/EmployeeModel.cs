using System.ComponentModel.DataAnnotations;

namespace Sebo_tcc.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do Funcionário")]
        public string NameEmployee { get; set; } = "";

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter exatamente 11 dígitos.")]
        public string CPFEmployee { get; set; } = "";

        [Required]
        [Display(Name = "Data de Admissão")]
        [DataType(DataType.Date)]
        public DateTime DataHiring { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string EmailEmployee { get; set; } = "";
    }
}
