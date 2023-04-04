using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.ACCESOBD
{
    public class AccesoBD2 : DbContext //, IApplicationDbContext, IAccesoBD
    {

        public AccesoBD2()
        {
        }
        /*
        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["conexionBD_Somee"].ConnectionString);



        public DbSet<Tbl_Adm_Usuario> Tbl_Adm_Usuario { get; set; }

        /*
        public AccesoBD(DbContextOptions<AccesoBD> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    System.Configuration.ConfigurationManager.ConnectionStrings["conexionBD_Somee"].ConnectionString)
                    .EnableSensitiveDataLogging(true);
            }
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder) {
            throw new UnintentionalCodeFirstException();
        }*/
        /*
       



        /*



        

        public DbSet<Tbl_Adm_Usuario> Tbl_Adm_Usuario { get; set; }
        public IDbConnection Connection => Database.GetDbConnection();
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    System.Configuration.ConfigurationManager.ConnectionStrings["conexionBD_Somee"].ConnectionString)
                    .EnableSensitiveDataLogging(true);
            }
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("").EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory().AddConsole());
        }
        /*
        public AccesoBD(DbContextOptions<AccesoBD> options) : base(options){}

        public AccesoBD()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //var configuracion = config.Build();
            //var valor = configuracion.GetValue<string>("Connection");
            //options.UseSqlServer(valor);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public virtual DbSet<Tbl_Adm_Usuario> Tbl_Adm_Usuarios { get; set; }
    */
    }
}
