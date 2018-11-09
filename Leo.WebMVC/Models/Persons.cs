using System.Data.Entity;
using System.Data.SqlClient;

namespace Leo.WebMVC.Models
{
    public class LeoDbContext : DbContext
    {
        public LeoDbContext():base()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost\\SQLEXPRESS";
            builder.InitialCatalog = "ECDocking";
            builder.IntegratedSecurity = true;
            this.Database.Connection.ConnectionString = builder.ConnectionString;
            this.Configuration.LazyLoadingEnabled = true;
        }

        public LeoDbContext(string connectionString):base(connectionString)
        {
        }

        public DbSet<Persons> Persons { get; set; }
    }
    public class Persons
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
    }
}