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
    public partial class OpcionesNormal : Form
    {
        public OpcionesNormal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           EdificiosVisitas edificiosVisitas= new EdificiosVisitas();
           edificiosVisitas.Visible = true;
            this.Visible = false; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registrarUsuario= new RegistrarUsuario();
            registrarUsuario.Visible = true;
            this.Visible=false;
        }
    }
}
