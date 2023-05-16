using System.ComponentModel.DataAnnotations;

namespace MyShop.Models.Entities
{
    public class OrderDetails
    {
        [Key]
        public int DetailId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Count { get; set; }


        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
