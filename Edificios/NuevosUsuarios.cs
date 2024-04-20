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
    public partial class NuevosUsuarios : Form
    {
        CapaNegocios.AdminActividades adminActividad;
        CapaNegocios.AgregarDatos negociosCapa;
        public NuevosUsuarios()
        {
            InitializeComponent();
            contrasenaField.PasswordChar = '*';
            negociosCapa = new CapaNegocios.AgregarDatos();
            adminActividad = new CapaNegocios.AdminActividades();
           tipoComboBox.DataSource= adminActividad.ObtenerTipo();
        }

        private void contrasenaField_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            String fechaNacFormated= fechaNacimiento.Value.ToString(("yyyy-MM-dd"));
            adminActividad.InsertarNuevoUsuario(nombreField.Text, apellidoField.Text, contrasenaField.Text,fechaNacFormated,tipoComboBox.Text);
            MessageBox.Show("Un nuevo usuario se ha registrado");
        }

        private void tipoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
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
