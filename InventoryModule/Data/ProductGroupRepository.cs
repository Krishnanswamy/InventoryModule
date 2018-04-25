using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryModule.Models.Masters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryModule.Data
{
    public class ProductGroupRepository : Interfaces.IProductGroup
    {
        private Models.InventoryContext _context;
        private DbSet<ProductGroup> pGroup;
        public ProductGroupRepository(Models.InventoryContext Context)
        {
            this._context = Context;
            pGroup = _context.Set<ProductGroup>();
                    }

        
        public void  AddProductGroup(ProductGroup productGroup)
        {
            int id = 0;
            _context.Entry(productGroup).State = EntityState.Added;

             id =     _context.SaveChanges();
            //  return  new JsonResult(id);
            //return id;



        }

        public void DeleteProductGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductGroup> getAllGroup()
        {
            return pGroup.AsEnumerable();

        }

        public ProductGroup getProductGroupById(int id)
        {
            return (pGroup.Find(id));


        }

        public void UpdateProductGroup(int id, ProductGroup productGroup)
        {
            var p = pGroup.SingleOrDefault(x => x.ProductGroupID == id);
            p.ProductGroupName = productGroup.ProductGroupName;
            p.IsActive = productGroup.IsActive;
            p.ModifiedDate = DateTime.Today;
            pGroup.Update(p);
            _context.SaveChanges();
        }
    }
}
