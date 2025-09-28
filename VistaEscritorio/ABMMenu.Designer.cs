namespace VistaEscritorio
{
    partial class ABMMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            materiasToolStripMenuItem = new ToolStripMenuItem();
            planesToolStripMenuItem = new ToolStripMenuItem();
            especialidadesToolStripMenuItem = new ToolStripMenuItem();
            cursosToolStripMenuItem = new ToolStripMenuItem();
            alumnosToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F);
            label1.Location = new Point(302, 87);
            label1.Name = "label1";
            label1.Size = new Size(429, 81);
            label1.TabIndex = 0;
            label1.Text = "Menu de Inicio";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 11F);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { materiasToolStripMenuItem, planesToolStripMenuItem, especialidadesToolStripMenuItem, cursosToolStripMenuItem, alumnosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(977, 35);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // materiasToolStripMenuItem
            // 
            materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            materiasToolStripMenuItem.Size = new Size(99, 29);
            materiasToolStripMenuItem.Text = "Materias";
            materiasToolStripMenuItem.Click += materiasToolStripMenuItem_Click;
            // 
            // planesToolStripMenuItem
            // 
            planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            planesToolStripMenuItem.Size = new Size(81, 29);
            planesToolStripMenuItem.Text = "Planes";
            planesToolStripMenuItem.Click += planesToolStripMenuItem_Click;
            // 
            // especialidadesToolStripMenuItem
            // 
            especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            especialidadesToolStripMenuItem.Size = new Size(149, 29);
            especialidadesToolStripMenuItem.Text = "Especialidades";
            especialidadesToolStripMenuItem.Click += especialidadesToolStripMenuItem_Click;
            // 
            // cursosToolStripMenuItem
            // 
            cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            cursosToolStripMenuItem.Size = new Size(83, 29);
            cursosToolStripMenuItem.Text = "Cursos";
            cursosToolStripMenuItem.Click += cursosToolStripMenuItem_Click;
            // 
            // alumnosToolStripMenuItem
            // 
            alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            alumnosToolStripMenuItem.Size = new Size(99, 29);
            alumnosToolStripMenuItem.Text = "Usuarios";
            alumnosToolStripMenuItem.Click += alumnosToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Location = new Point(0, 35);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(977, 25);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // ABMMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 645);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(label1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ABMMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button materiasButton;
        private Button planesButton;
        private Panel panel1;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem materiasToolStripMenuItem;
        private ToolStripMenuItem masMateriasToolStripMenuItem;
        private ToolStripMenuItem planesToolStripMenuItem;
        private ToolStripMenuItem especialidadesToolStripMenuItem;
        private ToolStripMenuItem cursosToolStripMenuItem;
        private ToolStripMenuItem alumnosToolStripMenuItem;
        private ToolStrip toolStrip1;
    }
}