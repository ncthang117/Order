using System.ComponentModel.DataAnnotations;

namespace ApiOrder.Models
{
    public class Order
    {
        public Guid ID { get; set; }
        public int UserID { get; set; }
        public int  ProductID { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; } 
        public string Date { get; set; }
        public string Total { get; set; }
        public string Status { get; set; }
    }
}
