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
    public partial class ListadoVisitantes : Form
    {
        CapaNegocios.AdminActividades AdminActividades;

        public ListadoVisitantes()
        {
            InitializeComponent();
            AdminActividades = new CapaNegocios.AdminActividades();
            listaUsuariosBox.Items.Clear();
            listaUsuariosBox.DataSource = AdminActividades.ObtenerListaUsuarios();
        }

        private void listaUsuariosBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String seleccionado= listaUsuariosBox.SelectedItem.ToString();
            if (seleccionado.Length != 0)
            {
                String seleccionadoId = seleccionado.Substring(0, 1);
                CapaNegocios.AdminActividades.idUsuario = Convert.ToInt32(seleccionadoId);
                MessageBox.Show(seleccionadoId);
                MessageBox.Show("El idUsuario es: " + CapaNegocios.AdminActividades.idUsuario.ToString());
               
                EditarUsuario editarUsuario= new EditarUsuario();
                editarUsuario.Visible = true;
                this.Visible = false;
            }
            else {
                MessageBox.Show("Debes seleccionar un usuario de la lista");
            }

        }
    }
}
