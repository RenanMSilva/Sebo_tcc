using Microsoft.AspNetCore.Mvc.Rendering;
using Sebo_tcc.DTO;

namespace Sebo_tcc.FormViewModel
{
    public class LoanFormViewModel
    {
        public LoanDTO Loan { get; set; } = new LoanDTO();

        public List<SelectListItem> Customers { get; set; } = new();
        public List<SelectListItem> Books { get; set; } = new();
    }
}
