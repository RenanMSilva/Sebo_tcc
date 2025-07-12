using System.ComponentModel.DataAnnotations.Schema;

namespace Sebo_tcc.Models
{
    [Table("Order_Sales")]
    public class SaleItemModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public BookModel Item { get; set; } = new BookModel();
    }
}