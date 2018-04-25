using System;
using System.Collections.Generic;
using System.Linq;
using InventoryModule.Models;
using InventoryModule.Models.Masters;
using Microsoft.EntityFrameworkCore;

namespace InventoryModule.Data
{
    public class LedgerGroupRepository : Interfaces.ILedgerGroup

    {
        private InventoryContext _context;
        private DbSet<LedgerGroup> _ledgerGroup;

        public LedgerGroupRepository(InventoryContext context)
        {
            _context = context;
            _ledgerGroup = _context.Set<LedgerGroup>();


        }

       // public InventoryContext Context { get => _context; set => _context = value; }

        public LedgerGroup AddLedgerGroup(LedgerGroup ledgerGroup)
        {
            var lg = new LedgerGroup
            {
                LedgerGroupName = ledgerGroup.LedgerGroupName
                
            };
            _context.Add(lg);
            _context.SaveChanges();
          //  int id = lg.LedgerGroupId;
            return lg;

        }

        public void DeleteLedgerGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LedgerGroup> GetAllGroup()
        {
            return _ledgerGroup.AsEnumerable();
        }

        public LedgerGroup GetLedgerGroupById(int id)
        {
             var lg = _ledgerGroup.SingleOrDefault(x => x.LedgerGroupId == id);
            return lg;
        }

        public void UpdateLedgerGroup(int id, LedgerGroup ledgerGroup)
        {
          var  lg = GetLedgerGroupById(id);
            lg.LedgerGroupName = ledgerGroup.LedgerGroupName;
            _context.SaveChanges();

        }
    }
}
