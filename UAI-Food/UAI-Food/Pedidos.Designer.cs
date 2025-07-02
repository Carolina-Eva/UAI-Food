namespace UAI_Food
{
    partial class Pedidos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbCombos = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            clbAdicionales = new CheckedListBox();
            label3 = new Label();
            btnAgregar = new Button();
            lvPedido = new ListView();
            btnCancelar = new Button();
            btnPedido = new Button();
            lblTotal = new Label();
            lblBienvenido = new Label();
            SuspendLayout();
            // 
            // cbCombos
            // 
            cbCombos.FormattingEnabled = true;
            cbCombos.Location = new Point(30, 111);
            cbCombos.Name = "cbCombos";
            cbCombos.Size = new Size(227, 23);
            cbCombos.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 93);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 1;
            label1.Text = "Seleccione el Combo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 179);
            label2.Name = "label2";
            label2.Size = new Size(145, 15);
            label2.TabIndex = 2;
            label2.Text = "Seleccione los Adicionales";
            // 
            // clbAdicionales
            // 
            clbAdicionales.FormattingEnabled = true;
            clbAdicionales.Location = new Point(30, 203);
            clbAdicionales.Name = "clbAdicionales";
            clbAdicionales.Size = new Size(227, 166);
            clbAdicionales.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(30, 9);
            label3.Name = "label3";
            label3.Size = new Size(462, 45);
            label3.TabIndex = 4;
            label3.Text = "Sistema de Pedidos - UAI-Food";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(30, 384);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(227, 45);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lvPedido
            // 
            lvPedido.Location = new Point(301, 125);
            lvPedido.Name = "lvPedido";
            lvPedido.Size = new Size(473, 244);
            lvPedido.TabIndex = 6;
            lvPedido.UseCompatibleStateImageBehavior = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(301, 384);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(137, 45);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnPedido
            // 
            btnPedido.Location = new Point(649, 384);
            btnPedido.Name = "btnPedido";
            btnPedido.Size = new Size(125, 45);
            btnPedido.TabIndex = 8;
            btnPedido.Text = "Enviar Pedido";
            btnPedido.UseVisualStyleBackColor = true;
            btnPedido.Click += btnPedido_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(301, 98);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(125, 15);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total del Pedido: $0.00";
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Location = new Point(612, 32);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(0, 15);
            lblBienvenido.TabIndex = 10;
            // 
            // Pedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblBienvenido);
            Controls.Add(lblTotal);
            Controls.Add(btnPedido);
            Controls.Add(btnCancelar);
            Controls.Add(lvPedido);
            Controls.Add(btnAgregar);
            Controls.Add(label3);
            Controls.Add(clbAdicionales);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbCombos);
            Name = "Pedidos";
            Text = "Form1";
            Load += Pedidos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbCombos;
        private Label label1;
        private Label label2;
        private CheckedListBox clbAdicionales;
        private Label label3;
        private Button btnAgregar;
        private ListView lvPedido;
        private Button btnCancelar;
        private Button btnPedido;
        private Label lblTotal;
        private Label lblBienvenido;
    }
}
