using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private String Solicitud()
        {
            return "";

        }

        private Task<Respuesta<int>> ValidarLogin()
        {
            return new DaoAdminUsuario().ValidarLogin(textBox1.Text, textBox2.Text);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Task<Respuesta<int>> task = await new Task<Task<Respuesta<int>>>(ValidarLogin);
            task.Start();
            var respuestavalidacion = await task;
            if (respuestavalidacion.Estado == EstadosDeRespuesta.Correcto)
            {
                if (!respuestavalidacion.Datos.Equals(2))
                {
                    MessageBox.Show("No valido");
                }
                else{
                    MessageBox.Show("exitoso");
                }
            }
            //string passWord = Encrypt.GetSHA256(textBox2.Text.Trim());
        }
    }
}
