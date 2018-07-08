namespace FrbaHotel.AbmHabitacion
{
    partial class DatosHabitacion
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
            this.numericUpDownPiso = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownNroHab = new System.Windows.Forms.NumericUpDown();
            this.comboBoxTipoHab = new System.Windows.Forms.ComboBox();
            this.checkBoxVistaExterior = new System.Windows.Forms.CheckBox();
            this.checkBoxHabilitada = new System.Windows.Forms.CheckBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.errorProviderHabitacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPiso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNroHab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderHabitacion)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.8F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownPiso, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownNroHab, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTipoHab, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxVistaExterior, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxHabilitada, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDescripcion, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 276);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numericUpDownPiso
            // 
            this.numericUpDownPiso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownPiso.Location = new System.Drawing.Point(179, 29);
            this.numericUpDownPiso.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownPiso.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPiso.Name = "numericUpDownPiso";
            this.numericUpDownPiso.Size = new System.Drawing.Size(289, 20);
            this.numericUpDownPiso.TabIndex = 9;
            this.numericUpDownPiso.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(52, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 18);
            this.label7.TabIndex = 7;
            this.label7.Text = "Habilitada";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero de habitacion";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Piso";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tipo de habitacion";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vista al exterior";
            // 
            // numericUpDownNroHab
            // 
            this.numericUpDownNroHab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownNroHab.Location = new System.Drawing.Point(179, 3);
            this.numericUpDownNroHab.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownNroHab.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNroHab.Name = "numericUpDownNroHab";
            this.numericUpDownNroHab.Size = new System.Drawing.Size(289, 20);
            this.numericUpDownNroHab.TabIndex = 8;
            this.numericUpDownNroHab.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxTipoHab
            // 
            this.comboBoxTipoHab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxTipoHab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoHab.FormattingEnabled = true;
            this.comboBoxTipoHab.Location = new System.Drawing.Point(179, 75);
            this.comboBoxTipoHab.Name = "comboBoxTipoHab";
            this.comboBoxTipoHab.Size = new System.Drawing.Size(289, 21);
            this.comboBoxTipoHab.TabIndex = 11;
            // 
            // checkBoxVistaExterior
            // 
            this.checkBoxVistaExterior.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxVistaExterior.AutoSize = true;
            this.checkBoxVistaExterior.Location = new System.Drawing.Point(179, 55);
            this.checkBoxVistaExterior.Name = "checkBoxVistaExterior";
            this.checkBoxVistaExterior.Size = new System.Drawing.Size(15, 14);
            this.checkBoxVistaExterior.TabIndex = 12;
            this.checkBoxVistaExterior.UseVisualStyleBackColor = true;
            // 
            // checkBoxHabilitada
            // 
            this.checkBoxHabilitada.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxHabilitada.AutoSize = true;
            this.checkBoxHabilitada.Location = new System.Drawing.Point(179, 255);
            this.checkBoxHabilitada.Name = "checkBoxHabilitada";
            this.checkBoxHabilitada.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHabilitada.TabIndex = 13;
            this.checkBoxHabilitada.UseVisualStyleBackColor = true;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(179, 102);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(289, 144);
            this.textBoxDescripcion.TabIndex = 14;
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(38, 404);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 1;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(417, 404);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 2;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // errorProviderHabitacion
            // 
            this.errorProviderHabitacion.ContainerControl = this;
            // 
            // DatosHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 442);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DatosHabitacion";
            this.Text = "DatosHabitacion";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPiso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNroHab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderHabitacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.ErrorProvider errorProviderHabitacion;
        protected System.Windows.Forms.NumericUpDown numericUpDownNroHab;
        protected System.Windows.Forms.NumericUpDown numericUpDownPiso;
        protected System.Windows.Forms.ComboBox comboBoxTipoHab;
        protected System.Windows.Forms.CheckBox checkBoxVistaExterior;
        protected System.Windows.Forms.CheckBox checkBoxHabilitada;
        protected System.Windows.Forms.TextBox textBoxDescripcion;
    }
}