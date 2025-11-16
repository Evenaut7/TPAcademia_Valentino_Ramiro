namespace VistaEscritorio
{
    partial class ModificarComision
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer Generated Code

        private void InitializeComponent()
        {
            nombreBox = new TextBox();
            anioEspecialidadBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            planComboBox = new ComboBox();
            modificarComision = new Button();
            cancelarButton = new Button();
            lblEstado = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            lblTitulo = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // nombreBox
            // 
            nombreBox.Location = new Point(176, 71);
            nombreBox.Name = "nombreBox";
            nombreBox.Size = new Size(228, 27);
            nombreBox.TabIndex = 0;
            // 
            // anioEspecialidadBox
            // 
            anioEspecialidadBox.DropDownStyle = ComboBoxStyle.DropDownList;
            anioEspecialidadBox.Location = new Point(176, 111);
            anioEspecialidadBox.Name = "anioEspecialidadBox";
            anioEspecialidadBox.Size = new Size(228, 28);
            anioEspecialidadBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 75);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.Text = "Nombre: *";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 115);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.Text = "Año Especialidad: *";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 155);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.Text = "Plan: *";
            // 
            // planComboBox
            // 
            planComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            planComboBox.Location = new Point(176, 151);
            planComboBox.Name = "planComboBox";
            planComboBox.Size = new Size(342, 28);
            planComboBox.TabIndex = 2;
            // 
            // modificarComision
            // 
            modificarComision.Location = new Point(270, 10);
            modificarComision.Name = "modificarComision";
            modificarComision.Size = new Size(98, 30);
            modificarComision.TabIndex = 3;
            modificarComision.Text = "Modificar";
            modificarComision.UseVisualStyleBackColor = true;
            modificarComision.Click += modificarComision_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(374, 10);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 30);
            cancelarButton.TabIndex = 4;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(10, 17);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 20);
            // 
            // panel1
            // 
            panel1.Controls.Add(lblEstado);
            panel1.Controls.Add(modificarComision);
            panel1.Controls.Add(cancelarButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 220);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(530, 58);
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(lblTitulo);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(11, 13, 11, 13);
            panel2.Size = new Size(530, 58);
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(11, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(239, 32);
            lblTitulo.Text = "Modificar Comisión";
            // 
            // ModificarComision
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 278);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(planComboBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(anioEspecialidadBox);
            Controls.Add(nombreBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modificar Comisión";
            Load += ModificarComision_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nombreBox;
        private ComboBox anioEspecialidadBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox planComboBox;
        private Button modificarComision;
        private Button cancelarButton;
        private Label lblEstado;
        private Panel panel1;
        private Panel panel2;
        private Label lblTitulo;
    }
}
