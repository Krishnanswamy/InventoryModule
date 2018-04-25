using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InventoryModule.Models.Masters
{
    public class ProductGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductGroupID { get; set; }

        [Required]
        [StringLength(100)]
        public String ProductGroupName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public Boolean IsActive { get; set; }

        public ICollection<Products> Product { get; set; }
    }
}
