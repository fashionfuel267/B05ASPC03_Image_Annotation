using System.Web;
using System.Web.Mvc;

namespace B05ASPC03_DataAnnotation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
