using BE;
using BLL;
using SERVICES;

namespace UAI_Food
{
    public partial class LogIn : Form
    {
        UsuarioManager userLogin = new UsuarioManager();
        public LogIn()
        {
            InitializeComponent();
            pictureBox1.Image = Resource.burgerLogo;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            string usuario = tbUsuario.Text.Trim();
            string password = tbPass.Text.Trim();

            var result = await userLogin.AttemptLogin(usuario, password);
            var userId = await userLogin.GetUsuarioId(usuario);

            Usuario user = new Usuario(userId, usuario);

            if (result)
            {
                LogInService.GetInstance.Login(user);
                MessageBox.Show($"Bienvenido", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var mainForm = new Container();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
