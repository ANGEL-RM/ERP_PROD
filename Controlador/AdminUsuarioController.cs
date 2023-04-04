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



namespace Controlador
{
    public class AdminUsuarioController
    {

        private AccesoBD db = new AccesoBD();
        public List<Tbl_Adm_Usuario> ObtenerUsuarios()
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
        }



        public Respuesta<int> ValidarUsuarioLogin(String Nombre, String Password)
        {
                var respuesta = new Respuesta<int> { Estado = EstadosDeRespuesta.Correcto };
                try
                {   
                    Tbl_Adm_Usuario usuarios = db.Tbl_Adm_Usuarios.FirstOrDefault(U => U.Nombre.Equals(Nombre) && U.Password.Equals(Password));
                    if (usuarios == null)
                    {
                        respuesta.Estado = EstadosDeRespuesta.NoProceso;
                        respuesta.Mensaje = "Usuario o Contraseña Incorrecto";
                    }
                }
                catch (Exception ex)
                {
                    respuesta.Estado = EstadosDeRespuesta.Error;
                    respuesta.Mensaje = ex.Message.ToString();
                }
            return respuesta;
        }
    }
}
