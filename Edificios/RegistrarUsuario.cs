﻿using CapaNegocios;
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
    public partial class RegistrarUsuario : Form
    {
        CapaNegocios.AgregarDatos negociosCapa;
        CapaNegocios.AdminActividades adminActividad;

        public RegistrarUsuario()
        {
            InitializeComponent();
            
            contrasenaField.PasswordChar = '*';
            pictureBox18.Visible= false;
            label13.Visible=false;

            negociosCapa = new CapaNegocios.AgregarDatos();
            adminActividad = new CapaNegocios.AdminActividades();

            carreraComboBox.DataSource = negociosCapa.ObtenerCarrera();
            edificioComboBox.DataSource = negociosCapa.ObtenerEdificio();
            aulaComboBox.DataSource=negociosCapa.ObtenerAula();

            if (AgregarDatos.idUsuario != 0) {
                pictureBox18.Visible = true;
                label13.Visible=true;
                MessageBox.Show(AgregarDatos.idUsuario.ToString());
                registrarButton.Text = "Actualizar";

                List<String> listaCampo = adminActividad.ObtenerCampos(CapaNegocios.AgregarDatos.idUsuario);
                nombreField.Text = listaCampo[0];
                apellidoField.Text = listaCampo[1];
                contrasenaField.Text = listaCampo[2];
                motivoField.Text = listaCampo[3];
                correoField.Text = listaCampo[4];
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nombreField_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void registrarButton_Click(object sender, EventArgs e)
        {
            String fechaentrada = entradaDateTime.Value.ToString(("yyyy-MM-dd"));
            String fechasalida= salidaDateTime.Value.ToString(("yyyy-MM-dd"));

            if (AgregarDatos.idUsuario != 0)
            {
                negociosCapa.ActualizarUsuario(AgregarDatos.idUsuario,nombreField.Text, apellidoField.Text, correoField.Text, contrasenaField.Text, motivoField.Text, carreraComboBox.Text, edificioComboBox.Text, aulaComboBox.Text, fechaentrada, fechasalida);

                String tipoDeUsuario = negociosCapa.UsuarioOAdmin(AgregarDatos.idUsuario);
                MessageBox.Show(tipoDeUsuario);

                if (tipoDeUsuario == "Admin")
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

            else {
                negociosCapa.InsertarUsuario(nombreField.Text, apellidoField.Text, correoField.Text, contrasenaField.Text, motivoField.Text, carreraComboBox.Text, edificioComboBox.Text, aulaComboBox.Text, fechaentrada, fechasalida);
                MessageBox.Show("El usuario se ha registrado");
                MessageBox.Show(AgregarDatos.idUsuario.ToString());
                String tipoDeUsuario = negociosCapa.UsuarioOAdmin(AgregarDatos.idUsuario);
                MessageBox.Show(tipoDeUsuario);

                if (tipoDeUsuario == "Admin")
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

        private void RegistrarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void carreraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
