using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CRUD_EmpresaElectronica
{
    public partial class FrmVisualizadorUsuarios : Form
    {
        public FrmVisualizadorUsuarios()
        {
            InitializeComponent();
        }

        private void FrmVisualizadorUsuarios_Load(object sender, EventArgs e)
        {
            Encoding miCodificacion = Encoding.UTF8;
            string info;

            using (StreamReader sr = new StreamReader(@"../../../../usuarios.log", miCodificacion))
            {
                info = sr.ReadToEnd();
            }

            richTxtBoxInfoLogueos.ReadOnly = true;
            richTxtBoxInfoLogueos.Text = info;
        }
    }
}
