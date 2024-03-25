using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class TypeAbonement
    {
        public TypeAbonement()
        {
            Abonements = new HashSet<Abonement>();
        }

        public int IdTypeAbon { get; set; }
        public string NameType { get; set; } = null!;
        public double PriceType { get; set; }
        public bool IsDeleted { get; set; }
        public string? TypeDiscription { get; set; }

        public virtual ICollection<Abonement> Abonements { get; set; }
    }
}
