using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace VistaEscritorio
{
    partial class CargaComision
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
            nombreBox = new TextBox();
            anioEspecialidadBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            planComboBox = new ComboBox();
            agregarComision = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // nombreBox
            // 
            nombreBox.Location = new Point(130, 20);
            nombreBox.Name = "nombreBox";
            nombreBox.Size = new Size(150, 23);
            nombreBox.TabIndex = 0;
            // 
            // anioEspecialidadBox
            // 
            anioEspecialidadBox.Location = new Point(130, 49);
            anioEspecialidadBox.Name = "anioEspecialidadBox";
            anioEspecialidadBox.Size = new Size(86, 23);
            anioEspecialidadBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 23);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 5;
            label2.Text = "Año Especialidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 81);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 6;
            label3.Text = "Plan";
            // 
            // planComboBox
            // 
            planComboBox.FormattingEnabled = true;
            planComboBox.Location = new Point(130, 78);
            planComboBox.Name = "planComboBox";
            planComboBox.Size = new Size(150, 23);
            planComboBox.TabIndex = 7;
            // 
            // agregarComision
            // 
            agregarComision.Location = new Point(159, 130);
            agregarComision.Name = "agregarComision";
            agregarComision.Size = new Size(75, 23);
            agregarComision.TabIndex = 10;
            agregarComision.Text = "Agregar";
            agregarComision.UseVisualStyleBackColor = true;
            agregarComision.Click += agregarComision_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(240, 130);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 11;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // CargarComision
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 172);
            Controls.Add(agregarComision);
            Controls.Add(cancelarButton);
            Controls.Add(planComboBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(anioEspecialidadBox);
            Controls.Add(nombreBox);
            Name = "CargarComision";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cargar Comisión";
            Load += CargarComision_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nombreBox;
        private TextBox anioEspecialidadBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox planComboBox;
        private Button agregarComision;
        private Button cancelarButton;
    }
}