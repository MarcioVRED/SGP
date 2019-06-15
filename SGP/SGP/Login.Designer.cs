namespace SGP
{
    partial class frmLogin
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSGP = new System.Windows.Forms.Label();
            this.btnLogar = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.UserType = new System.Windows.Forms.TextBox();
            this.UserID = new System.Windows.Forms.TextBox();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSGP
            // 
            this.lblSGP.AutoSize = true;
            this.lblSGP.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSGP.Location = new System.Drawing.Point(378, 100);
            this.lblSGP.Name = "lblSGP";
            this.lblSGP.Size = new System.Drawing.Size(248, 108);
            this.lblSGP.TabIndex = 0;
            this.lblSGP.Text = "SGP";
            // 
            // btnLogar
            // 
            this.btnLogar.Location = new System.Drawing.Point(52, 132);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(105, 33);
            this.btnLogar.TabIndex = 1;
            this.btnLogar.Text = "LOGAR";
            this.btnLogar.UseVisualStyleBackColor = true;
            this.btnLogar.Click += new System.EventHandler(this.btnLogar_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(55, 48);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(104, 20);
            this.txtUser.TabIndex = 2;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(55, 91);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '♠';
            this.txtSenha.Size = new System.Drawing.Size(104, 20);
            this.txtSenha.TabIndex = 3;
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnlLogin.Controls.Add(this.lblSenha);
            this.pnlLogin.Controls.Add(this.lblUser);
            this.pnlLogin.Controls.Add(this.txtUser);
            this.pnlLogin.Controls.Add(this.btnLogar);
            this.pnlLogin.Controls.Add(this.txtSenha);
            this.pnlLogin.Location = new System.Drawing.Point(388, 206);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(211, 255);
            this.pnlLogin.TabIndex = 4;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSenha.Location = new System.Drawing.Point(74, 72);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(59, 18);
            this.lblSenha.TabIndex = 6;
            this.lblSenha.Text = "SENHA";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUser.Location = new System.Drawing.Point(68, 28);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(75, 18);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "USUÁRIO";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(0, 617);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(1036, 10);
            this.ProgressBar1.TabIndex = 6;
            // 
            // UserType
            // 
            this.UserType.Location = new System.Drawing.Point(905, 591);
            this.UserType.Name = "UserType";
            this.UserType.Size = new System.Drawing.Size(131, 20);
            this.UserType.TabIndex = 63;
            this.UserType.Visible = false;
            // 
            // UserID
            // 
            this.UserID.Location = new System.Drawing.Point(905, 565);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(131, 20);
            this.UserID.TabIndex = 64;
            this.UserID.Visible = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 628);
            this.Controls.Add(this.UserID);
            this.Controls.Add(this.UserType);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.lblSGP);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - SGP";
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSGP;
        private System.Windows.Forms.Button btnLogar;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblUser;
        internal System.Windows.Forms.TextBox UserType;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.TextBox txtUser;
        internal System.Windows.Forms.TextBox txtSenha;
        internal System.Windows.Forms.TextBox UserID;
    }
}

