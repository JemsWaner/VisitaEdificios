using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edificios
{
    public partial class OpcionesAdmin : Form
    {
        public OpcionesAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EdificiosVisitas edificiosVisitas = new EdificiosVisitas();
            edificiosVisitas.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           ListadoVisitantes listadoVisitantes = new ListadoVisitantes();
            listadoVisitantes.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NuevosUsuarios nuevosUsuarios= new NuevosUsuarios();
            nuevosUsuarios.Visible= true;
            this.Visible= false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
