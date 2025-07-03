using BE;
using BLL;
using SERVICES;

namespace UAI_Food
{
    public partial class Pedidos : Form
    {
        List<ProductoBase> agregados = new List<ProductoBase>();
        List<ProductoBase> combos = new List<ProductoBase>();

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
            lvPedido.Columns.Clear();
            lvPedido.View = View.Details;
            lvPedido.FullRowSelect = true;
            lvPedido.GridLines = true;

            lvPedido.Columns.Add("Combo", 150);
            lvPedido.Columns.Add("Agregados", 200);
            lvPedido.Columns.Add("Subtotal", 100);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbCombos.SelectedItem is ProductoBase comboSeleccionado)
            {
                // Crear una instancia nueva del combo según su tipo real
                ProductoBase combo = CrearInstanciaCombo(comboSeleccionado);

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

        private ProductoBase CrearInstanciaCombo(ProductoBase baseCombo)
        {
            switch (baseCombo.Nombre.ToLower())
            {
                case "combo basico":
                    return new ComboBasico { Nombre = baseCombo.Nombre, Precio = baseCombo.Precio };
                case "combo especial":
                    return new ComboEspecial { Nombre = baseCombo.Nombre, Precio = baseCombo.Precio };
                case "combo familiar":
                    return new ComboFamiliar { Nombre = baseCombo.Nombre, Precio = baseCombo.Precio };
                default:
                    return null;
            }
        }

        private void GenerarPedido(ProductoBase combo)
        {
            foreach (var item in clbAdicionales.CheckedItems)
            {
                if (item is ProductoBase agregado)
                {
                    switch (agregado.Nombre.ToUpper())
                    {
                        case "PAPA":
                            combo = new Papa(combo, agregado.Nombre, agregado.Precio);
                            break;
                        case "CARNE":
                            combo = new Carne(combo, agregado.Nombre, agregado.Precio);
                            break;
                        case "QUESO":
                            combo = new Queso(combo, agregado.Nombre, agregado.Precio);
                            break;
                        case "TOMATE":
                            combo = new Tomate(combo, agregado.Nombre, agregado.Precio);
                            break;
                        default:
                            break;
                    }
                }
            }

            var pedidoNuevo = new Pedido
            {
                ComboDescription = combo.Nombre,
                CostoTotal = combo.Precio,
                Usuario = LogInService.GetInstance.User,
                Fecha = DateTime.Now
            };

            pedidos.Add(pedidoNuevo);

            double totalPedido = pedidos.Sum(p => p.CostoTotal);
            lblTotal.Text = $"Total del Pedido: {totalPedido:C2}";

            mostrarComboEnLista(combo);
        }


        private void mostrarComboEnLista(ProductoBase combo)
        {
            ListViewItem item = new ListViewItem(combo.Nombre);
            string agregadosSeleccionados = string.Join(", ",
                                                             clbAdicionales.CheckedItems
                                                                 .OfType<ProductoBase>()
                                                                 .Select(a => a.Nombre));
            item.SubItems.Add(agregadosSeleccionados);
            item.SubItems.Add(combo.Precio.ToString("C2"));
            lvPedido.Items.Add(item);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cbCombos.DataSource = null;
            cbCombos.DataSource = combos;
            cbCombos.DisplayMember = "Nombre";
            cbCombos.SelectedIndex = 0;

            clbAdicionales.DataSource = null;
            clbAdicionales.DataSource = agregados;
            clbAdicionales.DisplayMember = "Nombre";

            lblTotal.Text = "Total del Pedido: $0.00";
            lvPedido.Items.Clear();
            pedidos.Clear();
        }

        private async void btnPedido_Click(object sender, EventArgs e)
        {
            if (pedidos.Count == 0)
            {
                MessageBox.Show("No hay pedidos para enviar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pedidos == null)
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
                    cbCombos.DisplayMember = "Nombre";

                    clbAdicionales.DataSource = null;
                    clbAdicionales.DataSource = agregados;
                    clbAdicionales.DisplayMember = "Nombre";

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
