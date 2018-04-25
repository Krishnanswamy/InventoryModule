using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryModule.Models;
using InventoryModule.Models.Masters;
using Microsoft.EntityFrameworkCore;

namespace InventoryModule.Data
{
    public class LedgerRepository : Interfaces.ILedger


    {
        private DbSet<Ledger> _ledgers;
        
        private Models.InventoryContext _context;
        public LedgerRepository(Models.InventoryContext context)
        {
            _ledgers = context.Set<Models.Masters.Ledger>();
            _context = context;
        }
        public void AddLedger(Ledger ledger)
        {
            var l = new Ledger
            {
                LedgerGroupId = ledger.LedgerGroupId,
                LedgerName = ledger.LedgerName,
                IsActive = ledger.IsActive
            };
          _context.Ledgers.Add(l);
          _context.SaveChanges();
        }

        public void Deleteledger(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ledger> GetAllLedgers()
        {
            return _ledgers.AsEnumerable();
        }

        public Ledger GetledgerById(int id)
        {
            throw new NotImplementedException();
        }

        public void Updateledger(int id, Ledger ledger)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LedgerGroup> PoulateLedgerGroups(object selectGroup = null)
        {
            var lgroup = from l in _context.LedgerGroups orderby l.LedgerGroupName select l;
            return lgroup;


        }
       
    }

}
