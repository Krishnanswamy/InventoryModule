using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InventoryModule.Models.Masters
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 ProductId { get; set; }

        [Required]
        [ForeignKey("ProductGroup")]
        public int ProductGroupId { get; set;}
        
        [Required]
        public string ProductName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        [Display(Name ="Is this Product Active")]
        public Boolean IsActive { get; set; }

        public virtual ProductGroup ProductGroup { get; set; }
        public ICollection<ProductUnits> ProductUnits { get; set; }
    }
}
