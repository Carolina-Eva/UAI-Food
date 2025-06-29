using BE;
using BLL;

namespace UAI_Food
{
    public partial class Form1 : Form
    {
        List<string> agregados = new List<string> {"Tomate", "Carne", "Queso", "Papa" };
        List<string> combos = new List<string> { "Seleccionar", "Combo Basico", "Combo Especial", "Combo Familiar" };
        Usuario Usuario = new Usuario(1, "UsuarioMock");
        Pedido? pedido;
        List<Pedido> pedidos = new List<Pedido>();
        private PedidoManager PedidoManager = new PedidoManager();

        public Form1()
        {
            InitializeComponent();
            IniciarlizarProductos();
        }

        private void IniciarlizarProductos()
        {
            cbCombos.DataSource = null;
            cbCombos.DataSource = combos;

            clbAdicionales.DataSource = null;
            clbAdicionales.DataSource = agregados;

            lvPedido.Items.Clear();
            lvPedido.View = View.Details;
            lvPedido.FullRowSelect = true;
            lvPedido.GridLines = true;

            lvPedido.Columns.Add("Combo", 150);
            lvPedido.Columns.Add("Agregados", 250);
            lvPedido.Columns.Add("Precio Total", 100);
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
                    else if (agregado == "Tomate") { combo = new Tomate(combo);}
                }
                pedido = new Pedido();

                pedido.Combo = combo;
                pedido.CostoTotal = combo.Costo;
                pedido.Usuario = Usuario;
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


            lvPedido.Items.Clear();
        }

        private void btnPedido_Click(object sender, EventArgs e)
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

            if (result == DialogResult.OK) {
                MessageBox.Show("Pedido enviado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try { 
                    PedidoManager.CrearPedido(pedido);
                    pedidos.Clear();
                    lvPedido.Items.Clear();
                    cbCombos.SelectedIndex = 0;
                    clbAdicionales.ClearSelected();
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
