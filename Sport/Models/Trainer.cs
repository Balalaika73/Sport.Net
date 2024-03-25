using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class Trainer
    {
        public Trainer()
        {
            Reviews = new HashSet<Review>();
            TrainerActivities = new HashSet<TrainerActivity>();
        }

        public int IdTrainer { get; set; }
        public string? PhotoTrainer { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<TrainerActivity> TrainerActivities { get; set; }
    }
}
