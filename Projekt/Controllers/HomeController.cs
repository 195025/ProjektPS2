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
            var dbSetProperties = db.GetDbSetProperties();
            List<String> dbSets = dbSetProperties.Select(x => x.Name).ToList();

            ViewBag.Tables = new SelectList(dbSets, "TableName");
            //ViewBag.tables;
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}