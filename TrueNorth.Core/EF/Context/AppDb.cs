using Microsoft.EntityFrameworkCore;
using TrueNorth.Core.EF.Mappers;
using Microsoft.Extensions.Configuration;
using TrueNorth.Core.Tasks;

namespace TrueNorth.Core.EF.Context
{
    public class AppDb : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
         

        public IConfiguration _config;
        public AppDb()
        {

        }
        public AppDb(IConfiguration configuration)
        {
            _config = configuration; 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseInMemoryDatabase(databaseName: "Test");

            //var db = "Server=(localdb)\\mssqllocaldb;Database=MyWMS;Trusted_Connection=True;MultipleActiveResultSets=true";

            //if (_config !=  null)
            //     db = _config["ConnectionString:DataBase"];

            //optionsBuilder.UseSqlServer(db);
            optionsBuilder.ConfigureWarnings(x => x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.InMemoryEventId.TransactionIgnoredWarning));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            TaskItemMapper.Setup(builder); 
        }
    }
}