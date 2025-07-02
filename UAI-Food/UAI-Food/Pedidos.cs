using BE;
using BLL;
using SERVICES;

namespace UAI_Food
{
    public partial class Pedidos : Form
    {
        List<Producto> agregados = new List<Producto>();
        List<Producto> combos = new List<Producto>();

        BE.Pedido? pedido;
        List<BE.Pedido> pedidos = new List<BE.Pedido>();
        private PedidoManager PedidoManager = new PedidoManager();
        private ProductoManager ProductoManager = new ProductoManager();

        public Pedidos()
        {
            InitializeComponent();
            lblBienvenido.Text = string.Empty;
            lblBienvenido.Text = "Bienvenido " + LogInService.GetInstance.User.Nombre;
            this.Load += Pedidos_Load;
        }

        private async void Pedidos_Load(object sender, EventArgs e)
        {
            await IniciarlizarProductos();  
        }


        private async Task IniciarlizarProductos()
        {
            agregados = await ProductoManager.ObtenerAgregados();
            combos = await ProductoManager.ObtenerCombos();

            cbCombos.DataSource = null;
            cbCombos.DataSource = combos;
            cbCombos.DisplayMember = "Nombre";

            clbAdicionales.DataSource = null;
            clbAdicionales.DataSource = agregados;
            clbAdicionales.DisplayMember = "Nombre";

            lvPedido.Items.Clear();
            lvPedido.View = View.Details;
            lvPedido.FullRowSelect = true;
            lvPedido.GridLines = true;

            lvPedido.Columns.Add("Combo", 150);
            lvPedido.Columns.Add("Agregados", 200);
            lvPedido.Columns.Add("Subtotal", 100);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbCombos.SelectedItem != null && cbCombos.SelectedItem.ToString() != "Seleccionar")
            {
                Combo combo = null;

                if (cbCombos.SelectedItem.ToString() == "Combo Basico")
                {
                    combo = new ComboBasico();
                }
                else if (cbCombos.SelectedItem.ToString() == "Combo Especial")
                {
                    combo = new ComboEspecial();
                }
                else if (cbCombos.SelectedItem.ToString() == "Combo Familiar")
                {
                    combo = new ComboFamiliar();
                }

                if (combo != null)
                {
                    GenerarPedido(combo);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un combo antes de agregar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void GenerarPedido(Combo combo)
        {
            if (clbAdicionales.CheckedItems.Count > 0)
            {
                foreach (string agregado in clbAdicionales.CheckedItems)
                {
                    if (agregado == "Papa") { combo = new Papa(combo); }
                    else if (agregado == "Carne") { combo = new Carne(combo); }
                    else if (agregado == "Queso") { combo = new Queso(combo); }
                    else if (agregado == "Tomate") { combo = new Tomate(combo); }
                }
                pedido = new BE.Pedido();

                pedido.Combo = combo;
                pedido.CostoTotal = combo.Costo;
                pedido.Usuario = LogInService.GetInstance.User;
                pedido.Fecha = DateTime.Now;
                pedido.Agregados = clbAdicionales.CheckedItems.Cast<string>().ToList();

                pedidos.Add(pedido);
                double totalPedido = pedidos.Sum(p => p.CostoTotal);
                lblTotal.Text = $"Total del Pedido: {totalPedido:C2}";
            }
            else
            {
                pedido.Combo = null;
            }
            mostrarComboEnLista(combo);
        }
        private void mostrarComboEnLista(Combo combo)
        {
            ListViewItem item = new ListViewItem(combo.Descripcion);
            string agregadosSeleccionados = string.Join(", ", clbAdicionales.CheckedItems.Cast<string>());
            item.SubItems.Add(agregadosSeleccionados);
            item.SubItems.Add(combo.Costo.ToString("C2"));
            lvPedido.Items.Add(item);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cbCombos.DataSource = null;
            cbCombos.DataSource = combos;
            cbCombos.SelectedIndex = 0;

            clbAdicionales.DataSource = null;
            clbAdicionales.DataSource = agregados;

            lblTotal.Text = "Total del Pedido: $0.00";
            lvPedido.Items.Clear();
        }

        private async void btnPedido_Click(object sender, EventArgs e)
        {
            if (pedidos.Count == 0)
            {
                MessageBox.Show("No hay pedidos para enviar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pedido == null)
            {
                MessageBox.Show("El pedido actual es nulo. Por favor, cree un pedido antes de enviarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double totalPedido = pedidos.Sum(p => p.CostoTotal);
            var result = MessageBox.Show(
                $"¿Desea enviar el pedido?\nTotal: ${totalPedido}",
                "Pedido",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                try
                {
                    var pedidosGenerados = 0;
                    foreach (var p in pedidos)
                    {
                        pedidosGenerados = await PedidoManager.CrearPedido(p);
                    }

                    pedidos.Clear();
                    lvPedido.Items.Clear();

                    cbCombos.DataSource = null;
                    cbCombos.DataSource = combos;
                    cbCombos.SelectedIndex = 0;

                    clbAdicionales.DataSource = null;
                    clbAdicionales.DataSource = agregados;

                    lblTotal.Text = "Total del Pedido: $0.00";
                    MessageBox.Show("Pedido enviado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al enviar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Pedido no enviado.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
