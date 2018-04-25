using System;
using System.Collections.Generic;
using System.Linq;
using InventoryModule.Models.Masters;
using Microsoft.EntityFrameworkCore;

namespace InventoryModule.Data
{
    public class UnitOfMeasureRepository : Interfaces.IUnitOfMeasure

    {
        private Models.InventoryContext _context;
        private DbSet<UnitOfMeasure> UOM;

        public UnitOfMeasureRepository(Models.InventoryContext context)
        {
            _context = context;
            UOM = _context.Set<UnitOfMeasure>();

        }

        public void AddUnit(UnitOfMeasure unitOfMeasure)
        {
            _context.Entry(unitOfMeasure).State = EntityState.Added;
            _context.SaveChanges();

        }

        public void DeleteUnit(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UnitOfMeasure> GetAllUnitofMeasure()
        {
            return UOM.AsEnumerable();

        }

        public UnitOfMeasure GetUnitofMeasureById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUnit(int id, UnitOfMeasure unitOfMeasure)
        {
            var p = UOM.SingleOrDefault(x => x.UnitId == id);
            DoUpateUnits(unitOfMeasure, p);

        }

        private void DoUpateUnits(UnitOfMeasure unitOfMeasure, UnitOfMeasure p)
        {
            if (p == null)
            {
               return;
            }
                p.UnitName = unitOfMeasure.UnitName;
                p.UnitDisplayName = unitOfMeasure.UnitDisplayName;
                UOM.Update(p);
                _context.SaveChanges();
            
        }
    }
}
