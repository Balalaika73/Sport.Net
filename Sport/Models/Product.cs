using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductCategories = new HashSet<ProductCategory>();
            PurchaseHistories = new HashSet<PurchaseHistory>();
        }

        public int IdProduct { get; set; }
        public string NameProduct { get; set; } = null!;
        public double Price { get; set; }
        public double Gramms { get; set; }
        public string? Discription { get; set; }
        public string PhotoProduct { get; set; } = null!;
        public int CountProduct { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<PurchaseHistory> PurchaseHistories { get; set; }
    }
}
