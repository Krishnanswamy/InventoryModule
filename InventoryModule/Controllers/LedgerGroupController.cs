using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryModule.Models.Masters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryModule.Controllers
{
    public class LedgerGroupController : Controller
    {
        private Interfaces.ILedgerGroup _context;

        public LedgerGroupController(Interfaces.ILedgerGroup context)
        {
            _context = context;
        }
        // GET: LedgerGroup
        public ActionResult Index()
        {
            IEnumerable<Models.Masters.LedgerGroup> lg = _context.GetAllGroup();
            return View("Index",lg);
        }

        // GET: LedgerGroup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LedgerGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LedgerGroup/Create
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult CreateGroup(LedgerGroup ledgerGroup,int? id=0)
        {
            //int i = 1;
            if (ledgerGroup == null) return Json("No Data");

            LedgerGroup lg = _context.AddLedgerGroup(ledgerGroup);
            if (id == 0)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json(lg);
                //return RedirectToAction("Create","Ledger");

            }
            //  return Json(ledgerGroup.LedgerGroupName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        

        // GET: LedgerGroup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LedgerGroup/Edit/5
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

        // GET: LedgerGroup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LedgerGroup/Delete/5
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