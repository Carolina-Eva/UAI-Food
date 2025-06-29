namespace UAI_Food
{
    partial class LogIn
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
            btnLogIn = new Button();
            tbUsuario = new TextBox();
            tbPass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLogIn
            // 
            btnLogIn.Location = new Point(494, 281);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(121, 53);
            btnLogIn.TabIndex = 0;
            btnLogIn.Text = "LogIn";
            btnLogIn.UseVisualStyleBackColor = true;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // tbUsuario
            // 
            tbUsuario.Location = new Point(439, 155);
            tbUsuario.Name = "tbUsuario";
            tbUsuario.Size = new Size(242, 23);
            tbUsuario.TabIndex = 1;
            // 
            // tbPass
            // 
            tbPass.Location = new Point(439, 231);
            tbPass.Name = "tbPass";
            tbPass.Size = new Size(242, 23);
            tbPass.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(439, 137);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(439, 213);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(94, 110);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(241, 224);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(61, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(673, 322);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "LogIn";
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPass);
            Controls.Add(tbUsuario);
            Controls.Add(btnLogIn);
            Controls.Add(groupBox1);
            Name = "LogIn";
            Text = "LogIn";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogIn;
        private TextBox tbUsuario;
        private TextBox tbPass;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
    }
}