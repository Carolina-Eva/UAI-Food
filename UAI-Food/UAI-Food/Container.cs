using BE;
using Microsoft.VisualBasic.Logging;
using SERVICES;

namespace UAI_Food
{
    public partial class Container : Form
    {
        public Container()
        {
            InitializeComponent();
        }

        private void generarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? form = Application.OpenForms["Pedidos"];
            if (form == null)
            {
                var perdidos = new Pedidos();
                perdidos.Name = "Pedidos";
                perdidos.MdiParent = this;
                perdidos.Show();
            }
            else
            {
                form.BringToFront(); 
            }
        }

        private void verMisOrdenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? form = Application.OpenForms["Ordenes"];
            if (form == null)
            {
                var ordenes = new Ordenes();
                ordenes.Name = "Ordenes";
                ordenes.MdiParent = this;
                ordenes.Show();
            }
            else
            {
                form.BringToFront(); 
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogInService.GetInstance.Logout();
            var login = new LogIn();
            login.Name = "LogIn";
            login.Show();
            this.Hide();
        }
    }
}
