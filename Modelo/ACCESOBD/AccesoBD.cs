﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Modelo.Usuarios;

namespace Modelo.ACCESOBD
{
    public class AccesoBD: DbContext
    {
        public AccesoBD() : base(ConfigurationManager.ConnectionStrings["cadena_conexion_Somee"].ToString())
        {
            if (!Database.Exists(ConfigurationManager.ConnectionStrings["cadena_conexion_Somee"].ToString()))
            {
                Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " Inicialización de BD");
                Database.SetInitializer(new DropCreateDatabaseAlways<AccesoBD>());
            }
        }

        public virtual DbSet<Tbl_Adm_Usuarios> Tbl_Adm_Usuarios { get; set; }
        public virtual DbSet<Tbl_Adm_Accesos> Tbl_Adm_Accesos { get; set; }
        public virtual DbSet<Tbl_Adm_Rol_Acceso> Tbl_Adm_Rol_Acceso { get; set; }
    }
}
