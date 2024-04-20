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
    public partial class EditarUsuario : Form
    {
        CapaNegocios.AgregarDatos negociosCapa;
        CapaNegocios.AdminActividades adminActividad;
        public EditarUsuario()
        {
            InitializeComponent();
            contrasenaField.PasswordChar = '*';
            negociosCapa = new CapaNegocios.AgregarDatos();         
            adminActividad = new CapaNegocios.AdminActividades();

            carreraComboBox.DataSource = negociosCapa.ObtenerCarrera();
            edificioComboBox.DataSource = negociosCapa.ObtenerEdificio();
            aulaComboBox.DataSource = negociosCapa.ObtenerAula();
            tipoComboBox.DataSource = adminActividad.ObtenerTipo();
            solicitudComboBox.DataSource= adminActividad.ObtenerSolicitud();

            List<String> listaCampo = adminActividad.ObtenerCampos(CapaNegocios.AdminActividades.idUsuario);
            nombreField.Text = listaCampo[0];
            apellidoField.Text = listaCampo[1];
            contrasenaField.Text = listaCampo[2];
            motivoField.Text = listaCampo[3];
            correoField.Text = listaCampo[4];
        }

        private void EditarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void contrasenaField_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            String fechaentrada = entradaDateTime.Value.ToString(("yyyy-MM-dd"));
            String fechasalida = salidaDateTime.Value.ToString(("yyyy-MM-dd"));

            negociosCapa.ActualizarUsuario(AgregarDatos.idUsuario, nombreField.Text, apellidoField.Text, correoField.Text, contrasenaField.Text, motivoField.Text, carreraComboBox.Text, edificioComboBox.Text, aulaComboBox.Text, fechaentrada, fechasalida);
            negociosCapa.ActualizarTipoYUsuario(AgregarDatos.idUsuario,tipoComboBox.Text,solicitudComboBox.Text);

            MessageBox.Show("Usuario editado con exito");

            OpcionesAdmin opcionesAdmin = new OpcionesAdmin();
            opcionesAdmin.Visible = true;
            this.Visible = false;
        }

        private void tipoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox25_Click(object sender, EventArgs e)
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
    }
}
