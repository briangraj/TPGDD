namespace FrbaHotel.RegistrarConsumible
{
    partial class RegistrarConsumibles
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
            this.dataGridViewConsumibles = new System.Windows.Forms.DataGridView();
            this.buttonSiguiente = new System.Windows.Forms.Button();
            this.dataGridViewConsumiblesSeleccionados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsumibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsumiblesSeleccionados)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewConsumibles
            // 
            this.dataGridViewConsumibles.AllowUserToAddRows = false;
            this.dataGridViewConsumibles.AllowUserToDeleteRows = false;
            this.dataGridViewConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsumibles.Location = new System.Drawing.Point(12, 32);
            this.dataGridViewConsumibles.Name = "dataGridViewConsumibles";
            this.dataGridViewConsumibles.ReadOnly = true;
            this.dataGridViewConsumibles.Size = new System.Drawing.Size(444, 138);
            this.dataGridViewConsumibles.TabIndex = 1;
            this.dataGridViewConsumibles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewConsumibles_CellClick);
            // 
            // buttonSiguiente
            // 
            this.buttonSiguiente.Location = new System.Drawing.Point(381, 581);
            this.buttonSiguiente.Name = "buttonSiguiente";
            this.buttonSiguiente.Size = new System.Drawing.Size(75, 23);
            this.buttonSiguiente.TabIndex = 3;
            this.buttonSiguiente.Text = "Siguiente";
            this.buttonSiguiente.UseVisualStyleBackColor = true;
            this.buttonSiguiente.Click += new System.EventHandler(this.buttonSiguiente_Click);
            // 
            // dataGridViewConsumiblesSeleccionados
            // 
            this.dataGridViewConsumiblesSeleccionados.AllowUserToAddRows = false;
            this.dataGridViewConsumiblesSeleccionados.AllowUserToDeleteRows = false;
            this.dataGridViewConsumiblesSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsumiblesSeleccionados.Location = new System.Drawing.Point(12, 227);
            this.dataGridViewConsumiblesSeleccionados.Name = "dataGridViewConsumiblesSeleccionados";
            this.dataGridViewConsumiblesSeleccionados.ReadOnly = true;
            this.dataGridViewConsumiblesSeleccionados.Size = new System.Drawing.Size(444, 348);
            this.dataGridViewConsumiblesSeleccionados.TabIndex = 4;
            this.dataGridViewConsumiblesSeleccionados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewConsumiblesSeleccionados_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione los consumibles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Consumibles seleccionados";
            // 
            // RegistrarConsumibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 616);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewConsumiblesSeleccionados);
            this.Controls.Add(this.buttonSiguiente);
            this.Controls.Add(this.dataGridViewConsumibles);
            this.Name = "RegistrarConsumibles";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.RegistrarConsumibles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsumibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsumiblesSeleccionados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewConsumibles;
        private System.Windows.Forms.Button buttonSiguiente;
        private System.Windows.Forms.DataGridView dataGridViewConsumiblesSeleccionados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}