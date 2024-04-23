using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
                coloresPanel.BackColor=Color.Firebrick;
                estadoLabel.ForeColor = Color.White;


                String link = @"C:\Users\Jems Waner\Documents\Basic Program\C#\Edificios\Edificios\iconos\icons8-cancel-96.png";
                Image imagen = Image.FromFile(link);
                iconPictureBox.Image = imagen;

            }
            else if (estadoSolicitud == "aprobada")
            {
                coloresPanel.BackColor = Color.SeaGreen;
                estadoLabel.ForeColor=Color.White;

                String link = @"C:\Users\Jems Waner\Documents\Basic Program\C#\Edificios\Edificios\iconos\icons8-approval-96.png";
                Image imagen = Image.FromFile(link);
                iconPictureBox.Image = imagen;
            }
            else
            {
                coloresPanel.BackColor = Color.Yellow;
                estadoLabel.Text = estadoSolicitud + "...".ToUpper();
            }

            List<String> listaCampo = adminActividad.ObtenerCampos(CapaNegocios.AgregarDatos.idUsuario);
            nombreLabel.Text = listaCampo[0].ToString()+ " " + listaCampo[1].ToString();
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
