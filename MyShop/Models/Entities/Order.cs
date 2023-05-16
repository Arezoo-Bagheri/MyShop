using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public bool IsFinaly { get; set; }


        [ForeignKey("UserId")]
        public Users Users { get; set; }

        public List<OrderDetails> orderDetails { get; set; }
    }
}
