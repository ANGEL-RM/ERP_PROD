using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Usuarios
{
    public class Tbl_Adm_Accesos
    {
        [Key]
        public int AccesoId { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public bool Es_Activo { get; set; }
    }
}
