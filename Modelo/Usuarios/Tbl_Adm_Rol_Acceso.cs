using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Usuarios
{
    public class Tbl_Adm_Rol_Acceso
    {
        [Key]
        public int RolId { get; set; }
        public int AccesoId { get; set; }
    }
}
