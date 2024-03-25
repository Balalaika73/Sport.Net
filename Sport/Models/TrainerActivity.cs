using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class TrainerActivity
    {
        public TrainerActivity()
        {
            GroupTrainings = new HashSet<GroupTraining>();
            PersonalTrainings = new HashSet<PersonalTraining>();
        }

        public int IdTrainerAct { get; set; }
        public int? ActivityId { get; set; }
        public int? TrainerId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Activity? Activity { get; set; }
        public virtual Trainer? Trainer { get; set; }
        public virtual ICollection<GroupTraining> GroupTrainings { get; set; }
        public virtual ICollection<PersonalTraining> PersonalTrainings { get; set; }
    }
}
