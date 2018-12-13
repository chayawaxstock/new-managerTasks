using manageTask.Logic;
using manageTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace manageTask
{
    public partial class SetTime : Telerik.WinControls.UI.RadForm
    {
        private List<ProjectWorker> projects;
        public static TimeSpan d = new TimeSpan(00, 00, 0000);
        public static TimeSpan time1 = TimeSpan.FromSeconds(1);

        public SetTime()
        {
            InitializeComponent();
        }
        public void AddStyle()
        {
            GlobalStyle.SetStyleForm(Controls);
            GlobalStyle.SetMiddle(gb_preccence);
        }
        public void FillProjectsWorker()
        {
            projects = TaskRequests.GetProjectsById(GlobalProp.CurrentUser.UserId);
            listProjectsWorker.Items.AddRange(projects.Select(p => new RadListDataItem() { Tag = p.Project, Text = p.Project.ProjectName }));
        }
        private void SetTime_Load(object sender, EventArgs e)
        {
            FillProjectsWorker();
            AddStyle();
        }
        //start timer to start work to project
        private bool StartPressent()
        {
            timerPressent.Enabled = true;

            PresentDay p = new PresentDay();
            p.UserId = GlobalProp.CurrentUser.UserId;
            p.ProjectId = (listProjectsWorker.SelectedItem.Tag as Project).ProjectId;
            p.TimeBegin = DateTime.Now;
            p.TimeEnd = DateTime.Now;
            return PresentDayRequests.AddPresentDay(p);

        }
        //end timer to finish work
        private bool EndPressent()
        {
            timerPressent.Enabled = false;
            PresentDay p = new PresentDay();
            p.UserId = GlobalProp.CurrentUser.UserId;
            p.ProjectId = (listProjectsWorker.SelectedItem.Tag as Project).ProjectId;
            p.TimeEnd = DateTime.Now;
            return PresentDayRequests.UpdatePresentDay(p);
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            d = d.Add(time1);
            lbl_clock.Text = d.ToString();
        }
        private void radToggleButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            RadToggleButton myButton = (RadToggleButton)sender;

            switch (args.ToggleState)
            {
                case ToggleState.On:
                    if (StartPressent() == true)
                    {
                        myButton.Text = "end";
                    }
                    break;
                case ToggleState.Off:
                    if (EndPressent() == true)
                    {
                        d = new TimeSpan(00, 00, 0000);
                        lbl_clock.Text = d.ToString();
                        myButton.Text = "start";
                    }
                    break;
                default:
                    break;
            }
        }
        private void listProjectsWorker_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            radToggleButtonPressent.Enabled = true;
        }
    }
}
