using System.Collections.Generic;

namespace Actimo.Business.Models
{
    public class RelationshipModel
    {
        public int? contactId { get; set; }
        public string type { get; set; }        
        public string contactName { get; set; }
        public string contactType { get; set; }
    }

    public class RelationshipRoot
    {
        public string status { get; set; }
        public List<RelationshipModel> data { get; set; }
    }
}
