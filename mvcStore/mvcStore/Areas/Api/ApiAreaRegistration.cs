using System.Web.Mvc;

namespace mvcStore.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName { get { return "Api"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Api_default",
                "Api/{controller}",
                new { action = "Index" }
            );
            context.MapRoute(
                "SingleCard",
                "Api/{controller}/{id}",
                new {
                    action = "Details",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
