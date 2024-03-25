using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class PurchaseHistory
    {
        public int IdPurHis { get; set; }
        public int? ProductId { get; set; }
        public DateTime BuyDate { get; set; }
        public int Count { get; set; }
        public int? UserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
