using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class HomeController : Controller
    {
        private MyDatabaseContext db;

        public HomeController()
        {
            db = new MyDatabaseContext();
        }

        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult Lists()
        {
            if (User.Identity.IsAuthenticated)
            {
                var dbSetProperties = db.GetDbSetProperties();
                List<String> dbSets = dbSetProperties.Select(x => x.Name).ToList();

                ViewBag.Tables = new SelectList(dbSets, "TableName");
            }

            return View();
        }

        public ActionResult ShowList(String tableName)
        {
            Trace.WriteLine("GET /Home/ShowList");

            if (tableName.Equals("Books"))
            {
                db.Dispose();
                return RedirectToAction("Index", "Book");
            }
            else if (tableName.Equals("Types"))
            {
                db.Dispose();
                return RedirectToAction("Index", "Type");
            }

            return RedirectToAction("Index");
        }


    }
}