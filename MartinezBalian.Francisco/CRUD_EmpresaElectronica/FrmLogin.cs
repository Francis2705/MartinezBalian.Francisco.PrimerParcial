using Electronicos;
using System.Text;
using System.Text.Json;

namespace CRUD_EmpresaElectronica
{
    public partial class FrmLogin : Form
    {
        private List<UsuarioElectronico> listaUsuarios = new List<UsuarioElectronico>();
        static UsuarioElectronico usuarioLogueado = null;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e) //Aca oculto el de rellenar automaticamente
        {

            if (File.Exists(@"../../../../MOCK_DATA.json"))
            {
                using (StreamReader lectorJson = new StreamReader(@"../../../../MOCK_DATA.json"))
                {
                    string jsonString = lectorJson.ReadToEnd();

                    this.listaUsuarios = JsonSerializer.Deserialize<List<UsuarioElectronico>>(jsonString);
                }
            }
            else
            {
                MessageBox.Show("No se encontro el path del archivo");
                Application.Exit();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool usuarioValido = false;

            foreach (UsuarioElectronico usuario in listaUsuarios)
            {
                if (usuario.correo == txtBoxCorreo.Text && usuario.clave == txtBoxClave.Text)
                {
                    usuarioValido = true;
                    usuarioLogueado = usuario;
                    break;
                }
            }
            if (usuarioValido)
            {
                Encoding miCodificacion = Encoding.UTF8;
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Apellido: {usuarioLogueado.apellido}");
                sb.AppendLine($"Nombre: {usuarioLogueado.nombre}");
                sb.AppendLine($"Legajo: {usuarioLogueado.legajo}");
                sb.AppendLine($"Correo: {usuarioLogueado.correo}");
                sb.AppendLine($"Clave: {usuarioLogueado.clave}");
                sb.AppendLine($"Perfil: {usuarioLogueado.perfil}");
                sb.AppendLine($"Fecha de logueo: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                sb.ToString();

                using (StreamWriter sw = new StreamWriter(@"../../../../usuarios.log", true, miCodificacion))
                {
                    sw.WriteLine(sb);
                }

                this.Hide();
                FrmPrincipalEmpresa frmPrincipalEmpresa = new FrmPrincipalEmpresa();
                if (frmPrincipalEmpresa.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    txtBoxCorreo.Text = string.Empty;
                    txtBoxClave.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Nombre de usuario o clave incorrectos.");
            }
        }

        private void btnRellenar_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int i = random.Next(0, listaUsuarios.Count);
            txtBoxCorreo.Text = listaUsuarios[i].correo;
            txtBoxClave.Text = listaUsuarios[i].clave;
        }

        public static UsuarioElectronico GetUsuarioElectronico()
        {
            return FrmLogin.usuarioLogueado;
        }
    }
}