using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceClassLibrary
{
    
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public Guid EventId { get; set; }
        [Required, MaxLength(64)]
        public string EventType { get; set; } = "";
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Payload { get; set; } = "";
        [Required]
        public DateTime Occurred { get; set; }
        [Required]
        public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;
        [MaxLength(64)]
        public string? SessionId {  get; set; }
        [MaxLength(64)]
        public string? CustomerId {  get; set; }
    }
}
