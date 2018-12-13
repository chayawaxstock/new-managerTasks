namespace manageTask
{
    partial class SetTime
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
            this.timerPressent = new System.Windows.Forms.Timer(this.components);
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.radToggleButtonPressent = new Telerik.WinControls.UI.RadToggleButton();
            this.listProjectsWorker = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.gb_preccence = new Telerik.WinControls.UI.RadGroupBox();
            this.lbl_clock = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleButtonPressent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listProjectsWorker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_preccence)).BeginInit();
            this.gb_preccence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_clock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.Location = new System.Drawing.Point(122, 115);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(93, 21);
            this.lbl_name.TabIndex = 8;
            this.lbl_name.Text = "Project name";
            this.lbl_name.ThemeName = "MaterialTeal";
            // 
            // timerPressent
            // 
            this.timerPressent.Interval = 1;
            this.timerPressent.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // radToggleButtonPressent
            // 
            this.radToggleButtonPressent.Enabled = false;
            this.radToggleButtonPressent.Location = new System.Drawing.Point(210, 181);
            this.radToggleButtonPressent.Name = "radToggleButtonPressent";
            this.radToggleButtonPressent.Size = new System.Drawing.Size(132, 48);
            this.radToggleButtonPressent.TabIndex = 11;
            this.radToggleButtonPressent.Text = "start";
            this.radToggleButtonPressent.ThemeName = "MaterialTeal";
            this.radToggleButtonPressent.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radToggleButton1_ToggleStateChanged);
            // 
            // listProjectsWorker
            // 
            this.listProjectsWorker.Location = new System.Drawing.Point(264, 100);
            this.listProjectsWorker.Name = "listProjectsWorker";
            this.listProjectsWorker.Size = new System.Drawing.Size(173, 36);
            this.listProjectsWorker.TabIndex = 12;
            this.listProjectsWorker.ThemeName = "MaterialTeal";
            this.listProjectsWorker.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.listProjectsWorker_SelectedIndexChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(160, 44);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(217, 23);
            this.radLabel1.TabIndex = 13;
            this.radLabel1.Text = "choose project to start work";
            this.radLabel1.ThemeName = "MaterialTeal";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel1.GetChildAt(0))).Text = "choose project to start work";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radLabel1.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            // 
            // gb_preccence
            // 
            this.gb_preccence.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gb_preccence.Controls.Add(this.lbl_clock);
            this.gb_preccence.Controls.Add(this.radLabel1);
            this.gb_preccence.Controls.Add(this.radToggleButtonPressent);
            this.gb_preccence.Controls.Add(this.listProjectsWorker);
            this.gb_preccence.Controls.Add(this.lbl_name);
            this.gb_preccence.HeaderText = "";
            this.gb_preccence.Location = new System.Drawing.Point(53, 38);
            this.gb_preccence.Name = "gb_preccence";
            this.gb_preccence.Size = new System.Drawing.Size(525, 359);
            this.gb_preccence.TabIndex = 14;
            this.gb_preccence.ThemeName = "MaterialTeal";
            // 
            // lbl_clock
            // 
            this.lbl_clock.Location = new System.Drawing.Point(244, 271);
            this.lbl_clock.Name = "lbl_clock";
            this.lbl_clock.Size = new System.Drawing.Size(2, 2);
            this.lbl_clock.TabIndex = 14;
            // 
            // SetTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 450);
            this.Controls.Add(this.gb_preccence);
            this.Name = "SetTime";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "SetTime";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.SetTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lbl_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleButtonPressent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listProjectsWorker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gb_preccence)).EndInit();
            this.gb_preccence.ResumeLayout(false);
            this.gb_preccence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_clock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel lbl_name;
        private System.Windows.Forms.Timer timerPressent;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadToggleButton radToggleButtonPressent;
        private Telerik.WinControls.UI.RadDropDownList listProjectsWorker;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox gb_preccence;
        private Telerik.WinControls.UI.RadLabel lbl_clock;
    }
}