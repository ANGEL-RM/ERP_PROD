using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class LogRegister
    {
        public void LogWriteProcesosExitosos(String clase, String metodo)
        {
            try
            {
                String ruta = Path.Combine(@AppDomain.CurrentDomain.BaseDirectory, "RegisterLogs\\");
                CreateIfMissing(ruta);
                FileStream fs = new FileStream(ruta +
                    "LogExitosos.log", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " Clase: " + clase + " Metodo: "+metodo);
                m_streamWriter.Flush();
                m_streamWriter.Close();
            }
            catch
            {
                //Silenciosa
            }
        }

        public void LogWriteProcesosError(String clase, String metodo, String MessageError)
        {
            try
            {

                String ruta = Path.Combine(@AppDomain.CurrentDomain.BaseDirectory, "RegisterLogs\\");
                CreateIfMissing(ruta);
                FileStream fs = new FileStream(ruta +
                    "LogError.log", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " Clase: " + clase + " Metodo: " + metodo+ " Detalle: "+ MessageError);
                m_streamWriter.Flush();
                m_streamWriter.Close();
            }
            catch
            {
                //Silenciosa
            }
        }

        public void LogWriteProcesos(String clase, String metodo)
        {
            try
            {
                String ruta = Path.Combine(@AppDomain.CurrentDomain.BaseDirectory, "RegisterLogs\\");
                CreateIfMissing(ruta);
                FileStream fs = new FileStream(ruta +
                    "Log.log", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " Clase: " + clase + " Metodo: " + metodo);
                m_streamWriter.Flush();
                m_streamWriter.Close();
            }
            catch
            {
                //Silenciosa
            }
        }

        private void CreateIfMissing(string path) {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

    }
}