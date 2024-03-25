using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class User
    {
        public User()
        {
            Abonements = new HashSet<Abonement>();
            HistoryGroups = new HashSet<HistoryGroup>();
            HistoryPersonals = new HashSet<HistoryPersonal>();
            PurchaseHistories = new HashSet<PurchaseHistory>();
            Reviews = new HashSet<Review>();
            Trainers = new HashSet<Trainer>();
        }

        public int IdUser { get; set; }
        public string NameUser { get; set; } = null!;
        public string SurUser { get; set; } = null!;
        public string? MiddleUser { get; set; }
        public string EmailUser { get; set; } = null!;
        public string PhoneNumb { get; set; } = null!;
        public DateTime BdUser { get; set; }
        public string PassUser { get; set; } = null!;
        public int RoleId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Abonement> Abonements { get; set; }
        public virtual ICollection<HistoryGroup> HistoryGroups { get; set; }
        public virtual ICollection<HistoryPersonal> HistoryPersonals { get; set; }
        public virtual ICollection<PurchaseHistory> PurchaseHistories { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
