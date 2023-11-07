using Makarov_Mikhail_Kt_31_20_Lab1.Database.Configurations;
using Makarov_Mikhail_Kt_31_20_Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Makarov_Mikhail_Kt_31_20_Lab1.Database
{
    public class MakarovDbContext: DbContext 

    {
        internal DbSet<Student> Students { get; set; }
        internal DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }
        public MakarovDbContext(DbContextOptions<MakarovDbContext> options) : base(options) { }
    }
}
