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
        public NuevosUsuarios()
        {
            InitializeComponent();
            contrasenaField.PasswordChar = '*';
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
    }
}
