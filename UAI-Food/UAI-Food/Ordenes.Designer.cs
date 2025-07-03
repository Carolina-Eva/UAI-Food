namespace UAI_Food
{
    partial class Ordenes
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
            lblTitulo = new Label();
            dgvOrdenes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(40, 26);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(0, 15);
            lblTitulo.TabIndex = 0;
            // 
            // dgvOrdenes
            // 
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdenes.Location = new Point(12, 75);
            dgvOrdenes.Name = "dgvOrdenes";
            dgvOrdenes.Size = new Size(766, 347);
            dgvOrdenes.TabIndex = 1;
            // 
            // Ordenes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvOrdenes);
            Controls.Add(lblTitulo);
            Name = "Ordenes";
            Text = "Pedidos";
            Load += Ordenes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvOrdenes;
    }
}