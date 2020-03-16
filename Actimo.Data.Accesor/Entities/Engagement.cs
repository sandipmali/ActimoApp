using System;
using System.Collections.Generic;

namespace Actimo.Data.Accesor.Entities
{
    public partial class Engagement
    {
        public int? ClientId { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public decimal? Value { get; set; }
        public int? UpperThreshold { get; set; }
        public int? LowerThreshold { get; set; }
        public string Suffix { get; set; }
    }
}
