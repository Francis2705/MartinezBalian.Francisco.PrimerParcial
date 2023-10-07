namespace CRUD_EmpresaElectronica
{
    partial class FrmPrincipalEmpresa
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
            btnVisualizadorUsuariosLogueo = new Button();
            lblUsuarioInfo = new Label();
            SuspendLayout();
            // 
            // btnVisualizadorUsuariosLogueo
            // 
            btnVisualizadorUsuariosLogueo.Location = new Point(43, 313);
            btnVisualizadorUsuariosLogueo.Name = "btnVisualizadorUsuariosLogueo";
            btnVisualizadorUsuariosLogueo.Size = new Size(189, 87);
            btnVisualizadorUsuariosLogueo.TabIndex = 0;
            btnVisualizadorUsuariosLogueo.Text = "Ver registro de usuarios";
            btnVisualizadorUsuariosLogueo.UseVisualStyleBackColor = true;
            btnVisualizadorUsuariosLogueo.Click += btnVisualizadorUsuariosLogueo_Click;
            // 
            // lblUsuarioInfo
            // 
            lblUsuarioInfo.AutoSize = true;
            lblUsuarioInfo.Location = new Point(651, 9);
            lblUsuarioInfo.Name = "lblUsuarioInfo";
            lblUsuarioInfo.Size = new Size(85, 20);
            lblUsuarioInfo.TabIndex = 1;
            lblUsuarioInfo.Text = "InfoUsuario";
            lblUsuarioInfo.TextAlign = ContentAlignment.TopRight;
            // 
            // FrmPrincipalEmpresa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblUsuarioInfo);
            Controls.Add(btnVisualizadorUsuariosLogueo);
            Name = "FrmPrincipalEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPrincipalEmpresa";
            FormClosing += FrmPrincipalEmpresa_FormClosing;
            Load += FrmPrincipalEmpresa_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVisualizadorUsuariosLogueo;
        private Label lblUsuarioInfo;
    }
}