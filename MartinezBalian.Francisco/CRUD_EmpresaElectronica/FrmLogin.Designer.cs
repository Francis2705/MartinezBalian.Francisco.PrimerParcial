using Electronicos;

namespace CRUD_EmpresaElectronica
{
    partial class FrmLogin
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
            txtBoxCorreo = new TextBox();
            txtBoxClave = new TextBox();
            btnIngresar = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtBoxCorreo
            // 
            txtBoxCorreo.Location = new Point(228, 96);
            txtBoxCorreo.Name = "txtBoxCorreo";
            txtBoxCorreo.Size = new Size(300, 27);
            txtBoxCorreo.TabIndex = 0;
            // 
            // txtBoxClave
            // 
            txtBoxClave.Location = new Point(228, 167);
            txtBoxClave.Name = "txtBoxClave";
            txtBoxClave.Size = new Size(258, 27);
            txtBoxClave.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(286, 326);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(173, 56);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(56, 319);
            button1.Name = "button1";
            button1.Size = new Size(148, 137);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 693);
            Controls.Add(button1);
            Controls.Add(btnIngresar);
            Controls.Add(txtBoxClave);
            Controls.Add(txtBoxCorreo);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += FrmLogin_FormClosing;
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxCorreo;
        private TextBox txtBoxClave;
        private Button btnIngresar;
        private Button button1;
    }
}