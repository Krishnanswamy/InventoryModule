using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace InventoryModule.Models.Masters
{
    public class LedgerGroup
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int LedgerGroupId { get; set; }
        
        [Required,StringLength(100)]
        public string LedgerGroupName { get; set; }

        public ICollection<Ledger> Ledgers { get; set; }
    }
}
