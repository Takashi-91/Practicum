using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceClassLibrary
{
    
    public class Order
    {
        [Key]
        public string OrderId { get; set; }
        [Required, MaxLength(64)]
        public string CustomerId { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal Amount {  get; set; }
        [Required, MaxLength(8)]
        public string Currency { set; get; } = "ZAR";
        [Required, MinLength (32)]
        public string Status { set; get; } = "Pending";
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
