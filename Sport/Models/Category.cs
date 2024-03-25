using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int IdCategory { get; set; }
        public string NameCategory { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
