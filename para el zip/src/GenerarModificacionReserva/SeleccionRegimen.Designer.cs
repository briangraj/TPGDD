namespace FrbaHotel.GenerarModificacionReserva
{
    partial class SeleccionRegimen
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
            this.dataGridViewRegimenes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegimenes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRegimenes
            // 
            this.dataGridViewRegimenes.AllowUserToAddRows = false;
            this.dataGridViewRegimenes.AllowUserToDeleteRows = false;
            this.dataGridViewRegimenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegimenes.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewRegimenes.Name = "dataGridViewRegimenes";
            this.dataGridViewRegimenes.ReadOnly = true;
            this.dataGridViewRegimenes.Size = new System.Drawing.Size(617, 287);
            this.dataGridViewRegimenes.TabIndex = 5;
            this.dataGridViewRegimenes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRegimenes_CellContentClick);
            // 
            // SeleccionRegimen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 311);
            this.Controls.Add(this.dataGridViewRegimenes);
            this.Name = "SeleccionRegimen";
            this.Text = "SeleccionRegimen";
            this.Load += new System.EventHandler(this.SeleccionRegimen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegimenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DataGridView dataGridViewRegimenes;

    }
}