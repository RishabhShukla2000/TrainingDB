using System;
using System.Collections.Generic;

namespace TrainingDB.Models
{
    public partial class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public int? CategoryId { get; set; }

        public virtual Book? Category { get; set; }
    }
}
