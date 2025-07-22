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
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).BeginInit();
            SuspendLayout();
            // 
            // dgvMaterias
            // 
            dgvMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterias.Location = new Point(12, 12);
            dgvMaterias.Name = "dgvMaterias";
            dgvMaterias.Size = new Size(626, 150);
            dgvMaterias.TabIndex = 0;
            // 
            // listarMaterias
            // 
            listarMaterias.Location = new Point(12, 241);
            listarMaterias.Name = "listarMaterias";
            listarMaterias.Size = new Size(75, 23);
            listarMaterias.TabIndex = 1;
            listarMaterias.Text = "Listar";
            listarMaterias.UseVisualStyleBackColor = true;
            listarMaterias.Click += listarMaterias_Click;
            // 
            // agegarMaterias
            // 
            agegarMaterias.Location = new Point(187, 241);
            agegarMaterias.Name = "agegarMaterias";
            agegarMaterias.Size = new Size(75, 23);
            agegarMaterias.TabIndex = 2;
            agegarMaterias.Text = "Agregar";
            agegarMaterias.UseVisualStyleBackColor = true;
            agegarMaterias.Click += agegarMaterias_Click;
            // 
            // eliminarMaterias
            // 
            eliminarMaterias.Location = new Point(563, 241);
            eliminarMaterias.Name = "eliminarMaterias";
            eliminarMaterias.Size = new Size(75, 23);
            eliminarMaterias.TabIndex = 3;
            eliminarMaterias.Text = "Eliminar";
            eliminarMaterias.UseVisualStyleBackColor = true;
            eliminarMaterias.Click += eliminarMaterias_Click;
            // 
            // modificarMateria
            // 
            modificarMateria.Location = new Point(381, 241);
            modificarMateria.Name = "modificarMateria";
            modificarMateria.Size = new Size(75, 23);
            modificarMateria.TabIndex = 4;
            modificarMateria.Text = "Modificar";
            modificarMateria.UseVisualStyleBackColor = true;
            modificarMateria.Click += modificarMateria_Click;
            // 
            // ABMmaterias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 289);
            Controls.Add(modificarMateria);
            Controls.Add(eliminarMaterias);
            Controls.Add(agegarMaterias);
            Controls.Add(listarMaterias);
            Controls.Add(dgvMaterias);
            Name = "ABMmaterias";
            Text = "Materias";
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMaterias;
        private Button listarMaterias;
        private Button agegarMaterias;
        private Button eliminarMaterias;
        private Button modificarMateria;
    }
}
