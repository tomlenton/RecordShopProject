using Microsoft.EntityFrameworkCore;
using RecordShopProject.DataModels;

namespace RecordShopProject.DBContext
{
   public class RecordShopContext : DbContext
   {
        public DbSet<Album> Albums { get; set; }
        public RecordShopContext(DbContextOptions<RecordShopContext> options) : base(options) {}
   }
}
