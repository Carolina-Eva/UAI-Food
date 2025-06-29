namespace UAI_Food
{
    partial class Form1
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
            SuspendLayout();
            // 
            // cbCombos
            // 
            cbCombos.FormattingEnabled = true;
            cbCombos.Location = new Point(36, 85);
            cbCombos.Name = "cbCombos";
            cbCombos.Size = new Size(227, 23);
            cbCombos.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 67);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 1;
            label1.Text = "Seleccione el Combo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 153);
            label2.Name = "label2";
            label2.Size = new Size(145, 15);
            label2.TabIndex = 2;
            label2.Text = "Seleccione los Adicionales";
            // 
            // clbAdicionales
            // 
            clbAdicionales.FormattingEnabled = true;
            clbAdicionales.Location = new Point(36, 177);
            clbAdicionales.Name = "clbAdicionales";
            clbAdicionales.Size = new Size(227, 166);
            clbAdicionales.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(163, 9);
            label3.Name = "label3";
            label3.Size = new Size(462, 45);
            label3.TabIndex = 4;
            label3.Text = "Sistema de Pedidos - UAI-Food";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(36, 358);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(227, 45);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lvPedido
            // 
            lvPedido.Location = new Point(307, 99);
            lvPedido.Name = "lvPedido";
            lvPedido.Size = new Size(473, 244);
            lvPedido.TabIndex = 6;
            lvPedido.UseCompatibleStateImageBehavior = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(307, 358);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(137, 45);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnPedido
            // 
            btnPedido.Location = new Point(655, 358);
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
            lblTotal.Location = new Point(307, 72);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(38, 15);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "label4";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "Form1";
            Text = "Form1";
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
    }
}
