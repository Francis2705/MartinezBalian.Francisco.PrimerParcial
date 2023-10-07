namespace CRUD_EmpresaElectronica
{
    partial class FrmVisualizadorUsuarios
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
            richTxtBoxInfoLogueos = new RichTextBox();
            SuspendLayout();
            // 
            // richTxtBoxInfoLogueos
            // 
            richTxtBoxInfoLogueos.Location = new Point(101, 73);
            richTxtBoxInfoLogueos.Name = "richTxtBoxInfoLogueos";
            richTxtBoxInfoLogueos.Size = new Size(616, 438);
            richTxtBoxInfoLogueos.TabIndex = 0;
            richTxtBoxInfoLogueos.Text = "";
            // 
            // FrmVisualizadorUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 584);
            Controls.Add(richTxtBoxInfoLogueos);
            Name = "FrmVisualizadorUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmVisualizadorUsuarios";
            Load += FrmVisualizadorUsuarios_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTxtBoxInfoLogueos;
    }
}