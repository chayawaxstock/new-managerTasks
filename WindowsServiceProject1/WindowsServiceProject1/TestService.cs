using System;
using System.ServiceProcess;
using System.Configuration;
using System.Timers;
using System.Collections.Generic;
using System.Linq;

namespace WindowsServiceProject1
{
    public partial class TestService : ServiceBase
    {
        private Timer timer1;
        private string timeString;
        public int getCallType;

        /////////////////////////////////////////////////////////////////////
        public TestService()
        {
            InitializeComponent();
            int strTime = Convert.ToInt32(ConfigurationSettings.AppSettings["callDuration"]);
            getCallType = Convert.ToInt32(ConfigurationSettings.AppSettings["CallType"]);
            if (getCallType == 1)
            {
                timer1 = new Timer();
                double inter = GetNextInterval();
                timer1.Interval = inter;
                timer1.Elapsed += new ElapsedEventHandler(ServiceTimer_Tick);
            }
            else
            {
                timer1 = new Timer();
                timer1.Interval = strTime * 1000;
                timer1.Elapsed += new ElapsedEventHandler(ServiceTimer_Tick);
            }
        }

        /////////////////////////////////////////////////////////////////////
        protected override void OnStart(string[] args)
        {
            timer1.AutoReset = true;
            timer1.Enabled = true;
            SendMailService.WriteErrorLog("Service started");
        }

        /////////////////////////////////////////////////////////////////////
        protected override void OnStop()
        {
            timer1.AutoReset = false;
            timer1.Enabled = false;
            SendMailService.WriteErrorLog("Service stopped");
        }

        /////////////////////////////////////////////////////////////////////
        private double GetNextInterval()
        {
            timeString = ConfigurationSettings.AppSettings["StartTime"];
            DateTime t = DateTime.Parse(timeString);
            TimeSpan ts = new TimeSpan();
            int x;
            ts = t - DateTime.Now;
            if (ts.TotalMilliseconds < 0)
            {
                ts = t.AddDays(1) - DateTime.Now;//Here you can increase the timer interval based on your requirments.   
            }
            return ts.TotalMilliseconds;
        }

        /////////////////////////////////////////////////////////////////////
        private void SetTimer()
        {
            try
            {
                double inter = GetNextInterval();
                timer1.Interval = inter;
                timer1.Start();
            }
            catch (Exception ex)
            {
            }
        }

        /////////////////////////////////////////////////////////////////////
        private void ServiceTimer_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {

            List<BOL.HelpModel.SendEmailEndProject> workerNotFinish = BLL.LogicProjects.SendEmailDateProjectEnd();
            foreach (var item in workerNotFinish)
            {
                string message = $"Hi {item.UserName}<br/> the project {item.nameProject} the deadline tommorow You did {item.HourDo} from {item.hoursForProject}, You stay to do {item.stayToDo} hours ";
                SendMailService.SendEmail(item.EmailUser, "end dead line", message);
            }
            var group = workerNotFinish.GroupBy(p => p.EmailManager);
            foreach (var item in group)
            {
                string message = "";
                item.ToList().ForEach(user =>
                {
                    message += user.UserName + " ";
                });
                SendMailService.SendEmail(item.Key, "end dead line", message += "not finish their work");
            }

            if (getCallType == 1)
            {
                timer1.Stop();
                System.Threading.Thread.Sleep(1000000);
                SetTimer();
            }
        }
    }
}
