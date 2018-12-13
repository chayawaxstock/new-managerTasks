using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace BLL
{
    public class BaseLogic
    {
        public static List<string> GetErorList(ICollection<ModelState> values)
        {
            List<string> ErrorList = new List<string>();
            foreach (var item in values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);
            return ErrorList;
        }
    }
}
