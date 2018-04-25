using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryModule.Models.Masters;
using InventoryModule.ViewModel;

namespace InventoryModule.Interfaces
{
    public interface IProductInterface
    {
        void AddProuct(ProductwithUnitsViewModel products);
        void UpdateProduct(int id, ProductwithUnitsViewModel products);
        IEnumerable<ProductwithUnitsViewModel> GetAllProducts();
        ProductwithUnitsViewModel GetProductsbyId(int? id);
        void RemoveProduct(int id);
        bool ProductExist(int id);

        //for Product group Selct list
        IEnumerable<Models.Masters.ProductGroup> PopulateProductGroups(object selectGroup = null);
        
        //for Units selct list
        IEnumerable<Models.Masters.UnitOfMeasure> PopulateUnits(object selectGroup = null);

        //object GetProductsbyId(int? id);
    }
}
