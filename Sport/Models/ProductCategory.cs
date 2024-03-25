using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class ProductCategory
    {
        public int IdProdCat { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Product? Product { get; set; }
    }
}
