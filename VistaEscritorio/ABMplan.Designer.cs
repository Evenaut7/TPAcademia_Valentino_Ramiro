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
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvPlanes).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPlanes
            // 
            dgvPlanes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlanes.Dock = DockStyle.Fill;
            dgvPlanes.Location = new Point(0, 0);
            dgvPlanes.Name = "dgvPlanes";
            dgvPlanes.Size = new Size(784, 461);
            dgvPlanes.TabIndex = 0;
            // 
            // listarPlanes
            // 
            listarPlanes.Dock = DockStyle.Right;
            listarPlanes.Location = new Point(479, 5);
            listarPlanes.Name = "listarPlanes";
            listarPlanes.Size = new Size(75, 35);
            listarPlanes.TabIndex = 1;
            listarPlanes.Text = "Listar";
            listarPlanes.Click += listarPlanes_Click;
            // 
            // agregarPlanes
            // 
            agregarPlanes.Dock = DockStyle.Right;
            agregarPlanes.Location = new Point(554, 5);
            agregarPlanes.Name = "agregarPlanes";
            agregarPlanes.Size = new Size(75, 35);
            agregarPlanes.TabIndex = 2;
            agregarPlanes.Text = "Agregar";
            agregarPlanes.Click += agregarPlanes_Click;
            // 
            // eliminarPlanes
            // 
            eliminarPlanes.Dock = DockStyle.Right;
            eliminarPlanes.Location = new Point(704, 5);
            eliminarPlanes.Name = "eliminarPlanes";
            eliminarPlanes.Size = new Size(75, 35);
            eliminarPlanes.TabIndex = 4;
            eliminarPlanes.Text = "Eliminar";
            eliminarPlanes.Click += eliminarPlanes_Click;
            // 
            // modificarPlanes
            // 
            modificarPlanes.Dock = DockStyle.Right;
            modificarPlanes.Location = new Point(629, 5);
            modificarPlanes.Name = "modificarPlanes";
            modificarPlanes.Size = new Size(75, 35);
            modificarPlanes.TabIndex = 3;
            modificarPlanes.Text = "Modificar";
            modificarPlanes.Click += modificarPlanes_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(listarPlanes);
            panel1.Controls.Add(agregarPlanes);
            panel1.Controls.Add(modificarPlanes);
            panel1.Controls.Add(eliminarPlanes);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 416);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(784, 45);
            panel1.TabIndex = 5;
            // 
            // ABMplan
            // 
            ClientSize = new Size(784, 461);
            Controls.Add(panel1);
            Controls.Add(dgvPlanes);
            Name = "ABMplan";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Planes";
            Load += ABMplan_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPlanes).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private DataGridView dgvPlanes;
        private Button listarPlanes;
        private Button agregarPlanes;
        private Button eliminarPlanes;
        private Button modificarPlanes;
        private Panel panel1;
    }
}
