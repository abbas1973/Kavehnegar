using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Linq;
using System.Reflection;
using Utilities;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Fluent API - لود کردن از کلاس های جانبی
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion


            #region DeleteBehavior - رفتار در هنگام حذف دیتا
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            #endregion

        }




        #region جداول دیتابیسی
        public DbSet<MyEntity> MyEntities { get; set; }
        #endregion




    }
}
