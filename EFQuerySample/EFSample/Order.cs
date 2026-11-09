using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
    {
    public class Order
        {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        }
    }
