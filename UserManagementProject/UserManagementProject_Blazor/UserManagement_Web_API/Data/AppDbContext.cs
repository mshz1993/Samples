using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserManagement_Web_API.Entities;

namespace UserManagement_Web_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
