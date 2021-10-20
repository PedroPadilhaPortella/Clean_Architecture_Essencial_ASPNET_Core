using CleanArchMVC.Application.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace CleanArchMVC.Infra.Data.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-2FBKQ8U\\SQLEXPRESS;Initial Catalog=CleanArchDB1;Integrated Security=True");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
