using Electronicos;
using System.Text;
using System.Text.Json;

namespace CRUD_EmpresaElectronica
{
    public partial class FrmLogin : Form
    {
        List<UsuarioElectronico> listaUsuarios = new List<UsuarioElectronico>();
        static UsuarioElectronico usuarioLogueado = null;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e) //Aca oculto el de rellenar automaticamente
        {
            //button1.Hide();

            if (File.Exists(@"../../../../MOCK_DATA.json"))
            {
                using (StreamReader lectorJson = new StreamReader(@"../../../../MOCK_DATA.json"))
                {
                    string jsonString = lectorJson.ReadToEnd();

                    listaUsuarios = JsonSerializer.Deserialize<List<UsuarioElectronico>>(jsonString);
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
                if (usuario.Correo == txtBoxCorreo.Text && usuario.Clave == txtBoxClave.Text)
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

                sb.AppendLine($"Apellido: {usuarioLogueado.Apellido}");
                sb.AppendLine($"Nombre: {usuarioLogueado.Nombre}");
                sb.AppendLine($"Legajo: {usuarioLogueado.Legajo}");
                sb.AppendLine($"Correo: {usuarioLogueado.Correo}");
                sb.AppendLine($"Clave: {usuarioLogueado.Clave}");
                sb.AppendLine($"Perfil: {usuarioLogueado.Perfil}");
                sb.AppendLine($"Fecha de logueo: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                sb.ToString();

                using (StreamWriter sw = new StreamWriter(@"../../../../usuarios.log", true, miCodificacion))
                {
                    sw.WriteLine(sb);
                }

                this.Hide();
                FrmPrincipalEmpresa frmPrincipalEmpresa = new FrmPrincipalEmpresa();
                frmPrincipalEmpresa.Show();
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
            txtBoxCorreo.Text = listaUsuarios[i].Correo;
            txtBoxClave.Text = listaUsuarios[i].Clave;
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public static UsuarioElectronico GetUsuarioElectronico()
        {
            return usuarioLogueado;
        }
    }
}