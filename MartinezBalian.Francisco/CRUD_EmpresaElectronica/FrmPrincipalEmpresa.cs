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
    public partial class FrmPrincipalEmpresa : Form
    {
        private EmpresaElectronica empresaElectronica = new EmpresaElectronica("Comcelcon", "Francis");
        private void ActualizarVisor()
        {
            lstBoxObjetos.Items.Clear();

            foreach (ArtefactoElectronico artefacto in empresaElectronica.ProductosElectronicos)
            {
                lstBoxObjetos.Items.Add(artefacto); //aniado un objeto y se muestran sus datos
                //lstBoxObjetos.Items.Add(artefacto.ToString()); //aniado un string con los datos del objeto
            }
        }
        public FrmPrincipalEmpresa()
        {
            InitializeComponent();
        }

        private void FrmPrincipalEmpresa_FormClosing(object sender, FormClosingEventArgs e)//HACER LO DE FILE CON OPCIONES DONDE GUARDAR
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

        private void btnVisualizadorUsuariosLogueo_Click(object sender, EventArgs e)
        {
            FrmVisualizadorUsuarios frmVisualizadorUsuarios = new FrmVisualizadorUsuarios();
            frmVisualizadorUsuarios.ShowDialog();
        }

        //ARREGLAR PROBLEMA DE SERIALIZACION
        private void FrmPrincipalEmpresa_Load(object sender, EventArgs e)//HACER LO DE FILE CON OPCIONES DONDE GUARDAR
        {
            UsuarioElectronico usuarioElectronico = FrmLogin.GetUsuarioElectronico();

            lblUsuarioInfo.Text = $"Nombre: {usuarioElectronico.Nombre}\nFecha: {DateTime.Now.ToString("yyyy-MM-dd")}";

            cmBoxProductos.Items.Add("Celular");
            cmBoxProductos.Items.Add("Computadora");
            cmBoxProductos.Items.Add("Consola");
            cmBoxProductos.DropDownStyle = ComboBoxStyle.DropDownList;

            using (StreamReader lectorJson = new StreamReader(@"../../../../productosElectronicos.json"))
            {
                string jsonString = lectorJson.ReadToEnd();

                empresaElectronica.ProductosElectronicos = (List<ArtefactoElectronico>)JsonSerializer.Deserialize(jsonString, 
                typeof(List<ArtefactoElectronico>));
            }
            this.ActualizarVisor();
        }

        private void btnMostrarCaracteristicasEspecificas_Click(object sender, EventArgs e) //Aparte de mostrar la info, poner foto
        {

        }

        private void btnOrdenar_Click(object sender, EventArgs e) //Ordeno segun el radioButton seleccionado
        {
            if (rbNombreAscendentemente.Checked == true)
            {
                //ordenar por nombre de la A - Z
            }
            else if (rbNombreDescendentemente.Checked == true)
            {
                //ordenar por nombre de la Z - A
            }
            else if (rbPrecioAscendentemente.Checked == true)
            {
                //ordenar por precio de menor a mayor
            }
            else if (rbPrecioDescendentemente.Checked == true)
            {
                //ordenar por precio de mayor a menor
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmBoxProductos.SelectedItem != null)
            {
                string opcionSeleccionada = cmBoxProductos.SelectedItem.ToString();
                if (opcionSeleccionada == "Celular")
                {
                    FrmAgregarCelular frmAgregarCeluar = new FrmAgregarCelular();
                    frmAgregarCeluar.ShowDialog();

                    if (frmAgregarCeluar.DialogResult == DialogResult.OK)
                    {
                        //Valido que no este
                        if (empresaElectronica != frmAgregarCeluar.celular)
                        {
                            empresaElectronica.ProductosElectronicos.Add(frmAgregarCeluar.celular);
                            this.ActualizarVisor();
                        }
                        else
                        {
                            MessageBox.Show("Error, celular existente");
                        }
                    }
                }
                else if (opcionSeleccionada == "Computadora")
                {
                    //llamo al form agregar de computadora
                }
                else if (opcionSeleccionada == "Consola")
                {
                    //llamo al form agregar de consola
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto para agregar");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
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

                    FrmAgregarCelular frmAgregarCelular = new FrmAgregarCelular(celu);
                    frmAgregarCelular.ShowDialog();

                    if (frmAgregarCelular.DialogResult == DialogResult.OK)
                    {
                        empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex] = frmAgregarCelular.celular;
                        this.ActualizarVisor();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) //Listo
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
                    empresaElectronica.ProductosElectronicos.RemoveAt(lstBoxObjetos.SelectedIndex); 
                    this.ActualizarVisor();
                }
            }
        }
    }
}
