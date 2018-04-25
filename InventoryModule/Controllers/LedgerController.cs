using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryModule.Models.Masters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryModule.Controllers
{
    public class LedgerController : Controller
    {
        private Interfaces.ILedger _ledger;

        public LedgerController(Interfaces.ILedger ledger)
        {
            _ledger = ledger;
        }

        public ActionResult ShowPartial()
        {
            ViewData["id"] = 1;
            return PartialView("~/Views/LedgerGroup/_create.cshtml");
        }
        // GET: Ledger
        public ActionResult Index()
        {
            IEnumerable<Models.Masters.Ledger> ledgers = _ledger.GetAllLedgers();

            return View("Index",ledgers);
        }

        // GET: Ledger/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ledger/Create
        public ActionResult Create()
        {
          IEnumerable<Models.Masters.LedgerGroup> lgroup = _ledger.PoulateLedgerGroups();
            ViewBag.LedgerGroupId = new  SelectList(lgroup, "LedgerGroupId", "LedgerGroupName");
            return View();
        }

        // POST: Ledger/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ledger ledger)
        {
            try
            {
                // TODO: Add insert logic here
                _ledger.AddLedger(ledger);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ledger/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ledger/Edit/5
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

        // GET: Ledger/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ledger/Delete/5
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