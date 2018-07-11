namespace FrbaHotel.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxListado = new System.Windows.Forms.ComboBox();
            this.comboBoxTrimestre = new System.Windows.Forms.ComboBox();
            this.textBoxAnio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProviderEstadisticas = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.dataGridViewEstadistica = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEstadisticas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstadistica)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.35071F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.57346F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.07583F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxListado, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTrimestre, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAnio, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.07692F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.92308F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(844, 55);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboBoxListado
            // 
            this.comboBoxListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListado.FormattingEnabled = true;
            this.comboBoxListado.Items.AddRange(new object[] {
            "Hoteles con mayor cantidad de reservas canceladas",
            "Hoteles con mayor cantidad de consumibles facturados",
            "Hoteles con mayor cantidad de días fuera de servicio",
            "Habitaciones con mayor cantidad de días y veces que fueron ocupadas",
            "Cliente con mayor cantidad de puntos"});
            this.comboBoxListado.Location = new System.Drawing.Point(262, 26);
            this.comboBoxListado.Name = "comboBoxListado";
            this.comboBoxListado.Size = new System.Drawing.Size(543, 21);
            this.comboBoxListado.TabIndex = 31;
            // 
            // comboBoxTrimestre
            // 
            this.comboBoxTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrimestre.FormattingEnabled = true;
            this.comboBoxTrimestre.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxTrimestre.Location = new System.Drawing.Point(140, 26);
            this.comboBoxTrimestre.Name = "comboBoxTrimestre";
            this.comboBoxTrimestre.Size = new System.Drawing.Size(71, 21);
            this.comboBoxTrimestre.TabIndex = 10;
            // 
            // textBoxAnio
            // 
            this.textBoxAnio.Location = new System.Drawing.Point(3, 26);
            this.textBoxAnio.Name = "textBoxAnio";
            this.textBoxAnio.Size = new System.Drawing.Size(91, 20);
            this.textBoxAnio.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Trimestre";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Listado";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Año";
            // 
            // errorProviderEstadisticas
            // 
            this.errorProviderEstadisticas.ContainerControl = this;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(743, 123);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 17;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // dataGridViewEstadistica
            // 
            this.dataGridViewEstadistica.AllowUserToAddRows = false;
            this.dataGridViewEstadistica.AllowUserToDeleteRows = false;
            this.dataGridViewEstadistica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEstadistica.Location = new System.Drawing.Point(15, 204);
            this.dataGridViewEstadistica.Name = "dataGridViewEstadistica";
            this.dataGridViewEstadistica.ReadOnly = true;
            this.dataGridViewEstadistica.Size = new System.Drawing.Size(841, 174);
            this.dataGridViewEstadistica.TabIndex = 18;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 390);
            this.Controls.Add(this.dataGridViewEstadistica);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ListadoEstadistico";
            this.Text = "Estadisticas";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEstadisticas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstadistica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox textBoxAnio;
        protected System.Windows.Forms.ComboBox comboBoxTrimestre;
        protected System.Windows.Forms.ComboBox comboBoxListado;
        private System.Windows.Forms.ErrorProvider errorProviderEstadisticas;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.DataGridView dataGridViewEstadistica;
    }
}