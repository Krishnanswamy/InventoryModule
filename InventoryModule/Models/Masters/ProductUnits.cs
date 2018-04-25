using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryModule.Models.Masters
{
    public class ProductUnits 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductUnitKey { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }

        [ForeignKey("UnitOfMeasure")]
        public int UnitId { get; set; }


        [Required]
        public bool IsThisPrimaryUnit { get; set; }

        public Products Products { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        //[InverseProperty("PrimaryUnit")]
        //public List<UnitofMeasureRelations> PrimaryUnit { get; set; }

        //[InverseProperty("AlternateUnit")]
        //public List<UnitofMeasureRelations> AlternateUnit { get; set; }
    }

}

