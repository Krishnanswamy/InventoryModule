using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryModule.Models.Masters;

namespace InventoryModule.Interfaces
{
    public interface IUnitOfMeasure
    {
        void AddUnit(UnitOfMeasure unitOfMeasure);
        void UpdateUnit(int id, UnitOfMeasure unitOfMeasure);
        void DeleteUnit(int id);
        IEnumerable <UnitOfMeasure> GetAllUnitofMeasure();
        UnitOfMeasure GetUnitofMeasureById(int id);


    }
}
