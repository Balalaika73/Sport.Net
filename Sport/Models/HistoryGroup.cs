using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class HistoryGroup
    {
        public int IdHistoryGroup { get; set; }
        public int? UserId { get; set; }
        public int? GroupTrainId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual GroupTraining? GroupTrain { get; set; }
        public virtual User? User { get; set; }
    }
}
