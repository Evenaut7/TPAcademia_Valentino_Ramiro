namespace VistaEscritorio
{
    partial class ABMAlumno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public System.Windows.Forms.DataGridView dgvAlumnos;
        public System.Windows.Forms.Button listarButton;
        public System.Windows.Forms.Button agregarButton;
        public System.Windows.Forms.Button modificarButton;
        public System.Windows.Forms.Button eliminarButton;

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
            dgvAlumnos = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Dni = new DataGridViewTextBoxColumn();
            FechaNacimiento = new DataGridViewTextBoxColumn();
            Legajo = new DataGridViewTextBoxColumn();
            listarButton = new Button();
            agregarButton = new Button();
            modificarButton = new Button();
            eliminarButton = new Button();
            Usuario = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
            SuspendLayout();
            // 
            // dgvAlumnos
            // 
            dgvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlumnos.Columns.AddRange(new DataGridViewColumn[] { Id, Nombre, Apellido, Dni, FechaNacimiento, Legajo, Usuario });
            dgvAlumnos.Location = new Point(56, 26);
            dgvAlumnos.Name = "dgvAlumnos";
            dgvAlumnos.Size = new Size(744, 150);
            dgvAlumnos.TabIndex = 0;
            dgvAlumnos.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.Name = "Id";
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.Name = "Apellido";
            // 
            // Dni
            // 
            Dni.HeaderText = "DNI";
            Dni.Name = "Dni";
            // 
            // FechaNacimiento
            // 
            FechaNacimiento.HeaderText = "Fecha de Nacimiento";
            FechaNacimiento.Name = "FechaNacimiento";
            // 
            // Legajo
            // 
            Legajo.HeaderText = "Legajo";
            Legajo.Name = "Legajo";
            // 
            // listarButton
            // 
            listarButton.Location = new Point(56, 182);
            listarButton.Name = "listarButton";
            listarButton.Size = new Size(144, 30);
            listarButton.TabIndex = 1;
            listarButton.Text = "Listar";
            listarButton.UseVisualStyleBackColor = true;
            listarButton.Click += listarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(255, 182);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(144, 30);
            agregarButton.TabIndex = 2;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(451, 182);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(144, 30);
            modificarButton.TabIndex = 3;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(656, 182);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(144, 30);
            eliminarButton.TabIndex = 4;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // Usuario
            // 
            Usuario.HeaderText = "Usuario";
            Usuario.Name = "Usuario";
            // 
            // ABMAlumno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 426);
            Controls.Add(dgvAlumnos);
            Controls.Add(listarButton);
            Controls.Add(agregarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Name = "ABMAlumno";
            Text = "ABMAlumno";
            Load += ABMAlumno_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Dni;
        private DataGridViewTextBoxColumn FechaNacimiento;
        private DataGridViewTextBoxColumn Legajo;
        private DataGridViewTextBoxColumn Usuario;
    }
}