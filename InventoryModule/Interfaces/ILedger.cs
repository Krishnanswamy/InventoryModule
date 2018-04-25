using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryModule.Models.Masters;
namespace InventoryModule.Interfaces
{
   public interface ILedger
    {
        void AddLedger(Ledger ledger);
        void Updateledger(int id, Ledger ledger);
        void Deleteledger(int id);
        IEnumerable<Ledger> GetAllLedgers();
        Ledger GetledgerById(int id);
        IEnumerable<LedgerGroup> PoulateLedgerGroups(object selectGroup = null);

    }
}
