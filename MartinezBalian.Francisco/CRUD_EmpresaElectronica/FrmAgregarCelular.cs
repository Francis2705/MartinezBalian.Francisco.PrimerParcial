using Electronicos;
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
    public partial class FrmAgregarCelular : FrmAgregar
    {
        public Celular celular;
        int precio;
        int bateria;
        int cantidadContactos;
        bool asistente = false;
        ETipoOrigen tipoOrigen;
        public FrmAgregarCelular()
        {
            InitializeComponent();
            cmBoxAsistenteVirtual.Items.Add("SI");
            cmBoxAsistenteVirtual.Items.Add("NO");
            cmBoxAsistenteVirtual.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public FrmAgregarCelular(Celular celu) : this()
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
        protected override void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty && int.TryParse(txtPrecio.Text, out precio) && txtMarca.Text != string.Empty &&
                int.TryParse(txtBateria.Text, out bateria) && int.TryParse(txtCantidadContactos.Text, out cantidadContactos) &&
                cmBoxAsistenteVirtual.Text != string.Empty && cmBoxOrigen.Text != string.Empty)
            {
                if (cmBoxAsistenteVirtual.Text == "SI")
                {
                    asistente = true;
                }
                switch(cmBoxOrigen.Text)
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
                MessageBox.Show("Campos invalidos o incompletos");
            }
        }
    }
}
