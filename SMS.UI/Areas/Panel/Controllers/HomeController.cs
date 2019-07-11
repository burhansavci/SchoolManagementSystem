using SMS.BLL.Service;
using System.Web.Mvc;

namespace SMS.UI.Areas.Panel.Controllers
{
    public class HomeController : Controller
    {
        DataService service = new DataService();
        public ActionResult Index()
        {
            return View();
        }
       
    }
}