using System.Collections.Generic;

namespace Actimo.Business.Models
{
    public class ContactMangerModel
    {
        public int? contactId { get; set; }
        public string type { get; set; }        
        public string contactName { get; set; }
        public string contactType { get; set; }
    }

    public class ContactMangerRoot
    {
        public string status { get; set; }
        public List<ContactMangerModel> data { get; set; }
    }
}
