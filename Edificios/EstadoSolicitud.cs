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
    public partial class EstadoSolicitud : Form
    {
        CapaNegocios.AgregarDatos negociosCapa;
        CapaNegocios.AdminActividades adminActividad;
        public EstadoSolicitud()
        {
            InitializeComponent();
            negociosCapa = new CapaNegocios.AgregarDatos();
            adminActividad= new CapaNegocios.AdminActividades();
            String estadoSolicitud= negociosCapa.ObtenerSolicitudes(CapaNegocios.AgregarDatos.idUsuario);
            estadoLabel.Text = estadoSolicitud;

            if (estadoSolicitud == "cancelada")
            {
                coloresPanel.BackColor=Color.Red;
            }
            else if (estadoSolicitud == "aprobada")
            {
                coloresPanel.BackColor = Color.Green;
            }
            else
            {
                coloresPanel.BackColor = Color.Yellow;
            }

            List<String> listaCampo = adminActividad.ObtenerCampos(CapaNegocios.AgregarDatos.idUsuario);
            nombreLabel.Text = listaCampo[0].ToString();
            contrasenaLabel.Text = listaCampo[2].ToString();
            correoLabel.Text = listaCampo[4].ToString();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
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

        private void estadoLabel_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void coloresPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
