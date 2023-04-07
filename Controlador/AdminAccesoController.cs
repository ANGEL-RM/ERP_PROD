using Modelo;
using Modelo.ACCESOBD;
using Modelo.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class AdminAccesoController
    {
        private AccesoBD db = new AccesoBD();
        public bool ValidarAcceso(String nameForm)
        {
            bool response = false;
            Tbl_Adm_Accesos AccesoForm = db.Tbl_Adm_Accesos.Where(U => U.Descripcion.Contains(nameForm)).FirstOrDefault();
            if (AccesoForm != null)
            {
                Tbl_Adm_Rol_Acceso Acceso = db.Tbl_Adm_Rol_Acceso.FirstOrDefault(ra => ra.RolId == Tbl_Adm_UsuarioCache.RolId && ra.AccesoId == AccesoForm.AccesoId);
                if (Acceso != null)
                {
                    response = true;
                }
            }
            return response;
        }
    }
}
