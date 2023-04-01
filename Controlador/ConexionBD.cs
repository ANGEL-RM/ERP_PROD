using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ConexionBD
    {
        public static string cadena_conexion = ConfigurationManager.ConnectionStrings["cadena_conexion_Somee"].ToString();
    }
}
