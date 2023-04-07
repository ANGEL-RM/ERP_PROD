using Controlador;
using Modelo.Usuarios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DaoFormPrincipal
    {
        public bool ValidarAcceso(String nameForm)
        {
            
            bool response = false;
            foreach (var acccesos in Tbl_Adm_UsuarioCache.Accesos)
            {
                if (acccesos.Descripcion.Contains(nameForm))
                {
                    response = true;
                }
            }
            return response;
        }
    }
}
