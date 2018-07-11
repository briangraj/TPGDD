namespace FrbaHotel.RegistrarEstadia
{
    partial class IngresoEgreso
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
            this.buttonEgreso = new System.Windows.Forms.Button();
            this.buttonIngreso = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEgreso
            // 
            this.buttonEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEgreso.Location = new System.Drawing.Point(77, 137);
            this.buttonEgreso.Name = "buttonEgreso";
            this.buttonEgreso.Size = new System.Drawing.Size(118, 35);
            this.buttonEgreso.TabIndex = 6;
            this.buttonEgreso.Text = "Egreso";
            this.buttonEgreso.UseVisualStyleBackColor = true;
            this.buttonEgreso.Click += new System.EventHandler(this.buttonEgreso_Click);
            // 
            // buttonIngreso
            // 
            this.buttonIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIngreso.Location = new System.Drawing.Point(77, 66);
            this.buttonIngreso.Name = "buttonIngreso";
            this.buttonIngreso.Size = new System.Drawing.Size(118, 35);
            this.buttonIngreso.TabIndex = 5;
            this.buttonIngreso.Text = "Ingreso";
            this.buttonIngreso.UseVisualStyleBackColor = true;
            this.buttonIngreso.Click += new System.EventHandler(this.buttonIngreso_Click);
            // 
            // IngresoEgreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonEgreso);
            this.Controls.Add(this.buttonIngreso);
            this.Name = "IngresoEgreso";
            this.Text = "IngresoEgreso";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEgreso;
        private System.Windows.Forms.Button buttonIngreso;
    }
}