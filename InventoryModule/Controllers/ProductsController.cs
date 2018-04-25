using System;
using System.Collections.Generic;
using InventoryModule.Interfaces;
using InventoryModule.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryModule.Controllers
{
    public class ProductsController : Controller
    {
        private IProductInterface _context;

       // public IProductInterface Context { get => _context; set => _context = value; }

        public ProductsController(IProductInterface productRepository) => _context = productRepository;

        // GET: Products
        public ActionResult Index()
        {
            IEnumerable<ProductwithUnitsViewModel> products = _context.GetAllProducts();
            return View("Index",products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            IEnumerable<Models.Masters.ProductGroup> groups = _context.PopulateProductGroups();
           ViewBag.ProductGroupId = new SelectList(groups, "ProductGroupID", "ProductGroupName");

            IEnumerable<Models.Masters.UnitOfMeasure> uom = _context.PopulateUnits();
            ViewBag.UnitId = new SelectList(uom, "UnitId", "UnitName");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductwithUnitsViewModel products)
        {
            try
            {
                // TODO: Add insert logic here
               _context.AddProuct(products);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Models.Masters.ProductGroup> groups = _context.PopulateProductGroups();
            ViewBag.ProductGroupId = new SelectList(groups, "ProductGroupID", "ProductGroupName");

            IEnumerable<Models.Masters.UnitOfMeasure> uom = _context.PopulateUnits();
            ViewBag.UnitId = new SelectList(uom, "UnitId", "UnitName");

            ProductwithUnitsViewModel products = _context.GetProductsbyId(id);
            return View(products);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductwithUnitsViewModel products )
        {
            try
            {
                // TODO: Add update logic here
                _context.UpdateProduct(id,products);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost, ValidateAntiForgeryToken]
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