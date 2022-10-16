using EF_Project.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Project.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            Configuration = configuration;
        }

        //NEW
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        #region Old

        //OLD
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //// Get the connection string from configuration 
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=FirstDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
        //}
        
        #endregion

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
