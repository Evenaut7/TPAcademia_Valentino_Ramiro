namespace VistaEscritorio
{
    partial class CargaPlanes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            descBox = new TextBox();
            label1 = new Label();
            agregarPlan = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // descBox
            // 
            descBox.Location = new Point(120, 30);
            descBox.Name = "descBox";
            descBox.Size = new Size(200, 23);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 33);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.Text = "Descripción";
            // 
            // agregarPlan
            // 
            agregarPlan.Location = new Point(70, 80);
            agregarPlan.Name = "agregarPlan";
            agregarPlan.Size = new Size(75, 23);
            agregarPlan.Text = "Agregar";
            agregarPlan.UseVisualStyleBackColor = true;
            agregarPlan.Click += agregarPlan_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(200, 80);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // CargaPlanes
            // 
            ClientSize = new Size(370, 130);
            Controls.Add(descBox);
            Controls.Add(label1);
            Controls.Add(agregarPlan);
            Controls.Add(cancelarButton);
            Name = "CargaPlanes";
            Text = "Agregar Plan";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox descBox;
        private Label label1;
        private Button agregarPlan;
        private Button cancelarButton;
    }
}
