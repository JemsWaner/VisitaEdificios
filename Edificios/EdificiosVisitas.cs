using CapaNegocios;
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
    public partial class EdificiosVisitas : Form
    {
        CapaNegocios.AgregarDatos negociosCapa;
        public EdificiosVisitas()
        {
            InitializeComponent();
            negociosCapa = new CapaNegocios.AgregarDatos();
            edificio1comboBox.Items.Clear();
            edificio2comboBox.Items.Clear();
            edificio3comboBox.Items.Clear();
            edificio4comboBox.Items.Clear();

            edificio1comboBox.DataSource = negociosCapa.ObtenerEdificio(1);
            edificio2comboBox.DataSource = negociosCapa.ObtenerEdificio(2);
            edificio3comboBox.DataSource = negociosCapa.ObtenerEdificio(3);
            edificio4comboBox.DataSource = negociosCapa.ObtenerEdificio(4);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            String AdminONo = negociosCapa.UsuarioOAdmin(CapaNegocios.AgregarDatos.idUsuario);

            if (AdminONo.Equals("Admin"))
            {
                OpcionesAdmin opcionesAdmin = new OpcionesAdmin();
                opcionesAdmin.Visible = true;
                this.Visible = false;
            }
            else
            {
                OpcionesNormal opcionesNormal = new OpcionesNormal();
                opcionesNormal.Visible = true;
                this.Visible = false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
