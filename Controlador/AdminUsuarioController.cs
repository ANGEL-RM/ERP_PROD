using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class AdminUsuarioController
    {
        public async Task<List<Tbl_Adm_Usuario>> ObtenerUsuarios()
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
                }
            }
            return Usuarios;
        }



        public Respuesta<int> ValidarUsuarioLogin(Tbl_Adm_Usuario usuario)
        {
            var respuesta = new Respuesta<int> { Estado = EstadosDeRespuesta.Correcto };

            List<Tbl_Adm_Usuario> Usuarios = new List<Tbl_Adm_Usuario>();
            using (SqlConnection conn = new SqlConnection(ConexionBD.cadena_conexion))
            {
                try
                {
                    string query = "select * from Tbl_Adm_Usuario where Nombre= '" + usuario.Nombre + "' and Password= '" + usuario.Password + "'";
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

                    if (Usuarios.Count != 0)
                    {
                            if (Usuarios.First().Password != null)
                            {
                                if (Usuarios.First().Password != usuario.Password)
                                {
                                    respuesta.Estado = EstadosDeRespuesta.NoProceso;
                                    respuesta.Mensaje = "Contraseña Incorrecta";
                                }
                                else
                                {
                                    respuesta.Datos = 2;
                                }
                            }
                            else
                            {
                                respuesta.Estado = EstadosDeRespuesta.NoProceso;
                                respuesta.Mensaje = "Ingresa Contraseña";
                            }
                        
                    }
                    else
                    {
                        respuesta.Datos = 1;
                    }

                }
                catch (Exception ex)
                {
                    respuesta.Estado = EstadosDeRespuesta.Error;
                    respuesta.Mensaje = $"ocurrio un error al obtener los usuarios: {ex.Message}";
                }
            }
            return respuesta;
        }
    }
}
