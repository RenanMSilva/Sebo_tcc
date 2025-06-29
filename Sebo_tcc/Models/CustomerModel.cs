using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Sebo_tcc.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter exatamente 11 dígitos.")]
        public string CPFCustomer { get; set; } = "";

        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        public string NumberCustomer { get; set; } = "";

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime BirthDate { get; set; }

    }
}
