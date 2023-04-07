using Modelo;
using Modelo.Usuarios;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();            
        }
        private bool ValidaAcceso()
        {
            return new DaoFormPrincipal().ValidarAcceso(this.GetType().Name);
        }
        private void Principal_Load(object sender, EventArgs e) {
            if (!ValidaAcceso())
            {
                Login FormLogin = new Login();
                this.Close();
                FormLogin.Show();
            }
        }
    }
}
