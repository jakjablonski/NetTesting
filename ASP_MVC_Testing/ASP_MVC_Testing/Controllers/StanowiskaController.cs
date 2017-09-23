using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_Testing.Data;
using ASP_MVC_Testing.Models;

namespace ASP_MVC_Testing.Controllers
{

    [HandleError(View = "Error")]
    [ValueReporter]
    public class StanowiskaController : Controller
    {
        private IWypoContext context;
        public StanowiskaController()
        {
            context = new WypoContext();
        }

        public StanowiskaController(IWypoContext Context)
        {
            context = Context;
        }

        // GET: Stanowiska
        public ActionResult Index()
        {
            return View("Index", context.Stanowiska.ToList());
        }

        // GET: Stanowiska/Details/5
        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult Details(int id)
        {
            
            Stanowisko stanowisko = context.FindStanowiskoById(id);
            if (stanowisko == null)
            {
                throw new Exception();
            }
            return View(stanowisko);
        }

        // GET: Stanowiska/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stanowiska/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StanowiskoId,Nazwa,Pensja")] Stanowisko stanowisko)
        {
            if (ModelState.IsValid)
            {
                context.Add(stanowisko);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stanowisko);
        }

        // GET: Stanowiska/Edit/5
        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stanowisko stanowisko = context.FindStanowiskoById(id);
            if (stanowisko == null)
            {
                throw new Exception();
            }
            return View(stanowisko);
        }

        // POST: Stanowiska/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StanowiskoId,Nazwa,Pensja")] Stanowisko stanowisko)
        {
            if (ModelState.IsValid)
            {
                context.Entry(stanowisko).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stanowisko);
        }

        // GET: Stanowiska/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stanowisko stanowisko = context.FindStanowiskoById(id);
            if (stanowisko == null)
            {
                return HttpNotFound();
            }
            return View(stanowisko);
        }

        // POST: Stanowiska/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stanowisko stanowisko = context.FindStanowiskoById(id);
            context.Delete(stanowisko);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View("Add");
        }
    }
}
