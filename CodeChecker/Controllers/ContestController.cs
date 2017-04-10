using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeChecker.Controllers
{
    public class ContestController : Controller
    {
        // GET: Contests
        public ActionResult Contest()
        {
            return View();
        }
    }
}