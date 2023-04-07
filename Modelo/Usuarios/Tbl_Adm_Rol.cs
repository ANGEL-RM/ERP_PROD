using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Usuarios
{
    public class Tbl_Adm_Rol
    {
        [Key]
        [Required(ErrorMessage = "el perfil es requerido")]
        public int RolId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public byte Es_Activo { get; set; }
    }
}
