using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Respuesta<T>
    {
        public EstadosDeRespuesta Estado { get; set; }

        public string Mensaje { get; set; }

        public T Datos { get; set; }
    }
}
