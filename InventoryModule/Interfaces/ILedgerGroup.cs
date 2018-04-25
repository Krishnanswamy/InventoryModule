using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryModule.Models.Masters;

namespace InventoryModule.Interfaces
{
  public  interface ILedgerGroup
    {

        LedgerGroup AddLedgerGroup(LedgerGroup ledgerGroup);
        void UpdateLedgerGroup(int id, LedgerGroup ledgerGroup);
        void DeleteLedgerGroup(int id);
        IEnumerable<LedgerGroup> GetAllGroup();
        LedgerGroup GetLedgerGroupById(int id);
    }
}
