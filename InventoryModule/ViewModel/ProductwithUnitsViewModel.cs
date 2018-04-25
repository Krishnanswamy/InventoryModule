using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryModule.Models.Masters;

namespace InventoryModule.ViewModel
{
    public class ProductwithUnitsViewModel
    {[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 ProductId { get; set; }

        [Required]
        [ForeignKey("ProductGroup")]
        [Display(Name = "Product Group")]
        [Range(1,100000,ErrorMessage = "Choose Product Group.")]
        public int ProductGroupId { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Primary Unit")]
        [Range(1,maximum: 10000,ErrorMessage = "Choose Primary Unit.")]
        public  int UnitId { get; set; }

        [Required, Display(Name = "Is this Product Active")]
        public Boolean IsActive { get; set; }

        public string PrimaryUnit { get;set; }

        public virtual ProductGroup ProductGroup { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
