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
    public class PracownicyController : Controller
    {
        //private WypoContext db = new WypoContext();
        private IWypoContext context;

        //public PracownicyController(WypoContext context)
        //{
        //    this.db = context;
        //}

        public PracownicyController()
        {
            context = new WypoContext();
        }

        public PracownicyController(IWypoContext Context)
        {
            context = Context;
        }


        // GET: Pracownicy
        [HandleError(View = "Error")]
        [ValueReporter]
        public ActionResult Index()
        {
            var pracownik = context.Pracownicy.Include(p => p.Stanowisko);
            return View("Index",pracownik.ToList());
        }

        // GET: Pracownicy/Details/5
        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult Details(int id)
        {
          
            Pracownik pracownik = context.FindPracownikById(id);
            if (pracownik == null)
            {
                throw new Exception();
            }
            return View("Details",pracownik);
        }

        // GET: Pracownicy/Create
        public ActionResult Create()
        {
            ViewBag.StanowiskoId = new SelectList(context.Stanowiska, "StanowiskoId", "Nazwa");
            return View();
        }

        // POST: Pracownicy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PracownikId,StanowiskoId,Imie,Nazwisko,Pesel")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                context.Add(pracownik);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StanowiskoId = new SelectList(context.Stanowiska, "StanowiskoId", "Nazwa", pracownik.StanowiskoId);
            return View(pracownik);
        }

        // GET: Pracownicy/Edit/5
        [HandleError(ExceptionType = typeof(Exception), View = "ErrorId")]
        public ActionResult Edit(int id)
        {
           
            Pracownik pracownik = context.FindPracownikById(id);
            if (pracownik == null)
            {
                throw new Exception();
            }
            ViewBag.StanowiskoId = new SelectList(context.Stanowiska, "StanowiskoId", "Nazwa", pracownik.StanowiskoId);
            return View("Edit", pracownik);
        }

        // POST: Pracownicy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PracownikId,StanowiskoId,Imie,Nazwisko,Pesel")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                context.Entry(pracownik).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StanowiskoId = new SelectList(context.Stanowiska, "StanowiskoId", "Nazwa", pracownik.StanowiskoId);
            return View("Edit",pracownik);
        }

        // GET: Pracownicy/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = context.FindPracownikById(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: Pracownicy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pracownik pracownik = context.FindPracownikById(id);
            context.Delete(pracownik);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Add()
        {
            return View("Add");
        }

        
    }
}
