using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.ACCESOBD;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Modelo.Usuarios;
using System.Security.Cryptography;

namespace Controlador
{
    public class AdminUsuarioController
    {

        private AccesoBD db = new AccesoBD();

        private LogRegister EscribirLog = new LogRegister();
        /*public List<Tbl_Adm_Usuario> ObtenerUsuarios()
        {
                List<Tbl_Adm_Usuario> Usuarios = new List<Tbl_Adm_Usuario>();
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadena_conexion))
            {
                try
                {
                    string query = "select  * from Tbl_Adm_Usuario";
                    SqlCommand sqlCommand = new SqlCommand(query, conn);
                    sqlCommand.CommandType = CommandType.Text;
                    conn.Open();

                    using (SqlDataReader dr = sqlCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Usuarios.Add(new Tbl_Adm_Usuario()
                            {
                                UsuarioId = (int)dr["UsuarioId"],
                                Password = (string)dr["Password"],
                                Nombre = (string)dr["Nombre"],
                                ApellidoP = (string)dr["ApellidoP"],
                                ApellidoM = (string)dr["ApellidoM"],
                                Estado = (bool)dr["Estado"],
                                FechaIngreso = (DateTime)dr["FechaIngreso"],
                                FechaAltaSys = (DateTime)dr["FechaAltaSys"],
                                RolId = (int)dr["RolId"],
                                EsCambiarPassword = (bool)dr["EsCambiarPassword"],
                                RecoverPassword = (string)dr["RecoverPassword"]
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Usuarios = new List<Tbl_Adm_Usuario>();
                    throw ex;
                }
            }
            return Usuarios;
        }*/



        public Respuesta<int> ValidarUsuarioLogin(String Nombre, String Password)
        {            
            var respuesta = new Respuesta<int> { Estado = EstadosDeRespuesta.Correcto };
                try
                {
                Tbl_Adm_Usuarios usuario = db.Tbl_Adm_Usuarios.FirstOrDefault(U => U.Nombre.Equals(Nombre) && U.Password.Equals(Password));
                if (usuario != null)
                {
                    Tbl_Adm_UsuarioCache.UsuarioId = usuario.UsuarioId;
                    Tbl_Adm_UsuarioCache.Nombre = usuario.Nombre;
                    Tbl_Adm_UsuarioCache.ApellidoM = usuario.ApellidoM;
                    Tbl_Adm_UsuarioCache.ApellidoP = usuario.ApellidoP;
                    Tbl_Adm_UsuarioCache.Estado = usuario.Estado;
                    Tbl_Adm_UsuarioCache.FechaIngreso = usuario.FechaIngreso;
                    Tbl_Adm_UsuarioCache.FechaAltaSys = usuario.FechaAltaSys;
                    Tbl_Adm_UsuarioCache.RolId = usuario.RolId;
                    Tbl_Adm_UsuarioCache.EsCambiarPassword = usuario.EsCambiarPassword;
                    Tbl_Adm_UsuarioCache.RecoverPassword = usuario.RecoverPassword;
                    Tbl_Adm_UsuarioCache.Accesos = (from rolAcceso in db.Tbl_Adm_Rol_Acceso
                                         join acc in db.Tbl_Adm_Accesos on rolAcceso.AccesoId equals acc.AccesoId
                                         where rolAcceso.RolId == usuario.RolId
                                         select acc).ToList();

                }
                else
                {                     
                        respuesta.Estado = EstadosDeRespuesta.NoProceso;
                        respuesta.Mensaje = "Usuario o Contraseña Incorrecto";
                    }
                }
                catch (Exception ex)
                {
                    StackFrame stackFrame = new StackFrame(0);
                    respuesta.Estado = EstadosDeRespuesta.Error;
                    respuesta.Mensaje = ex.Message.ToString();
                    EscribirLog.LogWriteProcesosError(typeof(AdminUsuarioController).Name, stackFrame.GetMethod().Name, ex.Message.ToString());
            }
            return respuesta;
        }
    }
}
