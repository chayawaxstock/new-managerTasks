using manageTask.Models;

namespace manageTask
{
    enum department
    {
        MANAGER,
        DEVELOPMENT,
        QA,
        UI,
        UX,
        TEAMLEADER
    }
    public static class GlobalProp
    {
        public static User CurrentUser { get; set; }

        public const string ManagerNameDepartment= "manager";

        public const string TeamLeaderNameDepartment = "teamLeader";

        public const string URI = @"http://localhost:12988/";

       
    }
}
