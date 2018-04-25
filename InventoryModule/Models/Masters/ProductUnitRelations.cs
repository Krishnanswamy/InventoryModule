using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryModule.Models.Masters
{
    public class ProductUnitRelations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductUnitRelationsKey {get; set; }
        public  int PrimaryProductunitKey { get; set; }
        public int AlternateProductunitKey { get; set; }

        
        public decimal PrimaryValue { get; set; }
        public decimal AlternateValue { get; set; }

        
        public   ProductUnits PrimaryUnit { get; set; }
        public  ProductUnits AlternateUnit { get; set; }


       

    }
}
