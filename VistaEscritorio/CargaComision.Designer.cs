using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace VistaEscritorio
{
    partial class CargaComision
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
            nombreBox = new TextBox();
            anioEspecialidadBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            planComboBox = new ComboBox();
            agregarComision = new Button();
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
            nombreBox.Location = new Point(164, 73);
            nombreBox.Margin = new Padding(3, 4, 3, 4);
            nombreBox.Name = "nombreBox";
            nombreBox.Size = new Size(228, 27);
            nombreBox.TabIndex = 0;
            // 
            // anioEspecialidadBox
            // 
            anioEspecialidadBox.DropDownStyle = ComboBoxStyle.DropDownList;
            anioEspecialidadBox.Location = new Point(164, 113);
            anioEspecialidadBox.Margin = new Padding(3, 4, 3, 4);
            anioEspecialidadBox.Name = "anioEspecialidadBox";
            anioEspecialidadBox.Size = new Size(228, 28);
            anioEspecialidadBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 77);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 4;
            label1.Text = "Nombre: *";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 117);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 5;
            label2.Text = "Año Especialidad: *";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 157);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 6;
            label3.Text = "Plan: *";
            // 
            // planComboBox
            // 
            planComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            planComboBox.FormattingEnabled = true;
            planComboBox.Location = new Point(164, 153);
            planComboBox.Margin = new Padding(3, 4, 3, 4);
            planComboBox.Name = "planComboBox";
            planComboBox.Size = new Size(342, 28);
            planComboBox.TabIndex = 2;
            // 
            // agregarComision
            // 
            agregarComision.Location = new Point(336, 13);
            agregarComision.Margin = new Padding(3, 4, 3, 4);
            agregarComision.Name = "agregarComision";
            agregarComision.Size = new Size(86, 40);
            agregarComision.TabIndex = 3;
            agregarComision.Text = "Agregar";
            agregarComision.UseVisualStyleBackColor = true;
            agregarComision.Click += agregarComision_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(429, 13);
            cancelarButton.Margin = new Padding(3, 4, 3, 4);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(86, 40);
            cancelarButton.TabIndex = 4;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(11, 23);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 20);
            lblEstado.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblEstado);
            panel1.Controls.Add(agregarComision);
            panel1.Controls.Add(cancelarButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 213);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(11, 13, 11, 13);
            panel1.Size = new Size(530, 67);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTitulo);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(11, 13, 11, 13);
            panel2.Size = new Size(530, 65);
            panel2.TabIndex = 10;
            panel2.Paint += panel2_Paint;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(11, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(221, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agregar Comisión";
            // 
            // CargaComision
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 280);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(planComboBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(anioEspecialidadBox);
            Controls.Add(nombreBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CargaComision";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cargar Comisión";
            Load += CargarComision_Load;
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
        private Button agregarComision;
        private Button cancelarButton;
        private Label lblEstado;
        private Panel panel1;
        private Panel panel2;
        private Label lblTitulo;
    }
}
