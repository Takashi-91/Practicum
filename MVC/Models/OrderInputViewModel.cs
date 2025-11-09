using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class OrderInputViewModel
    {

        [Required] public string OrderId { get; set; } = "";
        [Required] public string UserId { get; set; } = "";
        [Range(0.01, 1_000_000)] public decimal Amount { get; set; }
    }
}
