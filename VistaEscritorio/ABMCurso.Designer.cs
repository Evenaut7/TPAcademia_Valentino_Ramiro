namespace VistaEscritorio
{
    partial class ABMCurso
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            listarButton = new Button();
            panel1 = new Panel();
            txtMateria = new TextBox();
            txtComision = new TextBox();
            btnBuscar = new Button();
            lblMateria = new Label();
            lblComision = new Label();
            panel2 = new Panel();
            dgvCurso = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurso).BeginInit();
            SuspendLayout();
            // 
            // eliminarButton
            // 
            eliminarButton.Dock = DockStyle.Right;
            eliminarButton.Location = new Point(704, 5);
            eliminarButton.Margin = new Padding(20);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(75, 30);
            eliminarButton.TabIndex = 0;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click_1;
            // 
            // modificarButton
            // 
            modificarButton.Dock = DockStyle.Right;
            modificarButton.Location = new Point(629, 5);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(75, 30);
            modificarButton.TabIndex = 1;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Dock = DockStyle.Right;
            agregarButton.Location = new Point(554, 5);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(75, 30);
            agregarButton.TabIndex = 2;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // listarButton
            // 
            listarButton.Dock = DockStyle.Right;
            listarButton.Location = new Point(479, 5);
            listarButton.Name = "listarButton";
            listarButton.Size = new Size(75, 30);
            listarButton.TabIndex = 3;
            listarButton.Text = "Listar";
            listarButton.UseVisualStyleBackColor = true;
            listarButton.Click += listarButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(listarButton);
            panel1.Controls.Add(agregarButton);
            panel1.Controls.Add(modificarButton);
            panel1.Controls.Add(eliminarButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 421);
            panel1.Margin = new Padding(10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(784, 40);
            panel1.TabIndex = 3;
            // 
            // txtMateria
            // 
            txtMateria.Location = new Point(68, 11);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new Size(150, 23);
            txtMateria.TabIndex = 1;
            // 
            // txtComision
            // 
            txtComision.Location = new Point(300, 11);
            txtComision.Name = "txtComision";
            txtComision.Size = new Size(150, 23);
            txtComision.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(464, 10);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 25);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Location = new Point(12, 14);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(50, 15);
            lblMateria.TabIndex = 0;
            lblMateria.Text = "Materia:";
            // 
            // lblComision
            // 
            lblComision.AutoSize = true;
            lblComision.Location = new Point(233, 14);
            lblComision.Name = "lblComision";
            lblComision.Size = new Size(61, 15);
            lblComision.TabIndex = 2;
            lblComision.Text = "Comisión:";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(btnBuscar);
            panel2.Controls.Add(lblMateria);
            panel2.Controls.Add(txtMateria);
            panel2.Controls.Add(txtComision);
            panel2.Controls.Add(lblComision);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(784, 38);
            panel2.TabIndex = 5;
            // 
            // dgvCurso
            // 
            dgvCurso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurso.Dock = DockStyle.Fill;
            dgvCurso.Location = new Point(0, 38);
            dgvCurso.Name = "dgvCurso";
            dgvCurso.Size = new Size(784, 383);
            dgvCurso.TabIndex = 5;
            // 
            // ABMCurso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(dgvCurso);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ABMCurso";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ABM Curso";
            Load += ABMCurso_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
        private Button listarButton;
        private Panel panel1;

        private TextBox txtMateria;
        private TextBox txtComision;
        private Button btnBuscar;
        private Label lblMateria;
        private Label lblComision;
        private Panel panel2;
        private DataGridView dgvCurso;
    }
}
