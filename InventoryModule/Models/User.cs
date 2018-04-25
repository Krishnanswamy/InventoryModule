using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryModule.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        [InverseProperty("CreatedBy")]
        public List<Contact> ContactsCreated { get; set; }
        [InverseProperty("UpdatedBy")]
        public List<Contact> ContactsUpdated { get; set; }
    }
}
