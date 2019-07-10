using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using systemBook.Models;

namespace systemBook.Controllers
{
    public class EscritoresController : Controller
    {
        // GET: Escritores
        public ActionResult Index()
        {
            List<Escritor> escritores = Bd_conections.AllEscritores();
            return View(escritores);
        }

        // GET: Escritores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Escritores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escritores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Escritor collection)
        {
            Bd_conections.AddEscritores((Escritor)collection);
            return RedirectToAction(nameof(Index));
            try
            {
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Escritores/Edit/5
        public ActionResult Edit(int id)
        {
            Bd_conections.singleEscritor(id);
            return View();
        }

        // POST: Escritores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Escritores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Escritores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}