using System.Web.Mvc;

namespace SMS.UI.Areas.Panel
{
    public class PanelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Panel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Panel_default",
                "Panel/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "SMS.UI.Areas.Panel.Controllers" }
            );
        }
    }
}