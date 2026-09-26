using EfSample.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuerySample_UI
{
    public class CourseeStoreDBContextFactory : IDesignTimeDbContextFactory<CourseeStoreDBContext>
    {
        public CourseeStoreDBContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<CourseeStoreDBContext>();
            optionBuilder.UseSqlServer("Server=.;Database=CourseeDb;Integrated Security=True;TrustServerCertificate=true;");
            optionBuilder.UseLazyLoadingProxies();

            CourseeStoreDBContext ctx = new CourseeStoreDBContext(optionBuilder.Options);
            return ctx;
        }
    }
}
