using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ACCESOBD
{
    public class AccesoBD: DbContext
    {
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
    
    }
}
