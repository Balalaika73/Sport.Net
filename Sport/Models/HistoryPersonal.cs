using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class HistoryPersonal
    {
        public int IdHistoryPers { get; set; }
        public int? UserId { get; set; }
        public int? PersTrainId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual PersonalTraining? PersTrain { get; set; }
        public virtual User? User { get; set; }
    }
}
