namespace VistaEscritorio
{
    partial class ModificarPlan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            idBox = new TextBox();
            descBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // idBox
            // 
            idBox.Location = new Point(120, 20);
            idBox.Name = "idBox";
            idBox.ReadOnly = true;
            idBox.Size = new Size(200, 23);
            idBox.TabIndex = 0;
            // 
            // descBox
            // 
            descBox.Location = new Point(120, 60);
            descBox.Name = "descBox";
            descBox.Size = new Size(200, 23);
            descBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 23);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 2;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 63);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 3;
            label2.Text = "Descripción";
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(200, 100);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 4;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // ModificarPlan
            // 
            ClientSize = new Size(370, 150);
            Controls.Add(idBox);
            Controls.Add(descBox);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(cancelarButton);
            Name = "ModificarPlan";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modificar Plan";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox idBox;
        private TextBox descBox;
        private Label label1;
        private Label label2;
        private Button modificarPlan;
        private Button cancelarButton;
    }
}
