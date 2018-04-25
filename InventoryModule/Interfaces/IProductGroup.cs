using System;
using InventoryModule.Models.Masters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryModule.Interfaces
{
   public interface IProductGroup
    {
        void AddProductGroup(ProductGroup productGroup);
        void UpdateProductGroup(int id, ProductGroup productGroup);
        void DeleteProductGroup(int id);
        IEnumerable<ProductGroup> getAllGroup();
        ProductGroup getProductGroupById(int id);
    }
} 
