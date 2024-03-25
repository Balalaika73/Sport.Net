using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class PersonalTraining
    {
        public PersonalTraining()
        {
            HistoryPersonals = new HashSet<HistoryPersonal>();
        }

        public int IdPersTrain { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public int? TrainerActId { get; set; }
        public int? ActRoomId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ActivityRoom? ActRoom { get; set; }
        public virtual TrainerActivity? TrainerAct { get; set; }
        public virtual ICollection<HistoryPersonal> HistoryPersonals { get; set; }
    }
}
