using System;
using System.Drawing;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ABMplan : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvPlanes = new DataGridView();
            listarPlanes = new Button();
            agregarPlanes = new Button();
            eliminarPlanes = new Button();
            modificarPlanes = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvPlanes).BeginInit();
            SuspendLayout();

            // dgvPlanes
            dgvPlanes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlanes.Location = new Point(12, 12);
            dgvPlanes.Name = "dgvPlanes";
            dgvPlanes.Size = new Size(500, 150);
            dgvPlanes.TabIndex = 0;

            // listarPlanes
            listarPlanes.Location = new Point(12, 200);
            listarPlanes.Name = "listarPlanes";
            listarPlanes.Size = new Size(75, 23);
            listarPlanes.Text = "Listar";
            listarPlanes.Click += listarPlanes_Click;

            // agregarPlanes
            agregarPlanes.Location = new Point(120, 200);
            agregarPlanes.Name = "agregarPlanes";
            agregarPlanes.Size = new Size(75, 23);
            agregarPlanes.Text = "Agregar";
            agregarPlanes.Click += agregarPlanes_Click;

            // modificarPlanes
            modificarPlanes.Location = new Point(230, 200);
            modificarPlanes.Name = "modificarPlanes";
            modificarPlanes.Size = new Size(75, 23);
            modificarPlanes.Text = "Modificar";
            modificarPlanes.Click += modificarPlanes_Click;

            // eliminarPlanes
            eliminarPlanes.Location = new Point(340, 200);
            eliminarPlanes.Name = "eliminarPlanes";
            eliminarPlanes.Size = new Size(75, 23);
            eliminarPlanes.Text = "Eliminar";
            eliminarPlanes.Click += eliminarPlanes_Click;

            // ABMplan
            ClientSize = new Size(534, 261);
            Controls.Add(dgvPlanes);
            Controls.Add(listarPlanes);
            Controls.Add(agregarPlanes);
            Controls.Add(modificarPlanes);
            Controls.Add(eliminarPlanes);
            Text = "Planes";

            ((System.ComponentModel.ISupportInitialize)dgvPlanes).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dgvPlanes;
        private Button listarPlanes;
        private Button agregarPlanes;
        private Button eliminarPlanes;
        private Button modificarPlanes;
    }
}
