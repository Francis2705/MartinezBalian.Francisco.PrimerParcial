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
    public partial class FrmPrincipalEmpresa : Form
    {
        public FrmPrincipalEmpresa()
        {
            InitializeComponent();
        }

        private void FrmPrincipalEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres cerrar la sesion?", 
                "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
            }
        }

        private void btnVisualizadorUsuariosLogueo_Click(object sender, EventArgs e)
        {
            FrmVisualizadorUsuarios frmVisualizadorUsuarios = new FrmVisualizadorUsuarios();
            frmVisualizadorUsuarios.ShowDialog();
        }

        private void FrmPrincipalEmpresa_Load(object sender, EventArgs e)
        {
            UsuarioElectronico usuarioElectronico = FrmLogin.GetUsuarioElectronico();

            lblUsuarioInfo.Text = $"Nombre: {usuarioElectronico.Nombre}\nFecha: {DateTime.Now.ToString("yyyy-MM-dd")}";
        }
    }
}
