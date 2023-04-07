
using log4net.Core;
using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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

        private Respuesta<int> ValidarLogin()
        {
            return new DaoAdminUsuario().ValidarLogin(textBox1.Text, textBox2.Text);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && textBox1.Text != null && !textBox2.Text.Equals("") && textBox2.Text != null)
            {
                messageInfo.Text = "";
                Task<Respuesta<int>> taskValidarLogin = new Task<Respuesta<int>>(ValidarLogin);
                taskValidarLogin.Start();
                Respuesta<int> respuestavalidacion = await taskValidarLogin;
                if (respuestavalidacion.Estado == EstadosDeRespuesta.Correcto)
                {
                    Principal FormPrincipal = new Principal();
                    FormPrincipal.Show();
                    this.Hide();
                }
                else if (respuestavalidacion.Estado == EstadosDeRespuesta.NoProceso)
                {
                    messageInfo.Text = respuestavalidacion.Mensaje;
                }
                else
                {
                    StreamWriter sw = new StreamWriter(@"C:\_MyTest\log.txt", true);//set the log path
                    sw.WriteLine($"Error Message:({respuestavalidacion.Mensaje}\t)");//error message
                    sw.Close();
                }
                //string passWord = Encrypt.GetSHA256(textBox2.Text.Trim());
            }
            else
            {
                
                textBox1.Focus();
                //return false;
                //
                //textBox1.Select(0, textBox1.Text.Length);
                //errorProvider1.SetError(textBox1, "Debe introducir el nombre");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
