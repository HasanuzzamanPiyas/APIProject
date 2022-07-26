
using APIProject.Data.Entitties;
using APIProject.Model;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Data
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options):base(options)
        {
        }

        public DbSet<ListModel> ListModels { set; get; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // optionsBuilder.UseSqlServer("Server =.;Databse=PracticeApi; User ID=sa;Password=Foyaz123;providerName = System.Data.SqlClient");
        //    optionsBuilder.UseSqlServer("Server =.;Databse=PracticeApi;Integrated Security= True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
