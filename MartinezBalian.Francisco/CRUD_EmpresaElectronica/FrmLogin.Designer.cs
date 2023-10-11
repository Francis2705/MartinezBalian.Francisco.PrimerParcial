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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            txtBoxCorreo = new TextBox();
            txtBoxClave = new TextBox();
            btnIngresar = new Button();
            btnRellenar = new Button();
            SuspendLayout();
            // 
            // txtBoxCorreo
            // 
            txtBoxCorreo.Location = new Point(228, 96);
            txtBoxCorreo.Name = "txtBoxCorreo";
            txtBoxCorreo.PlaceholderText = "Ingrese su usuario";
            txtBoxCorreo.Size = new Size(300, 27);
            txtBoxCorreo.TabIndex = 0;
            // 
            // txtBoxClave
            // 
            txtBoxClave.Location = new Point(228, 167);
            txtBoxClave.Name = "txtBoxClave";
            txtBoxClave.PasswordChar = '*';
            txtBoxClave.PlaceholderText = "Ingrese su clave";
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
            // btnRellenar
            // 
            btnRellenar.Location = new Point(56, 319);
            btnRellenar.Name = "btnRellenar";
            btnRellenar.Size = new Size(148, 137);
            btnRellenar.TabIndex = 3;
            btnRellenar.Text = "Relleno automatico";
            btnRellenar.UseVisualStyleBackColor = true;
            btnRellenar.Click += btnRellenar_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(605, 499);
            Controls.Add(btnRellenar);
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
        private Button btnRellenar;
    }
}