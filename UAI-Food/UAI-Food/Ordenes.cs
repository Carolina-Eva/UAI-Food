using BLL;
using SERVICES;
using BE;

namespace UAI_Food
{
    public partial class Ordenes : Form
    {
        private List<Pedido> listaDeOrdenes = new List<Pedido>();
        private PedidoManager PedidoManager = new PedidoManager();
        public Ordenes()
        {
            InitializeComponent();
            lblTitulo.Text = string.Empty;
            lblTitulo.Text = "Ordenes de  " + LogInService.GetInstance.User.Nombre;
            this.Load += Ordenes_Load;
        }

        private async Task CargarOrdenes()
        {
            try
            {
                int id = LogInService.GetInstance.User.Id;
                listaDeOrdenes = await PedidoManager.ListarPedidosPorUsuario(id);
                dgvOrdenes.DataSource = null;
                dgvOrdenes.Dock = DockStyle.Fill;
                var listaParaGrid = listaDeOrdenes.Select(p => new PedidoViewModel
                {
                    Id = p.Id,
                    Usuario = p.Usuario.Nombre,
                    Combo = p.ComboDescription,
                    Fecha = p.Fecha,
                    CostoTotal = p.CostoTotal
                }).ToList();

                dgvOrdenes.DataSource = listaParaGrid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las órdenes: " + ex.Message);
            }
        }

        private async void Ordenes_Load(object sender, EventArgs e)
        {
            await CargarOrdenes();
        }
    }
}
