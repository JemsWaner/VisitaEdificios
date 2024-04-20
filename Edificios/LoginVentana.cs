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
    public partial class LoginVentana : Form
    {
        CapaNegocios.AgregarDatos agregarDatos;
        public LoginVentana()
        {
            InitializeComponent();
            contrasenaField.PasswordChar = '*';
            agregarDatos =new CapaNegocios.AgregarDatos();
        }

        private void contrasenaField_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         bool puedeEntrar= agregarDatos.IniciarSesion(nombreField.Text,contrasenaField.Text);
            if (puedeEntrar.Equals(true)) {
                MessageBox.Show("Si existe");
                String AdminONo = agregarDatos.UsuarioOAdmin(CapaNegocios.AgregarDatos.idUsuario);
               
                if (AdminONo.Equals("Admin")) { 
                    OpcionesAdmin opcionesAdmin= new OpcionesAdmin();
                    opcionesAdmin.Visible = true;
                    this.Visible = false;
                }
                else { 
                    OpcionesNormal opcionesNormal= new OpcionesNormal();
                    opcionesNormal.Visible = true;
                    this.Visible = false;
                }
            }
        }

        private void contrasenaField_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
