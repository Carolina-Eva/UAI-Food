namespace UAI_Food
{
    partial class Container
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            generarPedidoToolStripMenuItem = new ToolStripMenuItem();
            verMisOrdenesToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(834, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarPedidoToolStripMenuItem, verMisOrdenesToolStripMenuItem, logOutToolStripMenuItem });
            menuToolStripMenuItem.Image = Resource.icono;
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(66, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // generarPedidoToolStripMenuItem
            // 
            generarPedidoToolStripMenuItem.Name = "generarPedidoToolStripMenuItem";
            generarPedidoToolStripMenuItem.Size = new Size(180, 22);
            generarPedidoToolStripMenuItem.Text = "Generar Pedido";
            generarPedidoToolStripMenuItem.Click += generarPedidoToolStripMenuItem_Click;
            // 
            // verMisOrdenesToolStripMenuItem
            // 
            verMisOrdenesToolStripMenuItem.Name = "verMisOrdenesToolStripMenuItem";
            verMisOrdenesToolStripMenuItem.Size = new Size(180, 22);
            verMisOrdenesToolStripMenuItem.Text = "Ver mis Ordenes";
            verMisOrdenesToolStripMenuItem.Click += verMisOrdenesToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(180, 22);
            logOutToolStripMenuItem.Text = "LogOut";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // Container
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 561);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Container";
            Text = "Container";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem generarPedidoToolStripMenuItem;
        private ToolStripMenuItem verMisOrdenesToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
    }
}