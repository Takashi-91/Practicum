using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data.Entities
{
    public class OrderEvent
    {
        public long Id { get; set; }
        public string OrderId { get; set; } = "";
        public string UserId { get; set; } = "";
        public decimal Amount { get; set; }
        public DateTime OccurredUtc { get; set; }
    }
}
