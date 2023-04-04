using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DaoAdminUsuario
    {
        private AdminUsuarioController controllerAdminUsuario = new AdminUsuarioController();
        public Respuesta<int> ValidarLogin(String Nombre, String Password)
        {
            return controllerAdminUsuario.ValidarUsuarioLogin(Nombre, Password);
        }

    }
}
