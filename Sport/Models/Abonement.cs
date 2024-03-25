using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class Abonement
    {
        public int IdAbonement { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public double? FinishPrice { get; set; }
        public int UserId { get; set; }
        public int TypeAbonId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual TypeAbonement TypeAbon { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
