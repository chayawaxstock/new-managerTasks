namespace Profile
{
    partial class Profile
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_name = new Telerik.WinControls.UI.RadLabel();
            this.lbl_department = new Telerik.WinControls.UI.RadLabel();
            this.btn_logout = new Telerik.WinControls.UI.RadButton();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_department)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_logout)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.Location = new System.Drawing.Point(3, 10);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(43, 21);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "name";
            this.lbl_name.ThemeName = "MaterialTeal";
            // 
            // lbl_department
            // 
            this.lbl_department.Location = new System.Drawing.Point(58, 10);
            this.lbl_department.Name = "lbl_department";
            this.lbl_department.Size = new System.Drawing.Size(82, 21);
            this.lbl_department.TabIndex = 1;
            this.lbl_department.Text = "department";
            this.lbl_department.ThemeName = "MaterialTeal";
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(159, 5);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(90, 28);
            this.btn_logout.TabIndex = 2;
            this.btn_logout.Text = "Log-Out";
            this.btn_logout.ThemeName = "MaterialTeal";
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.lbl_department);
            this.Controls.Add(this.lbl_name);
            this.Name = "Profile";
            this.Size = new System.Drawing.Size(262, 41);
            ((System.ComponentModel.ISupportInitialize)(this.lbl_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_department)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_logout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lbl_name;
        private Telerik.WinControls.UI.RadLabel lbl_department;
        private Telerik.WinControls.UI.RadButton btn_logout;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
    }
}
