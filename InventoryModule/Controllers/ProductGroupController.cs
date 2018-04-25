using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryModule.Controllers
{
    public class ProductGroupController : Controller
    {
        private Interfaces.IProductGroup productGroupRepository;
        public ProductGroupController(Interfaces.IProductGroup repository)
        {
            this.productGroupRepository = repository;

        }
        // GET: ProductGroup
        public ActionResult Index()
        {
         IEnumerable<Models.Masters.ProductGroup> model=    productGroupRepository.getAllGroup();
            return View("Index", model);
        }

        // GET: ProductGroup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductGroup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ProductGroupName,IsActive")] Models.Masters.ProductGroup pvalues)
        {
            if (pvalues == null)
            {
                throw new ArgumentNullException(nameof(pvalues));
            }

            try
            {
                // int id = 0;
                // TODO: Add insert logic here
                pvalues.CreatedDate = DateTime.Today;
                pvalues.ModifiedDate = DateTime.Today;
               productGroupRepository.AddProductGroup(pvalues);


                //return View("Index");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: ProductGroup/Edit/5
        public ActionResult Edit(int id)
        {
            Models.Masters.ProductGroup model = productGroupRepository.getProductGroupById(id);
            return View(model);
        }

        // POST: ProductGroup/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[Bind("ProductGroupName,IsActive")] Models.Masters.ProductGroup pvalues)
        {
            try
            {
                // TODO: Add update logic here
                productGroupRepository.UpdateProductGroup(id, pvalues);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductGroup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductGroup/Delete/5
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