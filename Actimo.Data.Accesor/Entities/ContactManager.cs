﻿using System;
using System.Collections.Generic;

namespace Actimo.Data.Accesor.Entities
{
    public partial class ContactManager
    {
        public int? ClientId { get; set; }
        public string ContactManagerId { get; set; }
        public int? ContactId { get; set; }
        public string Type { get; set; }
        public string ContactName { get; set; }
        public string ContactType { get; set; }
    }
}
