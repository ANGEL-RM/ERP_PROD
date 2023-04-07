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
    public partial class Loader : Form
    {

        public Loader()
        {
            InitializeComponent();         
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            OLoader.Load("SpinLoad.gif");
        }
        /*protected override void OnLoad(EventArgs e) 
{ 
   base.OnLoad(e);
   Task.Factory.StartNew(ActionLoader).ContinueWith(s => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
}*/

        /*private void Loader_Load(object sender, EventArgs e)
        {
            
            //OLoader.Location = new Point(this.Width / 2 - OLoader.Width / 2, this.Height / 2 - OLoader.Height / 2);

        }*/
    }
}
