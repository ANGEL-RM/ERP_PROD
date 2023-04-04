using Modelo;
using System.Data.Entity;

namespace Controlador.BDACCESS
{
    public class AccesoBD : DbContext
    {
        public AccesoBD() : base(System.Configuration.ConfigurationManager.ConnectionStrings["conexionBD_Somee"].ConnectionString)
        {
            if (!Database.Exists(System.Configuration.ConfigurationManager.ConnectionStrings["conexionBD_Somee"].ConnectionString))
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<AccesoBD>());
            }
        }
        public DbSet<Tbl_Adm_Usuario> Tbl_Adm_Usuario { get; set; }
    }
}
