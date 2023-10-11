using Electronicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EmpresaElectronica
{
    public partial class FrmConsola : FrmAgregar
    {
        public Consola consola;
        int precio;
        double memoriaTotal;
        short velocidadDescargaMB;
        bool aceptaDiscosFisicos = false;
        ETipoOrigen tipoOrigen;
        public FrmConsola()
        {
            InitializeComponent();
            cmBoxAceptaDiscosFisicos.Items.Add("SI");
            cmBoxAceptaDiscosFisicos.Items.Add("NO");
            cmBoxAceptaDiscosFisicos.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public FrmConsola(Consola consola) : this()
        {
            txtNombre.Text = consola.Nombre;
            txtPrecio.Text = consola.Precio.ToString();
            txtMarca.Text = consola.Marca;
            txtBoxMemoriaTotal.Text = consola.MemoriaTotal.ToString();
            txtBoxVelocidadDescarga.Text = consola.VelocidadDescargaMB.ToString();
            cmBoxOrigen.Text = consola.TipoOrigen.ToString();
            if (consola.AceptaDiscosFisicos)
            {
                cmBoxAceptaDiscosFisicos.Text = "SI";
            }
            else
            {
                cmBoxAceptaDiscosFisicos.Text = "NO";
            }
        }
        protected override void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != string.Empty && int.TryParse(txtPrecio.Text, out precio) && txtMarca.Text != string.Empty &&
                double.TryParse(txtBoxMemoriaTotal.Text, out memoriaTotal) && short.TryParse(txtBoxVelocidadDescarga.Text, 
                out velocidadDescargaMB) && cmBoxAceptaDiscosFisicos.Text != string.Empty && cmBoxOrigen.Text != string.Empty)
            {
                if (cmBoxAceptaDiscosFisicos.Text == "SI")
                {
                    aceptaDiscosFisicos = true;
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

                this.consola = new Consola(precio, txtNombre.Text, txtMarca.Text, tipoOrigen, aceptaDiscosFisicos, velocidadDescargaMB,
                    memoriaTotal);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Campos invalidos o incompletos");
            }
        }
    }
}
