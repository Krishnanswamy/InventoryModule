using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryModule.Models.Masters
{
    public class UnitOfMeasure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnitId { get; set; }

        [Required]
        [StringLength(20)]
        public string UnitName { get; set; }

        [Required]
        public string UnitDisplayName { get; set; }
        public ICollection<Masters.ProductUnits> ProductUnits { get; set; }

    }
}
