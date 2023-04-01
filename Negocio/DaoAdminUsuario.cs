using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DaoAdminUsuario
    {
        public class Ejecucion_Adm_Usuario
        {
            private AdminUsuarioController controllerAdminUsuario = new AdminUsuarioController();
            public List<Tbl_Adm_Usuario> ObtenerUsuarios() => controllerAdminUsuario.ObtenerUsuarios();
        }
    }
}
