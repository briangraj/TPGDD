namespace FrbaHotel.Login
{
    partial class Inicio
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
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.errorProviderInicio = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonGuest = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.25641F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.74359F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxPass, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUser, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelUser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelPass, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(48, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(195, 61);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(62, 33);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(100, 20);
            this.textBoxPass.TabIndex = 1;
            this.textBoxPass.UseSystemPasswordChar = true;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(62, 3);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(100, 20);
            this.textBoxUser.TabIndex = 0;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(3, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(37, 16);
            this.labelUser.TabIndex = 2;
            this.labelUser.Text = "User";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.Location = new System.Drawing.Point(3, 30);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(39, 16);
            this.labelPass.TabIndex = 3;
            this.labelPass.Text = "Pass";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(110, 123);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 1;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // errorProviderInicio
            // 
            this.errorProviderInicio.ContainerControl = this;
            // 
            // buttonGuest
            // 
            this.buttonGuest.Enabled = false;
            this.buttonGuest.Location = new System.Drawing.Point(65, 199);
            this.buttonGuest.Name = "buttonGuest";
            this.buttonGuest.Size = new System.Drawing.Size(162, 23);
            this.buttonGuest.TabIndex = 2;
            this.buttonGuest.Text = "Ingresar como guest";
            this.buttonGuest.UseVisualStyleBackColor = true;
            this.buttonGuest.Click += new System.EventHandler(this.buttonGuest_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonGuest);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Inicio";
            this.Text = "Login";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ErrorProvider errorProviderInicio;
        private System.Windows.Forms.Button buttonGuest;
    }
}