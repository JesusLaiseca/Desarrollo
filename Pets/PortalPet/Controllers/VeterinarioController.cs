using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalPet.Controllers
{
    public class VeterinarioController : Controller
    {
        // GET: Veterinario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Veterinario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Veterinario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veterinario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Veterinario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Veterinario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Veterinario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Veterinario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
