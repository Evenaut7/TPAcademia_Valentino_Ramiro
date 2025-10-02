namespace VistaEscritorio
{
    partial class ABMmaterias
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
            dgvMaterias = new DataGridView();
            listarMaterias = new Button();
            agegarMaterias = new Button();
            eliminarMaterias = new Button();
            modificarMateria = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMaterias
            // 
            dgvMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterias.Dock = DockStyle.Fill;
            dgvMaterias.Location = new Point(0, 0);
            dgvMaterias.Name = "dgvMaterias";
            dgvMaterias.Size = new Size(784, 461);
            dgvMaterias.TabIndex = 0;
            dgvMaterias.CellContentClick += dgvMaterias_CellContentClick;
            // 
            // listarMaterias
            // 
            listarMaterias.Dock = DockStyle.Right;
            listarMaterias.Location = new Point(554, 5);
            listarMaterias.Name = "listarMaterias";
            listarMaterias.Size = new Size(75, 30);
            listarMaterias.TabIndex = 1;
            listarMaterias.Text = "Listar";
            listarMaterias.UseVisualStyleBackColor = true;
            listarMaterias.Click += listarMaterias_Click;
            // 
            // agegarMaterias
            // 
            agegarMaterias.Dock = DockStyle.Right;
            agegarMaterias.Location = new Point(629, 5);
            agegarMaterias.Name = "agegarMaterias";
            agegarMaterias.Size = new Size(75, 30);
            agegarMaterias.TabIndex = 2;
            agegarMaterias.Text = "Agregar";
            agegarMaterias.UseVisualStyleBackColor = true;
            agegarMaterias.Click += agegarMaterias_Click;
            // 
            // eliminarMaterias
            // 
            eliminarMaterias.Dock = DockStyle.Right;
            eliminarMaterias.Location = new Point(479, 5);
            eliminarMaterias.Name = "eliminarMaterias";
            eliminarMaterias.Size = new Size(75, 30);
            eliminarMaterias.TabIndex = 3;
            eliminarMaterias.Text = "Eliminar";
            eliminarMaterias.UseVisualStyleBackColor = true;
            eliminarMaterias.Click += eliminarMaterias_Click;
            // 
            // modificarMateria
            // 
            modificarMateria.Dock = DockStyle.Right;
            modificarMateria.Location = new Point(704, 5);
            modificarMateria.Name = "modificarMateria";
            modificarMateria.Size = new Size(75, 30);
            modificarMateria.TabIndex = 4;
            modificarMateria.Text = "Modificar";
            modificarMateria.UseVisualStyleBackColor = true;
            modificarMateria.Click += modificarMateria_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(eliminarMaterias);
            panel1.Controls.Add(listarMaterias);
            panel1.Controls.Add(agegarMaterias);
            panel1.Controls.Add(modificarMateria);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 421);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(784, 40);
            panel1.TabIndex = 5;
            // 
            // ABMmaterias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(panel1);
            Controls.Add(dgvMaterias);
            Name = "ABMmaterias";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Materias";
            Load += ABMmaterias_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMaterias;
        private Button listarMaterias;
        private Button agegarMaterias;
        private Button eliminarMaterias;
        private Button modificarMateria;
        private Panel panel1;
    }
}
