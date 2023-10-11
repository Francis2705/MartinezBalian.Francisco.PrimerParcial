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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_EmpresaElectronica
{
    public partial class FrmPrincipalEmpresa : Form //ARREGLAR PROBLEMA DE SERIALIZACION
    {
        private EmpresaElectronica empresaElectronica = new EmpresaElectronica("Comcelcon", "Francis");

        public FrmPrincipalEmpresa()
        {
            InitializeComponent();
        }

        private void ActualizarVisor() //Completo
        {
            lstBoxObjetos.Items.Clear();

            foreach (ArtefactoElectronico artefacto in empresaElectronica.ProductosElectronicos)
            {
                lstBoxObjetos.Items.Add(artefacto); //agrego un objeto y se muestran sus datos
                //lstBoxObjetos.Items.Add(artefacto.ToString()); //Agrego un string con los datos del objeto
            }
        }

        private void FrmPrincipalEmpresa_FormClosing(object sender, FormClosingEventArgs e)//Incompleto FILE CON OPCIONES DONDE GUARDAR
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres cerrar la sesion?",
                "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
                serializerOptions.WriteIndented = true;

                string objJson = JsonSerializer.Serialize(empresaElectronica.ProductosElectronicos, serializerOptions);
                using (StreamWriter escritorJson = new StreamWriter(@"../../../../productosElectronicos.json"))
                {
                    escritorJson.WriteLine(objJson);
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void btnVisualizadorUsuariosLogueo_Click(object sender, EventArgs e) //Completo
        {
            FrmVisualizadorUsuarios frmVisualizadorUsuarios = new FrmVisualizadorUsuarios();
            frmVisualizadorUsuarios.ShowDialog();
        }

        private void FrmPrincipalEmpresa_Load(object sender, EventArgs e)//Incompleto FILE CON OPCIONES DONDE GUARDAR
        {
            UsuarioElectronico usuarioElectronico = FrmLogin.GetUsuarioElectronico();

            lblUsuarioInfo.Text = $"Nombre: {usuarioElectronico.Nombre}\nFecha: {DateTime.Now.ToString("yyyy-MM-dd")}";

            cmBoxProductos.Items.Add("Celular");
            cmBoxProductos.Items.Add("Computadora");
            cmBoxProductos.Items.Add("Consola");
            cmBoxProductos.DropDownStyle = ComboBoxStyle.DropDownList;

            /*using (StreamReader lectorJson = new StreamReader(@"../../../../productosElectronicos.json"))
            {
                string jsonString = lectorJson.ReadToEnd();

                empresaElectronica.ProductosElectronicos = (List<ArtefactoElectronico>)JsonSerializer.Deserialize(jsonString, 
                typeof(List<ArtefactoElectronico>));
            }
            this.ActualizarVisor();*/
        }

        private void btnMostrarCaracteristicasEspecificas_Click(object sender, EventArgs e) //Incompleto (poner foto)
        {

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
                        if (empresaElectronica != frmCeluar.celular)
                        {
                            empresaElectronica += frmCeluar.celular; //empresaElectronica.ProductosElectronicos.Add(frmCeluar.celular);
                            this.ActualizarVisor();
                        }
                        else
                        {
                            MessageBox.Show("Error, producto existente");
                        }
                    }
                }
                else if (opcionSeleccionada == "Computadora")
                {
                    FrmComputadora frmComputadora = new FrmComputadora();
                    frmComputadora.ShowDialog();

                    if (frmComputadora.DialogResult == DialogResult.OK)
                    {
                        if (empresaElectronica != frmComputadora.computadora)
                        {
                            empresaElectronica += frmComputadora.computadora;
                            //empresaElectronica.ProductosElectronicos.Add(frmComputadora.computadora);
                            this.ActualizarVisor();
                        }
                        else
                        {
                            MessageBox.Show("Error, producto existente");
                        }
                    }
                }
                else if (opcionSeleccionada == "Consola")
                {
                    FrmConsola frmConsola = new FrmConsola();
                    frmConsola.ShowDialog();

                    if (frmConsola.DialogResult == DialogResult.OK)
                    {
                        if (empresaElectronica != frmConsola.consola)
                        {
                            empresaElectronica += frmConsola.consola; //empresaElectronica.ProductosElectronicos.Add(frmConsola.consola);
                            this.ActualizarVisor();
                        }
                        else
                        {
                            MessageBox.Show("Error, producto existente");
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
            if (lstBoxObjetos.SelectedIndex == -1)
            {
                MessageBox.Show("No se selecciono ningun producto para modificiar");
            }
            else
            {

                if (lstBoxObjetos.SelectedItem is Celular)
                {
                    Celular celu = (Celular)empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex];

                    FrmCelular frmCeluar = new FrmCelular(celu);
                    frmCeluar.ShowDialog();

                    if (frmCeluar.DialogResult == DialogResult.OK)
                    {
                        empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex] = frmCeluar.celular;
                        this.ActualizarVisor();
                    }
                }
                else if (lstBoxObjetos.SelectedItem is Computadora)
                {
                    Computadora computadora = (Computadora)empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex];

                    FrmComputadora frmComputadora = new FrmComputadora(computadora);
                    frmComputadora.ShowDialog();

                    if (frmComputadora.DialogResult == DialogResult.OK)
                    {
                        empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex] = frmComputadora.computadora;
                        this.ActualizarVisor();
                    }
                }
                else if (lstBoxObjetos.SelectedItem is Consola)
                {
                    Consola consola = (Consola)empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex];

                    FrmConsola frmConsola = new FrmConsola(consola);
                    frmConsola.ShowDialog();

                    if (frmConsola.DialogResult == DialogResult.OK)
                    {
                        empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex] = frmConsola.consola;
                        this.ActualizarVisor();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) //Completo
        {
            if (lstBoxObjetos.SelectedIndex == -1)
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
                    empresaElectronica -= (ArtefactoElectronico)lstBoxObjetos.SelectedItem;
                    this.ActualizarVisor();
                }
            }
        }
    }
}
