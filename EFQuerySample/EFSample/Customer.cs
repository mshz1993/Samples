using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
    {
    public class Customer
        {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
            = new List<Order>();
        }

    }
