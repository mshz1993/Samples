using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DigitalMarketDBContext : DbContext
    {
        public DigitalMarketDBContext(DbContextOptions<DigitalMarketDBContext> options) : base(options)
        {

        }
        public DbSet<HeaderMenu> HeaderMenus { set; get; }
        public DbSet<CallUs> CallUs { set; get; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }


}
