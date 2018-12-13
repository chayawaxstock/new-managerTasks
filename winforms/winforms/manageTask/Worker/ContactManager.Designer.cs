namespace manageTask
{
    partial class ContactManager
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
            this.btn_send_message = new Telerik.WinControls.UI.RadButton();
            this.txt_Body = new Telerik.WinControls.UI.RadRichTextEditor();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.txt_Subject = new Telerik.WinControls.UI.RadRichTextEditor();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gb_email = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_send_message)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Body)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Subject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_email)).BeginInit();
            this.gb_email.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_send_message
            // 
            this.btn_send_message.Location = new System.Drawing.Point(667, 431);
            this.btn_send_message.Margin = new System.Windows.Forms.Padding(4);
            this.btn_send_message.Name = "btn_send_message";
            this.btn_send_message.Size = new System.Drawing.Size(120, 45);
            this.btn_send_message.TabIndex = 5;
            this.btn_send_message.Text = "Send";
            this.btn_send_message.ThemeName = "MaterialTeal";
            this.btn_send_message.Click += new System.EventHandler(this.btn_send_message_Click);
            // 
            // txt_Body
            // 
            this.txt_Body.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Body.LayoutMode = Telerik.WinForms.Documents.Model.DocumentLayoutMode.Flow;
            this.txt_Body.Location = new System.Drawing.Point(102, 149);
            this.txt_Body.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Body.Name = "txt_Body";
            this.txt_Body.SelectionFill = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.txt_Body.SelectionStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.txt_Body.Size = new System.Drawing.Size(667, 255);
            this.txt_Body.TabIndex = 3;
            this.txt_Body.ThemeName = "MaterialTeal";
            // 
            // txt_Subject
            // 
            this.txt_Subject.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Subject.Location = new System.Drawing.Point(102, 91);
            this.txt_Subject.Name = "txt_Subject";
            this.txt_Subject.SelectionFill = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.txt_Subject.SelectionStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.txt_Subject.Size = new System.Drawing.Size(611, 32);
            this.txt_Subject.TabIndex = 6;
            this.txt_Subject.ThemeName = "MaterialTeal";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(126, 47);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(112, 21);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Write your email";
            this.radLabel1.ThemeName = "MaterialTeal";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gb_email
            // 
            this.gb_email.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gb_email.Controls.Add(this.btn_send_message);
            this.gb_email.Controls.Add(this.radLabel1);
            this.gb_email.Controls.Add(this.txt_Body);
            this.gb_email.Controls.Add(this.txt_Subject);
            this.gb_email.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.gb_email.HeaderText = "";
            this.gb_email.Location = new System.Drawing.Point(52, 23);
            this.gb_email.Name = "gb_email";
            this.gb_email.Size = new System.Drawing.Size(885, 506);
            this.gb_email.TabIndex = 8;
            this.gb_email.ThemeName = "MaterialTeal";
            // 
            // ContactManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 556);
            this.Controls.Add(this.gb_email);
            this.Name = "ContactManager";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ContactManager";
            this.ThemeName = "MaterialTeal";
            ((System.ComponentModel.ISupportInitialize)(this.btn_send_message)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Body)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Subject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_email)).EndInit();
            this.gb_email.ResumeLayout(false);
            this.gb_email.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn_send_message;
        private Telerik.WinControls.UI.RadRichTextEditor txt_Body;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadRichTextEditor txt_Subject;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Telerik.WinControls.UI.RadGroupBox gb_email;
    }
}