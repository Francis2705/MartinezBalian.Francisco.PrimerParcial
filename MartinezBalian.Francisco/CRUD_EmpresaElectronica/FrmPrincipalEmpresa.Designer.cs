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
            SuspendLayout();
            // 
            // btnVisualizadorUsuariosLogueo
            // 
            btnVisualizadorUsuariosLogueo.Location = new Point(371, 248);
            btnVisualizadorUsuariosLogueo.Name = "btnVisualizadorUsuariosLogueo";
            btnVisualizadorUsuariosLogueo.Size = new Size(189, 87);
            btnVisualizadorUsuariosLogueo.TabIndex = 0;
            btnVisualizadorUsuariosLogueo.Text = "Ver registro de usuarios";
            btnVisualizadorUsuariosLogueo.UseVisualStyleBackColor = true;
            btnVisualizadorUsuariosLogueo.Click += btnVisualizadorUsuariosLogueo_Click;
            // 
            // FrmPrincipalEmpresa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVisualizadorUsuariosLogueo);
            Name = "FrmPrincipalEmpresa";
            Text = "FrmPrincipalEmpresa";
            FormClosing += FrmPrincipalEmpresa_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button btnVisualizadorUsuariosLogueo;
    }
}