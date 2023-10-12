using Electronicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_EmpresaElectronica
{
    public partial class FrmPrincipalEmpresa : Form
    {
        private EmpresaElectronica empresaElectronica = new EmpresaElectronica("Comcelcon", "Francis");
        private bool error;
        private int cantidad;

        public FrmPrincipalEmpresa()
        {
            InitializeComponent();
            this.error = false;
        }

        private void ActualizarVisor() //Completo
        {
            lstBoxObjetos.Items.Clear();

            foreach (ArtefactoElectronico artefacto in empresaElectronica.ProductosElectronicos)
            {
                lstBoxObjetos.Items.Add(artefacto); //Agrego un objeto y se muestran sus datos
                //lstBoxObjetos.Items.Add(artefacto.ToString()); //Agrego un string con los datos del objeto
            }
        }

        private void FrmPrincipalEmpresa_FormClosing(object sender, FormClosingEventArgs e) //Completo
        {
            if (error)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres cerrar la sesion?",
                    "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "XML Files (*.xml)|*.xml";
                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = saveDialog.FileName;

                            XmlSerializer serializer = new XmlSerializer(typeof(List<ArtefactoElectronico>));

                            using (FileStream stream = new FileStream(fileName, FileMode.Create))
                            {
                                serializer.Serialize(stream, empresaElectronica.ProductosElectronicos);
                            }
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        private void FrmPrincipalEmpresa_Load(object sender, EventArgs e) //Completo
        {
            UsuarioElectronico usuarioElectronico = FrmLogin.GetUsuarioElectronico();

            lblUsuarioInfo.Text = $"Nombre: {usuarioElectronico.nombre}\nFecha: {DateTime.Now.ToString("yyyy-MM-dd")}";

            cmBoxProductos.Items.Add("Celular");
            cmBoxProductos.Items.Add("Computadora");
            cmBoxProductos.Items.Add("Consola");
            cmBoxProductos.DropDownStyle = ComboBoxStyle.DropDownList;

            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "XML Files (*.xml)|*.xml";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openDialog.FileName;
                    XmlSerializer serializer = new XmlSerializer(typeof(List<ArtefactoElectronico>));

                    try
                    {
                        using (FileStream stream = new FileStream(fileName, FileMode.Open))
                        {
                            empresaElectronica.ProductosElectronicos = (List<ArtefactoElectronico>)serializer.Deserialize(stream);
                        }
                        this.ActualizarVisor();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex}");
                        this.error = true;
                        this.DialogResult = DialogResult.OK; //Hago esto para llamar al FormClosing
                    }
                }
                else
                {
                    this.error = true;
                    this.DialogResult = DialogResult.OK; //Hago esto para llamar al FormClosing
                }
            }
        }

        private void btnVisualizadorUsuariosLogueo_Click(object sender, EventArgs e) //Completo
        {
            FrmVisualizadorUsuarios frmVisualizadorUsuarios = new FrmVisualizadorUsuarios();
            frmVisualizadorUsuarios.ShowDialog();
        }

        private void btnMostrarCaracteristicasEspecificas_Click(object sender, EventArgs e) //Completo
        {
            if (this.lstBoxObjetos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto para ver sus caracteristicas especificas");
            }
            else
            {
                MessageBox.Show($"{((ArtefactoElectronico)lstBoxObjetos.SelectedItem).MostrarCaracteristicasEspecificas()}",
                    "Caracteristicas especificas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e) //Completo
        {
            if (rbNombreAscendentemente.Checked == true)
            {
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica.OrdenarArtefactosPorNombreAscendente);
            }
            else if (rbNombreDescendentemente.Checked == true)
            {
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica.OrdenarArtefactosPorNombreDescendente);
            }
            else if (rbPrecioAscendentemente.Checked == true)
            {
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica.OrdenarArtefactosPorPrecioAscendente);
            }
            else if (rbPrecioDescendentemente.Checked == true)
            {
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica.OrdenarArtefactosPorPrecioDescendente);
            }
            this.ActualizarVisor();
        }

        private void btnAgregar_Click(object sender, EventArgs e) //Completo
        {
            if (cmBoxProductos.SelectedItem != null)
            {
                string opcionSeleccionada = cmBoxProductos.SelectedItem.ToString();

                if (opcionSeleccionada == "Celular")
                {
                    FrmCelular frmCeluar = new FrmCelular();
                    frmCeluar.ShowDialog();

                    if (frmCeluar.DialogResult == DialogResult.OK)
                    {
                        this.cantidad = empresaElectronica.ProductosElectronicos.Count;
                        this.empresaElectronica += frmCeluar.celular; //empresaElectronica.ProductosElectronicos.Add(frmCeluar.celular);

                        if (this.cantidad == this.empresaElectronica.ProductosElectronicos.Count)
                        {
                            MessageBox.Show("Error, producto existente");
                        }
                        else
                        {
                            this.ActualizarVisor();
                        }
                    }
                }
                else if (opcionSeleccionada == "Computadora")
                {
                    FrmComputadora frmComputadora = new FrmComputadora();
                    frmComputadora.ShowDialog();

                    if (frmComputadora.DialogResult == DialogResult.OK)
                    {
                        this.cantidad = empresaElectronica.ProductosElectronicos.Count;
                        this.empresaElectronica += frmComputadora.computadora;

                        if (this.cantidad == this.empresaElectronica.ProductosElectronicos.Count)
                        {
                            MessageBox.Show("Error, producto existente");
                        }
                        else
                        {
                            this.ActualizarVisor();
                        }
                    }
                }
                else if (opcionSeleccionada == "Consola")
                {
                    FrmConsola frmConsola = new FrmConsola();
                    frmConsola.ShowDialog();

                    if (frmConsola.DialogResult == DialogResult.OK)
                    {
                        this.cantidad = empresaElectronica.ProductosElectronicos.Count;
                        this.empresaElectronica += frmConsola.consola;

                        if (this.cantidad == this.empresaElectronica.ProductosElectronicos.Count)
                        {
                            MessageBox.Show("Error, producto existente");
                        }
                        else
                        {
                            this.ActualizarVisor();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto para agregar");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) //Completo
        {
            if (this.lstBoxObjetos.SelectedIndex == -1)
            {
                MessageBox.Show("No se selecciono ningun producto para modificiar");
            }
            else
            {

                if (this.lstBoxObjetos.SelectedItem is Celular)
                {
                    Celular celu = (Celular)this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex];

                    FrmCelular frmCeluar = new FrmCelular(celu);
                    frmCeluar.ShowDialog();

                    if (frmCeluar.DialogResult == DialogResult.OK)
                    {
                        this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex] = frmCeluar.celular;
                        this.ActualizarVisor();
                    }
                }
                else if (this.lstBoxObjetos.SelectedItem is Computadora)
                {
                    Computadora computadora = (Computadora)this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex];

                    FrmComputadora frmComputadora = new FrmComputadora(computadora);
                    frmComputadora.ShowDialog();

                    if (frmComputadora.DialogResult == DialogResult.OK)
                    {
                        this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex] = frmComputadora.computadora;
                        this.ActualizarVisor();
                    }
                }
                else if (this.lstBoxObjetos.SelectedItem is Consola)
                {
                    Consola consola = (Consola)this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex];

                    FrmConsola frmConsola = new FrmConsola(consola);
                    frmConsola.ShowDialog();

                    if (frmConsola.DialogResult == DialogResult.OK)
                    {
                        this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex] = frmConsola.consola;
                        this.ActualizarVisor();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) //Completo
        {
            if (this.lstBoxObjetos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto para eliminar");
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar este producto? Esta accion es irreversible",
                "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    //empresaElectronica.ProductosElectronicos.RemoveAt(lstBoxObjetos.SelectedIndex);
                    this.empresaElectronica -= (ArtefactoElectronico)lstBoxObjetos.SelectedItem;
                    this.ActualizarVisor();
                }
            }
        }
    }
}
