namespace FrbaHotel.GenerarModificacionReserva.DatosReserva
{
    partial class DatosReserva
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
            this.dataGridViewHabReservadas = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSiguiente = new System.Windows.Forms.Button();
            this.dataGridViewHabitaciones = new System.Windows.Forms.DataGridView();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTipoReg = new System.Windows.Forms.ComboBox();
            this.comboBoxTipoHab = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProviderReserva = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHabReservadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHabitaciones)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderReserva)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHabReservadas
            // 
            this.dataGridViewHabReservadas.AllowUserToAddRows = false;
            this.dataGridViewHabReservadas.AllowUserToDeleteRows = false;
            this.dataGridViewHabReservadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHabReservadas.Location = new System.Drawing.Point(730, 203);
            this.dataGridViewHabReservadas.Name = "dataGridViewHabReservadas";
            this.dataGridViewHabReservadas.ReadOnly = true;
            this.dataGridViewHabReservadas.Size = new System.Drawing.Size(653, 298);
            this.dataGridViewHabReservadas.TabIndex = 20;
            this.dataGridViewHabReservadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHabReservadas_CellClick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(726, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 24);
            this.label5.TabIndex = 19;
            this.label5.Text = "Habitaciones seleccionadas";
            // 
            // buttonSiguiente
            // 
            this.buttonSiguiente.Location = new System.Drawing.Point(1227, 517);
            this.buttonSiguiente.Name = "buttonSiguiente";
            this.buttonSiguiente.Size = new System.Drawing.Size(75, 23);
            this.buttonSiguiente.TabIndex = 18;
            this.buttonSiguiente.Text = "Siguiente";
            this.buttonSiguiente.UseVisualStyleBackColor = true;
            this.buttonSiguiente.Click += new System.EventHandler(this.buttonSiguiente_Click);
            // 
            // dataGridViewHabitaciones
            // 
            this.dataGridViewHabitaciones.AllowUserToAddRows = false;
            this.dataGridViewHabitaciones.AllowUserToDeleteRows = false;
            this.dataGridViewHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHabitaciones.Location = new System.Drawing.Point(21, 203);
            this.dataGridViewHabitaciones.Name = "dataGridViewHabitaciones";
            this.dataGridViewHabitaciones.ReadOnly = true;
            this.dataGridViewHabitaciones.Size = new System.Drawing.Size(653, 298);
            this.dataGridViewHabitaciones.TabIndex = 17;
            this.dataGridViewHabitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHabitaciones_CellClick);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscar.Location = new System.Drawing.Point(1026, 104);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(79, 29);
            this.buttonBuscar.TabIndex = 16;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpiar.Location = new System.Drawing.Point(850, 104);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(72, 29);
            this.buttonLimpiar.TabIndex = 15;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.59174F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.07776F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.41312F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.79587F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerDesde, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerHasta, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTipoReg, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTipoHab, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.23077F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.76923F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1298, 52);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1094, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tipo de regimen";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(413, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fecha de egreso";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fecha de ingreso";
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDesde.Location = new System.Drawing.Point(3, 26);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(245, 22);
            this.dateTimePickerDesde.TabIndex = 0;
            this.dateTimePickerDesde.Value = new System.DateTime(2021, 1, 13, 0, 0, 0, 0);
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerHasta.Location = new System.Drawing.Point(413, 26);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(248, 22);
            this.dateTimePickerHasta.TabIndex = 1;
            this.dateTimePickerHasta.Value = new System.DateTime(2021, 1, 17, 0, 0, 0, 0);
            // 
            // comboBoxTipoReg
            // 
            this.comboBoxTipoReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoReg.FormattingEnabled = true;
            this.comboBoxTipoReg.Location = new System.Drawing.Point(1094, 26);
            this.comboBoxTipoReg.Name = "comboBoxTipoReg";
            this.comboBoxTipoReg.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTipoReg.TabIndex = 3;
            // 
            // comboBoxTipoHab
            // 
            this.comboBoxTipoHab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoHab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoHab.FormattingEnabled = true;
            this.comboBoxTipoHab.Location = new System.Drawing.Point(829, 26);
            this.comboBoxTipoHab.Name = "comboBoxTipoHab";
            this.comboBoxTipoHab.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTipoHab.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(829, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tipo de habitacion";
            // 
            // errorProviderReserva
            // 
            this.errorProviderReserva.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(331, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "Seleccione las habitaciones deseadas";
            // 
            // DatosReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 552);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridViewHabReservadas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSiguiente);
            this.Controls.Add(this.dataGridViewHabitaciones);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DatosReserva";
            this.Text = "DatosReserv";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHabReservadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHabitaciones)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderReserva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DataGridView dataGridViewHabReservadas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSiguiente;
        protected System.Windows.Forms.DataGridView dataGridViewHabitaciones;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        protected System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        protected System.Windows.Forms.ComboBox comboBoxTipoHab;
        protected System.Windows.Forms.ComboBox comboBoxTipoReg;
        private System.Windows.Forms.ErrorProvider errorProviderReserva;
        private System.Windows.Forms.Label label6;

    }
}