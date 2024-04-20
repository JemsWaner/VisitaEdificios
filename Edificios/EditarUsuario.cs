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
        }

        private void EditarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void contrasenaField_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
