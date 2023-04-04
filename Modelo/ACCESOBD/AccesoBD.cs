using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ACCESOBD
{
    public class AccesoBD: DbContext
    {
        public AccesoBD() : base("workstation id=PRODERP.mssql.somee.com;packet size=4096;user id=ARM;pwd=12345678;data source=PRODERP.mssql.somee.com;persist security info=False;initial catalog=PRODERP")
        {
            if (!Database.Exists("workstation id=PRODERP.mssql.somee.com;packet size=4096;user id=ARM;pwd=12345678;data source=PRODERP.mssql.somee.com;persist security info=False;initial catalog=PRODERP"))
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<AccesoBD>());
            }
        }

        public virtual DbSet<Tbl_Adm_Usuario> Tbl_Adm_Usuarios { get; set; }
    
    }
}
