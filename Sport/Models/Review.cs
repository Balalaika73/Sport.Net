using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class Review
    {
        public int IdReview { get; set; }
        public DateTime DateWriting { get; set; }
        public string TextReview { get; set; } = null!;
        public int? UserId { get; set; }
        public int? TrainerId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Trainer? Trainer { get; set; }
        public virtual User? User { get; set; }
    }
}
