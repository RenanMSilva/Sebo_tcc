using Microsoft.EntityFrameworkCore;
using Sebo_tcc.Models;

namespace Sebo_tcc.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {


        }

        public DbSet<BookModel> Books { get; set; }

        public DbSet<CustomerModel> Customers { get; set; }

        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<LoanModel> Loans { get; set; }

        
    }
}
