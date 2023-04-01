using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Tbl_Adm_Usuario
    {
        public int UsuarioId { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaAltaSys { get; set; }
        public int RolId { get; set; }
        public bool EsCambiarPassword { get; set; }
        public string RecoverPassword { get; set; }
    }
}