using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryModule.Models.Masters
{
    public class Ledger
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int LedgerId { get; set; }
        [ForeignKey("LedgerGroup")]
        public int LedgerGroupId { get; set; }

        [Required,StringLength(200)]
        public string LedgerName { get; set; }

        [StringLength(400)]
        public String Address { get; set; }

        [EmailAddress]
        public String Email { get; set; }

        [Display(Name = "Is this Ledger Active")]
        public bool IsActive { get; set; }

        public  LedgerGroup LedgerGroups { get; set; }

    }

}
