namespace VistaEscritorio
{
    partial class CargarProfesor
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
            apellidoBox = new TextBox();
            dniBox = new TextBox();
            cargoBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            agregarProfesor = new Button();
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
            // apellidoBox
            // 
            apellidoBox.Location = new Point(130, 49);
            apellidoBox.Name = "apellidoBox";
            apellidoBox.Size = new Size(150, 23);
            apellidoBox.TabIndex = 1;
            // 
            // dniBox
            // 
            dniBox.Location = new Point(130, 78);
            dniBox.Name = "dniBox";
            dniBox.Size = new Size(150, 23);
            dniBox.TabIndex = 2;
            // 
            // cargoBox
            // 
            cargoBox.Location = new Point(130, 107);
            cargoBox.Name = "cargoBox";
            cargoBox.Size = new Size(150, 23);
            cargoBox.TabIndex = 3;
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
            label2.Location = new Point(58, 52);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 81);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 6;
            label3.Text = "DNI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 110);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 7;
            label4.Text = "Cargo";
            // 
            // agregarProfesor
            // 
            agregarProfesor.Location = new Point(159, 185);
            agregarProfesor.Name = "agregarProfesor";
            agregarProfesor.Size = new Size(75, 23);
            agregarProfesor.TabIndex = 10;
            agregarProfesor.Text = "Agregar";
            agregarProfesor.UseVisualStyleBackColor = true;
            agregarProfesor.Click += agregarProfesor_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(240, 185);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 11;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // CargarProfesor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 227);
            Controls.Add(agregarProfesor);
            Controls.Add(cancelarButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cargoBox);
            Controls.Add(dniBox);
            Controls.Add(apellidoBox);
            Controls.Add(nombreBox);
            Name = "CargarProfesor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cargar Profesor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nombreBox;
        private TextBox apellidoBox;
        private TextBox dniBox;
        private TextBox cargoBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button agregarProfesor;
        private Button cancelarButton;
    }
}