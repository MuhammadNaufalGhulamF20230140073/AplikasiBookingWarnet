namespace WarnetPABD
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoginUser;
        private System.Windows.Forms.Button btnLoginAdmin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSelectLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLoginUser = new System.Windows.Forms.Button();
            this.btnLoginAdmin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelectLogin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoginUser
            // 
            this.btnLoginUser.Location = new System.Drawing.Point(120, 60);
            this.btnLoginUser.Name = "btnLoginUser";
            this.btnLoginUser.Size = new System.Drawing.Size(100, 30);
            this.btnLoginUser.TabIndex = 0;
            this.btnLoginUser.Text = "Login User";
            this.btnLoginUser.UseVisualStyleBackColor = true;
            this.btnLoginUser.Click += new System.EventHandler(this.btnLoginUser_Click);
            // 
            // btnLoginAdmin
            // 
            this.btnLoginAdmin.Location = new System.Drawing.Point(120, 100);
            this.btnLoginAdmin.Name = "btnLoginAdmin";
            this.btnLoginAdmin.Size = new System.Drawing.Size(100, 30);
            this.btnLoginAdmin.TabIndex = 1;
            this.btnLoginAdmin.Text = "Login Admin";
            this.btnLoginAdmin.UseVisualStyleBackColor = true;
            this.btnLoginAdmin.Click += new System.EventHandler(this.btnLoginAdmin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSelectLogin
            // 
            this.lblSelectLogin.AutoSize = true;
            this.lblSelectLogin.Location = new System.Drawing.Point(120, 20);
            this.lblSelectLogin.Name = "lblSelectLogin";
            this.lblSelectLogin.Size = new System.Drawing.Size(108, 13);
            this.lblSelectLogin.TabIndex = 3;
            this.lblSelectLogin.Text = "LOGIN";
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(320, 180);
            this.Controls.Add(this.lblSelectLogin);
            this.Controls.Add(this.btnLoginAdmin);
            this.Controls.Add(this.btnLoginUser);
            this.Controls.Add(this.btnCancel);
            this.Name = "LoginForm";
            this.Text = "Login Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
