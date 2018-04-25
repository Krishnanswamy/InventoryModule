using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryModule.Controllers
{
    public class UnitOfMeasureController : Controller
    {
        private Interfaces.IUnitOfMeasure UOMRepository;

        public UnitOfMeasureController (Interfaces.IUnitOfMeasure URepository)
        {
            this.UOMRepository = URepository;
        }


        public ActionResult Index()
        {
            IEnumerable<Models.Masters.UnitOfMeasure> model = UOMRepository.GetAllUnitofMeasure();

            return View(model);
        }

        // GET: UnitOfMeasure/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnitOfMeasure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnitOfMeasure/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Masters.UnitOfMeasure UOM)
        {
            try
            {
                // TODO: Add insert logic here
                UOMRepository.AddUnit(UOM);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Index));
                

            }
            catch
            {
                return View();
            }
        }

        // GET: UnitOfMeasure/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnitOfMeasure/Edit/5
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

        // GET: UnitOfMeasure/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnitOfMeasure/Delete/5
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