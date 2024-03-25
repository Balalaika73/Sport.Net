using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class Activity
    {
        public Activity()
        {
            ActivityRooms = new HashSet<ActivityRoom>();
            TrainerActivities = new HashSet<TrainerActivity>();
        }

        public int IdActivity { get; set; }
        public string NameActivity { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<ActivityRoom> ActivityRooms { get; set; }
        public virtual ICollection<TrainerActivity> TrainerActivities { get; set; }
    }
}
