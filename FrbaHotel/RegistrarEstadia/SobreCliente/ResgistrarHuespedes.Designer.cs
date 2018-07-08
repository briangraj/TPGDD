namespace FrbaHotel.RegistrarEstadia
{
    partial class ResgistrarHuespedes
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
            this.buttonBuscarCliente = new System.Windows.Forms.Button();
            this.buttonClienteNuevo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBuscarCliente
            // 
            this.buttonBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscarCliente.Location = new System.Drawing.Point(79, 148);
            this.buttonBuscarCliente.Name = "buttonBuscarCliente";
            this.buttonBuscarCliente.Size = new System.Drawing.Size(127, 35);
            this.buttonBuscarCliente.TabIndex = 11;
            this.buttonBuscarCliente.Text = "Buscar cliente";
            this.buttonBuscarCliente.UseVisualStyleBackColor = true;
            this.buttonBuscarCliente.Click += new System.EventHandler(this.buttonBuscarCliente_Click);
            // 
            // buttonClienteNuevo
            // 
            this.buttonClienteNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClienteNuevo.Location = new System.Drawing.Point(79, 77);
            this.buttonClienteNuevo.Name = "buttonClienteNuevo";
            this.buttonClienteNuevo.Size = new System.Drawing.Size(127, 35);
            this.buttonClienteNuevo.TabIndex = 10;
            this.buttonClienteNuevo.Text = "Cliente nuevo";
            this.buttonClienteNuevo.UseVisualStyleBackColor = true;
            this.buttonClienteNuevo.Click += new System.EventHandler(this.buttonClienteNuevo_Click);
            // 
            // ResgistrarHuespedes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonBuscarCliente);
            this.Controls.Add(this.buttonClienteNuevo);
            this.Name = "ResgistrarHuespedes";
            this.Text = "ResgistrarHuespedes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBuscarCliente;
        private System.Windows.Forms.Button buttonClienteNuevo;
    }
}