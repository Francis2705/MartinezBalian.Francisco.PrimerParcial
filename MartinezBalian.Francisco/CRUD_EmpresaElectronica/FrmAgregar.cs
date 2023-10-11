﻿using Electronicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_EmpresaElectronica
{
    public partial class FrmAgregar : Form
    {
        public FrmAgregar()
        {
            InitializeComponent();

            cmBoxOrigen.Items.Add(ETipoOrigen.CHINO.ToString());
            cmBoxOrigen.Items.Add(ETipoOrigen.AMERICANO.ToString());
            cmBoxOrigen.Items.Add(ETipoOrigen.INTERNACIONAL.ToString());
            cmBoxOrigen.Items.Add(ETipoOrigen.JAPONES.ToString());
            cmBoxOrigen.Items.Add(ETipoOrigen.KOREANO.ToString());
            cmBoxOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected virtual void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
