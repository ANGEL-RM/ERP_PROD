
using log4net.Core;
using Modelo;
using Modelo.Usuarios;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            HiderLoader();
        }

        private Loader loader;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Respuesta<int> ValidarLogin()
        {
            return new DaoAdminUsuario().ValidarLogin(textBox1.Text, textBox2.Text);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                ShowLoader();
                Task<Respuesta<int>> taskValidarLogin = new Task<Respuesta<int>>(ValidarLogin);
                taskValidarLogin.Start();
                Respuesta<int> respuestavalidacion = await taskValidarLogin;
                HiderLoader();
                if (respuestavalidacion.Estado == EstadosDeRespuesta.Correcto)
                {
                    Principal FormPrincipal = new Principal();
                    MessageBox.Show("Bienvenido " + Tbl_Adm_UsuarioCache.Nombre + ", " + Tbl_Adm_UsuarioCache.ApellidoP);
                    FormPrincipal.Show();
                    this.Hide();
                }
                else if (respuestavalidacion.Estado == EstadosDeRespuesta.NoProceso)
                {
                    messageInfo.Text = respuestavalidacion.Mensaje;
                    messageInfo.ForeColor = Color.Red;
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
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.Focus();
                    MessageBox.Show("Ingresa Usuario");
                    //textBox1.BorderColor = Color.Red;
                    //textBox1.BorderFocusColor = Color.Red;
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        //textBox2.BorderColor = Color.Red;
                        //textBox2.BorderFocusColor = Color.Red;
                    }
                }
                else if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox2.Focus();
                    MessageBox.Show("Ingresa Contraseña");
                    //textBox2.BorderColor = Color.Red;
                    //textBox2.BorderFocusColor = Color.Red;
                    if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        //textBox1.BorderColor = Color.Red;
                        //textBox1.BorderFocusColor = Color.Red;
                    }
                }
                
                //errorProvider1.SetError(textBox1, "Debe introducir el nombre");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textBox1.BorderColor = Color.Black;
            //textBox1.BorderFocusColor = Color.Blue;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this.textBox2.BorderColor = Color.Black;
            //this.textBox2.BorderFocusColor = Color.Blue;
        }


        public void ShowLoader()
        {
            messageInfo.Text = "";
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.SpinLoader.Visible = true;
        }
        public void HiderLoader()
        {
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.SpinLoader.Visible = false;
        }
    }
}
