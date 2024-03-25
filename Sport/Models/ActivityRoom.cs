using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class ActivityRoom
    {
        public ActivityRoom()
        {
            GroupTrainings = new HashSet<GroupTraining>();
            PersonalTrainings = new HashSet<PersonalTraining>();
        }

        public int IdActRoom { get; set; }
        public int ActivityId { get; set; }
        public int TypeRoomId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Activity Activity { get; set; } = null!;
        public virtual TypeRoom TypeRoom { get; set; } = null!;
        public virtual ICollection<GroupTraining> GroupTrainings { get; set; }
        public virtual ICollection<PersonalTraining> PersonalTrainings { get; set; }
    }
}
