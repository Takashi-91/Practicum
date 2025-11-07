using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data.Entities
{
    public class ProcessedOrder
    {
        public long Id { get; set; }
        public string OrderId { get; set; } = "";
        public string Status { get; set; } = "Processed";
        public decimal Amount { get; set; }
        public DateTime ProcessedUtc { get; set; }
    }
}
