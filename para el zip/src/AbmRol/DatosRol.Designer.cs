namespace FrbaHotel.AbmRol
{
    partial class DatosRol
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
            this.checkedListBoxFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.labelNombreRol = new System.Windows.Forms.Label();
            this.labelFuncionalidades = new System.Windows.Forms.Label();
            this.textBoxNombreRol = new System.Windows.Forms.TextBox();
            this.checkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.errorProviderDatos = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBoxFuncionalidades
            // 
            this.checkedListBoxFuncionalidades.FormattingEnabled = true;
            this.checkedListBoxFuncionalidades.Location = new System.Drawing.Point(45, 143);
            this.checkedListBoxFuncionalidades.Name = "checkedListBoxFuncionalidades";
            this.checkedListBoxFuncionalidades.Size = new System.Drawing.Size(213, 244);
            this.checkedListBoxFuncionalidades.TabIndex = 0;
            // 
            // labelNombreRol
            // 
            this.labelNombreRol.AutoSize = true;
            this.labelNombreRol.Location = new System.Drawing.Point(42, 46);
            this.labelNombreRol.Name = "labelNombreRol";
            this.labelNombreRol.Size = new System.Drawing.Size(66, 13);
            this.labelNombreRol.TabIndex = 2;
            this.labelNombreRol.Text = "Nombre Rol ";
            // 
            // labelFuncionalidades
            // 
            this.labelFuncionalidades.AutoSize = true;
            this.labelFuncionalidades.Location = new System.Drawing.Point(42, 127);
            this.labelFuncionalidades.Name = "labelFuncionalidades";
            this.labelFuncionalidades.Size = new System.Drawing.Size(84, 13);
            this.labelFuncionalidades.TabIndex = 3;
            this.labelFuncionalidades.Text = "Funcionalidades";
            // 
            // textBoxNombreRol
            // 
            this.textBoxNombreRol.Location = new System.Drawing.Point(45, 62);
            this.textBoxNombreRol.Name = "textBoxNombreRol";
            this.textBoxNombreRol.Size = new System.Drawing.Size(213, 20);
            this.textBoxNombreRol.TabIndex = 4;
            // 
            // checkBoxHabilitado
            // 
            this.checkBoxHabilitado.AutoSize = true;
            this.checkBoxHabilitado.Location = new System.Drawing.Point(45, 423);
            this.checkBoxHabilitado.Name = "checkBoxHabilitado";
            this.checkBoxHabilitado.Size = new System.Drawing.Size(73, 17);
            this.checkBoxHabilitado.TabIndex = 5;
            this.checkBoxHabilitado.Text = "Habilitado";
            this.checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(45, 481);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 6;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(183, 481);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 7;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // errorProviderDatos
            // 
            this.errorProviderDatos.ContainerControl = this;
            // 
            // DatosRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 530);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.checkBoxHabilitado);
            this.Controls.Add(this.textBoxNombreRol);
            this.Controls.Add(this.labelFuncionalidades);
            this.Controls.Add(this.labelNombreRol);
            this.Controls.Add(this.checkedListBoxFuncionalidades);
            this.Name = "DatosRol";
            this.Text = "DatosRol";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxFuncionalidades;
        private System.Windows.Forms.Label labelNombreRol;
        private System.Windows.Forms.Label labelFuncionalidades;
        private System.Windows.Forms.TextBox textBoxNombreRol;
        private System.Windows.Forms.CheckBox checkBoxHabilitado;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.ErrorProvider errorProviderDatos;
    }
}