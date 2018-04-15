using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uksl.DAL.Interfaces;

namespace uksl.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Participant()
        {
            return View();
        }
        public ActionResult Step()
        {
            return View();
        }
        public ActionResult TournamentDota2()
        {
            ViewBag.CurrentTournamentId = 1;
            return View();
        }
        public ActionResult TournamentCsGo()
        {
            ViewBag.CurrentTournamentId = 2;
            return View();
        }
        public ActionResult Regulation()
        {
            return View();
        }
        public ActionResult Statistic()
        {
            return View();
        }
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}