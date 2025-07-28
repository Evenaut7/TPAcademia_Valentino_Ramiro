namespace VistaEscritorio
{
    partial class MenuABM
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
            label1 = new Label();
            materiasButton = new Button();
            planesButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(434, 65);
            label1.TabIndex = 0;
            label1.Text = "Seleccione un ABM";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // materiasButton
            // 
            materiasButton.Font = new Font("Segoe UI", 12F);
            materiasButton.Location = new Point(244, 169);
            materiasButton.Name = "materiasButton";
            materiasButton.Size = new Size(108, 71);
            materiasButton.TabIndex = 1;
            materiasButton.Text = "Materias";
            materiasButton.UseVisualStyleBackColor = true;
            materiasButton.Click += materiasButton_Click;
            // 
            // planesButton
            // 
            planesButton.Font = new Font("Segoe UI", 12F);
            planesButton.Location = new Point(110, 169);
            planesButton.Name = "planesButton";
            planesButton.Size = new Size(108, 71);
            planesButton.TabIndex = 2;
            planesButton.Text = "Planes";
            planesButton.UseVisualStyleBackColor = true;
            planesButton.Click += planesButton_Click;
            // 
            // MenuABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 277);
            Controls.Add(planesButton);
            Controls.Add(materiasButton);
            Controls.Add(label1);
            Name = "MenuABM";
            Text = "MenuABM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button materiasButton;
        private Button planesButton;
    }
}