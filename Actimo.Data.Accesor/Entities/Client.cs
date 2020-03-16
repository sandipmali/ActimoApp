using System;
using System.Collections.Generic;

namespace Actimo.Data.Accesor.Entities
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public int ActimoManagerContactId { get; set; }
        public int ActimoDummyMessageId { get; set; }
        public string ActimoApikey { get; set; }
    }
}
