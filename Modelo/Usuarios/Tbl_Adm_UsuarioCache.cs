using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Usuarios
{
    public static class Tbl_Adm_UsuarioCache
    {
        public static long UsuarioId { get; set; }
        public static string Nombre { get; set; }
        public static string ApellidoP { get; set; }
        public static string ApellidoM { get; set; }
        public static bool Estado { get; set; }
        public static DateTime FechaIngreso { get; set; }
        public static DateTime FechaAltaSys { get; set; }
        public static int RolId { get; set; }
        public static bool EsCambiarPassword { get; set; }
        public static string RecoverPassword { get; set; }
        public static List<Tbl_Adm_Accesos> Accesos { get; set; }
    }
}
