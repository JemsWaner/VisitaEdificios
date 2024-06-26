﻿using System;
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
        CapaNegocios.AgregarDatos negociosCapa;

        public ListadoVisitantes()
        {
            InitializeComponent();
            AdminActividades = new CapaNegocios.AdminActividades();
            negociosCapa = new CapaNegocios.AgregarDatos();
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
                int idNuevo= Convert.ToInt32(seleccionadoId);
                CapaNegocios.AdminActividades.idUsuarioAdmin = idNuevo;
                MessageBox.Show(seleccionadoId);
                MessageBox.Show("El idUsuarioAdmin es: " + CapaNegocios.AdminActividades.idUsuarioAdmin.ToString());
               
                EditarUsuario editarUsuario= new EditarUsuario();
                editarUsuario.Visible = true;
                this.Visible = false;
            }
            else {
                MessageBox.Show("Debes seleccionar un usuario de la lista");
            }

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
