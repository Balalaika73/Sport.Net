using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class GroupTraining
    {
        public GroupTraining()
        {
            HistoryGroups = new HashSet<HistoryGroup>();
        }

        public int IdGroupTrain { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public int Capacity { get; set; }
        public string NameTrain { get; set; } = null!;
        public int TrainerActId { get; set; }
        public int ActRoomId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ActivityRoom ActRoom { get; set; } = null!;
        public virtual TrainerActivity TrainerAct { get; set; } = null!;
        public virtual ICollection<HistoryGroup> HistoryGroups { get; set; }
    }
}
