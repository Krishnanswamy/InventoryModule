using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace InventoryModule.Models.Masters
{
    public class UnitofMeasureRelations
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int UnitofMeasureRelationsId { get; set; }

        public int PrimaryUnitId { get; set; }
        public  decimal PrimaryUnitValue { get; set; }

        public int AlternateUnitId { get; set; }
        public  decimal AlternateUnitValue { get; set; }

        //[ForeignKey("PrimaryUnitId")]
        //public  ProductUnits PrimaryUnit { get; set; }
        //[ForeignKey("AlternateUnitId")]
        //public  ProductUnits AlternateUnit { get; set; }
    }
}
