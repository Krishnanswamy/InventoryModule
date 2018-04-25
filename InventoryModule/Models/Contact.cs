using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryModule.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }
        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }
    }
}

