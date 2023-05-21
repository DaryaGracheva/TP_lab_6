using System;
using System.Web.Mvc;
using System.Web.Routing;
using Filters.Infrastructure;


public class HomeController : Controller
{
    //[CustomAuth(false)]
    //[Authorize(Users = null, Roles = "admin")]
    public ActionResult Index()
    {
        return View();

    }
   
    [HttpPost]
    public ActionResult Index(string Дата, string Откуда, string Куда, int? Вес, string Способ_доставки, int? Ценность, bool? Посылка_ценная)
    {
        if (Вес.HasValue)
        {
            ViewBag.Дата = Дата;
            ViewBag.Откуда = Откуда;
            ViewBag.Куда = Куда;
            ViewBag.Способ_доставки = Способ_доставки;
            ViewBag.Вес = Вес.Value;
            ViewBag.Ценность = Ценность;
            ViewBag.Посылка_ценная = Посылка_ценная;
            return View("Result");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
    public string RangeTest(int id)
    {
        if (id > 100)
        {
            return String.Format("The id value is: {0}", id);
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }


}
