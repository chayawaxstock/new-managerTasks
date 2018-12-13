namespace manageTask
{
    partial class Login
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
            this.lbl_name = new Telerik.WinControls.UI.RadLabel();
            this.lbl_password = new Telerik.WinControls.UI.RadLabel();
            this.txt_UserName = new Telerik.WinControls.UI.RadTextBox();
            this.txt_Password = new Telerik.WinControls.UI.RadTextBox();
            this.btn_signIn = new Telerik.WinControls.UI.RadButton();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.rememberMe = new Telerik.WinControls.UI.RadCheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gb_signIn = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btn_show_password = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password)).BeginInit();
            this.txt_Password.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_signIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rememberMe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_signIn)).BeginInit();
            this.gb_signIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_show_password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.Location = new System.Drawing.Point(27, 47);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(79, 21);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "user name:";
            this.lbl_name.ThemeName = "MaterialTeal";
            // 
            // lbl_password
            // 
            this.lbl_password.Location = new System.Drawing.Point(32, 92);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(74, 21);
            this.lbl_password.TabIndex = 1;
            this.lbl_password.Text = "password:";
            this.lbl_password.ThemeName = "MaterialTeal";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(122, 27);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.ShowClearButton = true;
            this.txt_UserName.Size = new System.Drawing.Size(127, 36);
            this.txt_UserName.TabIndex = 2;
            this.txt_UserName.ThemeName = "MaterialTeal";
            // 
            // txt_Password
            // 
            this.txt_Password.Controls.Add(this.btn_show_password);
            this.txt_Password.Location = new System.Drawing.Point(126, 81);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.ShowClearButton = true;
            this.txt_Password.Size = new System.Drawing.Size(126, 36);
            this.txt_Password.TabIndex = 3;
            this.txt_Password.ThemeName = "MaterialTeal";
            // 
            // btn_signIn
            // 
            this.btn_signIn.Location = new System.Drawing.Point(45, 200);
            this.btn_signIn.Name = "btn_signIn";
            this.btn_signIn.Size = new System.Drawing.Size(194, 38);
            this.btn_signIn.TabIndex = 4;
            this.btn_signIn.Text = "sign-in";
            this.btn_signIn.ThemeName = "MaterialTeal";
            this.btn_signIn.Click += new System.EventHandler(this.btn_signIn_Click_1);
            // 
            // rememberMe
            // 
            this.rememberMe.Location = new System.Drawing.Point(82, 152);
            this.rememberMe.Name = "rememberMe";
            this.rememberMe.Size = new System.Drawing.Size(120, 19);
            this.rememberMe.TabIndex = 5;
            this.rememberMe.Text = "Remember me";
            this.rememberMe.ThemeName = "MaterialTeal";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gb_signIn
            // 
            this.gb_signIn.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gb_signIn.Controls.Add(this.radLabel1);
            this.gb_signIn.Controls.Add(this.lbl_name);
            this.gb_signIn.Controls.Add(this.btn_signIn);
            this.gb_signIn.Controls.Add(this.rememberMe);
            this.gb_signIn.Controls.Add(this.txt_UserName);
            this.gb_signIn.Controls.Add(this.lbl_password);
            this.gb_signIn.Controls.Add(this.txt_Password);
            this.gb_signIn.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.gb_signIn.HeaderText = "sign-in";
            this.gb_signIn.Location = new System.Drawing.Point(52, 40);
            this.gb_signIn.Name = "gb_signIn";
            this.gb_signIn.Size = new System.Drawing.Size(294, 308);
            this.gb_signIn.TabIndex = 6;
            this.gb_signIn.Text = "sign-in";
            this.gb_signIn.ThemeName = "MaterialTeal";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(146, 255);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(93, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "forgot password?";
            this.radLabel1.Click += new System.EventHandler(this.radLabel1_Click);
            // 
            // btn_show_password
            // 
            this.btn_show_password.BackgroundImage = global::manageTask.Properties.Resources.view;
            this.btn_show_password.Image = global::manageTask.Properties.Resources.view;
            this.btn_show_password.Location = new System.Drawing.Point(95, 14);
            this.btn_show_password.Name = "btn_show_password";
            this.btn_show_password.Size = new System.Drawing.Size(18, 18);
            this.btn_show_password.TabIndex = 1;
            this.btn_show_password.Click += new System.EventHandler(this.btn_show_password_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 391);
            this.Controls.Add(this.gb_signIn);
            this.Name = "Login";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Sign-in";
            this.ThemeName = "MaterialTeal";
            ((System.ComponentModel.ISupportInitialize)(this.lbl_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password)).EndInit();
            this.txt_Password.ResumeLayout(false);
            this.txt_Password.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_signIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rememberMe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_signIn)).EndInit();
            this.gb_signIn.ResumeLayout(false);
            this.gb_signIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_show_password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lbl_name;
        private Telerik.WinControls.UI.RadLabel lbl_password;
        private Telerik.WinControls.UI.RadTextBox txt_UserName;
        private Telerik.WinControls.UI.RadTextBox txt_Password;
        private Telerik.WinControls.UI.RadButton btn_signIn;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadCheckBox rememberMe;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Telerik.WinControls.UI.RadGroupBox gb_signIn;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel btn_show_password;
    }
}

