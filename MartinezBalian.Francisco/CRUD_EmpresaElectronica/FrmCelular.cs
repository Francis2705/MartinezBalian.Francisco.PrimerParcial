﻿using Electronicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EmpresaElectronica
{
    /// <summary>
    /// Representa un formulario para agregar un celular
    /// </summary>
    public partial class FrmCelular : FrmAgregar
    {
        public Celular celular;
        int precio;
        int bateria;
        int cantidadContactos;
        bool asistente = false;
        ETipoOrigen tipoOrigen;
        public FrmCelular()
        {
            InitializeComponent();
            cmBoxAsistenteVirtual.Items.Add("SI");
            cmBoxAsistenteVirtual.Items.Add("NO");
            cmBoxAsistenteVirtual.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public FrmCelular(Celular celu) : this()
        {
            txtNombre.Text = celu.Nombre;
            txtPrecio.Text = celu.Precio.ToString();
            txtMarca.Text = celu.Marca;
            txtBateria.Text = celu.Bateria.ToString();
            txtCantidadContactos.Text = celu.CantidadContactos.ToString();
            cmBoxOrigen.Text = celu.TipoOrigen.ToString();
            if (celu.AsistenteVirtual)
            {
                cmBoxAsistenteVirtual.Text = "SI";
            }
            else
            {
                cmBoxAsistenteVirtual.Text = "NO";
            }
        }
        /// <summary>
        /// Si se pasa una serie de validaciones, se agrega un celular, sino se muestra un MessageBox.Show informando que no se pudo
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
        protected override void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && int.TryParse(txtPrecio.Text, out precio) && 
                !string.IsNullOrWhiteSpace(txtMarca.Text) && int.TryParse(txtBateria.Text, out bateria) && 
                int.TryParse(txtCantidadContactos.Text, out cantidadContactos) && cmBoxAsistenteVirtual.Text != string.Empty && 
                cmBoxOrigen.Text != string.Empty)
            {
                if (cmBoxAsistenteVirtual.Text == "SI")
                {
                    asistente = true;
                }
                switch (cmBoxOrigen.Text)
                {
                    case "CHINO":
                        tipoOrigen = ETipoOrigen.CHINO;
                        break;
                    case "AMERICANO":
                        tipoOrigen = ETipoOrigen.AMERICANO;
                        break;
                    case "KOREANO":
                        tipoOrigen = ETipoOrigen.KOREANO;
                        break;
                    case "JAPONES":
                        tipoOrigen = ETipoOrigen.JAPONES;
                        break;
                    case "INTERNACIONAL":
                        tipoOrigen = ETipoOrigen.INTERNACIONAL;
                        break;
                }

                this.celular = new Celular(precio, txtNombre.Text, txtMarca.Text, tipoOrigen, bateria, cantidadContactos, asistente);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Campos invalidos o incompletos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
