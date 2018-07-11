namespace FrbaHotel.Login
{
    partial class SeleccionarHotel
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
            this.comboBoxHoteles = new System.Windows.Forms.ComboBox();
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxHoteles
            // 
            this.comboBoxHoteles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHoteles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHoteles.FormattingEnabled = true;
            this.comboBoxHoteles.Location = new System.Drawing.Point(12, 69);
            this.comboBoxHoteles.Name = "comboBoxHoteles";
            this.comboBoxHoteles.Size = new System.Drawing.Size(561, 28);
            this.comboBoxHoteles.TabIndex = 0;
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSeleccionar.Location = new System.Drawing.Point(225, 155);
            this.buttonSeleccionar.Name = "buttonSeleccionar";
            this.buttonSeleccionar.Size = new System.Drawing.Size(114, 30);
            this.buttonSeleccionar.TabIndex = 1;
            this.buttonSeleccionar.Text = "Seleccionar";
            this.buttonSeleccionar.UseVisualStyleBackColor = true;
            this.buttonSeleccionar.Click += new System.EventHandler(this.buttonSeleccionar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione un hotel para continuar";
            // 
            // SeleccionarHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 212);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.comboBoxHoteles);
            this.Name = "SeleccionarHotel";
            this.Text = "SeleccionarHotel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxHoteles;
        private System.Windows.Forms.Button buttonSeleccionar;
        private System.Windows.Forms.Label label1;
    }
}