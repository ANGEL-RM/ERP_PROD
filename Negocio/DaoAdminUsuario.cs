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
            Tbl_Adm_Usuario usuario = new Tbl_Adm_Usuario();
            usuario.Nombre = Nombre;
            usuario.Password = Password;
            return controllerAdminUsuario.ValidarUsuarioLogin(usuario);
        }

    }
}
