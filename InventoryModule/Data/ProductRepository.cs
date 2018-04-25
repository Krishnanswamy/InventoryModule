using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Schema;
using InventoryModule.Models.Masters;
using InventoryModule.ViewModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.OData.Query.SemanticAst;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace InventoryModule.Data
{
    public class ProductRepository : Interfaces.IProductInterface
    {
        private Models.InventoryContext _context;
        private DbSet<Products> _products;
        private DbSet<UnitOfMeasure> _uom;
        private DbSet<ProductGroup> _productGroups;

        public ProductRepository(Models.InventoryContext context)
        {
            _context = context;
            _products = _context.Set<Products>();
            _uom= _context.Set<UnitOfMeasure>();
            _productGroups = _context.Set<ProductGroup>();
        }

        public void AddProuct(ProductwithUnitsViewModel products)
        {
            var p = new Models.Masters.Products
            {
                ProductGroupId = products.ProductGroupId,
                ProductName = products.ProductName,
                IsActive = products.IsActive,
                ProductUnits = new List<ProductUnits>
                {
                    new ProductUnits {IsThisPrimaryUnit = true, UnitId = products.UnitId}
                }
            };
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public IEnumerable<ViewModel.ProductwithUnitsViewModel> GetAllProducts()
        {
            //var p = (from g in _products select g)
            //    .Include(x => x.ProductGroup)
            //    .Include(x => x.ProductUnits.Select(y => y.IsThisPrimaryUnit == true)
               
                
            //    ).ToList();
            var p = from g in _products .Include(x =>x.ProductGroup) .Include(y=>y.ProductUnits)
                select new ProductwithUnitsViewModel
                {
                    ProductId = g.ProductId,
                    ProductGroupId = g.ProductGroupId,
                    ProductName = g.ProductName,
                    ProductGroup = g.ProductGroup,
                    IsActive = g.IsActive,
                   PrimaryUnit = g.ProductUnits.Where(i=>i.IsThisPrimaryUnit==true).Select(z=>z.UnitOfMeasure.UnitDisplayName ).SingleOrDefault()
                };

                        return p;
        }

        public ViewModel.ProductwithUnitsViewModel GetProductsbyId(int? id)
        {
            var p = _products.Include(x => x.ProductUnits).SingleOrDefault(x => x.ProductId == id);
            //if (p == null)
            //{
            //    throw new Exception("Not Found");
            //}
            var pw = new ViewModel.ProductwithUnitsViewModel
            {
                ProductGroupId = p.ProductGroupId,
                ProductName = p.ProductName,
                IsActive = p.IsActive,
                UnitId = p.ProductUnits.Where(x=>x.IsThisPrimaryUnit=true).Select(units => units.UnitId).SingleOrDefault()          
            };
            return pw;
            //  var p = UOM.SingleOrDefault(x => x.UnitId == id);
        }

        public IEnumerable<Models.Masters.ProductGroup> PopulateProductGroups(object selectGroup = null)
        {
            var group = from g in _context.ProductGroup orderby g.ProductGroupName
                select g;
          
            return group.ToList();
        }

        public IEnumerable<UnitOfMeasure> PopulateUnits(object selectGroup = null)
        {
            var uom = from u in _context.UnitOfMeasure orderby u.UnitName select u;
            return uom;
        }

        public bool ProductExist(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int id, ProductwithUnitsViewModel products)
        {
            var p = (from g in _context.Products where g.ProductId == id select g).SingleOrDefault();
            if (p == null) { throw new Exception("Not Found."); }

          ProductUnits   u = (from i in _context.ProductUnits where i.IsThisPrimaryUnit==true
                where i.ProductId==p.ProductId select i).SingleOrDefault();

            p.ProductUnits.Remove(u);
            _context.SaveChanges();
            //foreach (var rw in u )
            //{
            //    _context.ProductUnits.Remove(rw);
            //}

            


            p.ProductGroupId = products.ProductGroupId;
            p.ProductName = products.ProductName;
            p.IsActive = products.IsActive;
            p.ProductUnits = new List<ProductUnits>
            {
                new ProductUnits {IsThisPrimaryUnit = true, UnitId = products.UnitId}
            };
            _context.SaveChanges();
        }
    }
}
