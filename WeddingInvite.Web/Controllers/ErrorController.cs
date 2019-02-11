using System.Web.Mvc;

namespace WeddingInvite.Web.Controllers
{
	public class ErrorController : Controller
    {
		// GET: Default
		public ViewResult Index()
		{
			return View("Error");
		}

		public ViewResult NotFound()
		{
			Response.StatusCode = 404;  //you may want to set this to 200
			return View("NotFound");
		}
	}
}