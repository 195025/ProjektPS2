using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.Models;
using System.Diagnostics;
using Projekt.Models;

namespace DotNetAppSqlDb.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private MyDatabaseContext db;

        public BookController()
        {
            db = new MyDatabaseContext();
        }

        public ActionResult Index()
        {
            Trace.WriteLine("GET /Book/Index");

            var books = db.Books.Include(c => c.Type);

            return View(books);
        }

        // GET: Todos/Create
        public ActionResult Create()
        {
            Trace.WriteLine("GET /Book/CreateBook");
            return View(new Book());
        }


        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, Description, Author, TypeId")] Book book)
        {
            Trace.WriteLine("POST /Book/CreateBook");
            if (ModelState.IsValid)
            {
                if (!db.Types.Any(x=>x.TypeId == book.TypeId))
                {
                    ModelState.AddModelError("TypeId", "Haslo nieprawidlowe !");
                    return View();
                }

                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }


        // GET: Todos/Edit/5
        public ActionResult Edit(int? id)
        {
            Trace.WriteLine("GET /Book/Edit/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
    
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId, Title, Description, Author, TypeId")] Book book)
        {
            Trace.WriteLine("POST /Book/Edit/" + book.BookId);
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Todos/Delete/5
        public ActionResult Delete(int? id)
        {
            Trace.WriteLine("GET /Book/Delete/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trace.WriteLine("POST /Book/Delete/" + id);
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
