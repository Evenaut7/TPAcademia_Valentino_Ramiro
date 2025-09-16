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
            especialidadLabel = new Label();
            idEspecialidadBox = new ComboBox();
            SuspendLayout();
            // 
            // descBox
            // 
            descBox.Location = new Point(120, 30);
            descBox.Name = "descBox";
            descBox.Size = new Size(200, 23);
            descBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 33);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 1;
            label1.Text = "Descripción";
            // 
            // agregarPlan
            // 
            agregarPlan.Location = new Point(255, 143);
            agregarPlan.Name = "agregarPlan";
            agregarPlan.Size = new Size(75, 23);
            agregarPlan.TabIndex = 2;
            agregarPlan.Text = "Agregar";
            agregarPlan.UseVisualStyleBackColor = true;
            agregarPlan.Click += agregarPlan_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(336, 143);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 3;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // especialidadLabel
            // 
            especialidadLabel.AutoSize = true;
            especialidadLabel.Location = new Point(30, 76);
            especialidadLabel.Name = "especialidadLabel";
            especialidadLabel.Size = new Size(72, 15);
            especialidadLabel.TabIndex = 4;
            especialidadLabel.Text = "Especialidad";
            especialidadLabel.Click += label2_Click;
            // 
            // idEspecialidadBox
            // 
            idEspecialidadBox.DropDownStyle = ComboBoxStyle.DropDownList;
            idEspecialidadBox.FormattingEnabled = true;
            idEspecialidadBox.Location = new Point(120, 73);
            idEspecialidadBox.Name = "idEspecialidadBox";
            idEspecialidadBox.Size = new Size(121, 23);
            idEspecialidadBox.TabIndex = 14;
            idEspecialidadBox.SelectedIndexChanged += idEspecialidadBox_SelectedIndexChanged;
            // 
            // CargaPlanes
            // 
            ClientSize = new Size(423, 196);
            Controls.Add(idEspecialidadBox);
            Controls.Add(especialidadLabel);
            Controls.Add(descBox);
            Controls.Add(label1);
            Controls.Add(agregarPlan);
            Controls.Add(cancelarButton);
            Name = "CargaPlanes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar Plan";
            Load += CargaPlanes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox descBox;
        private Label label1;
        private Button agregarPlan;
        private Button cancelarButton;
        private Label especialidadLabel;
        private ComboBox idEspecialidadBox;
    }
}
