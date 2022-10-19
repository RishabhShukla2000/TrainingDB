using System;
using System.Collections.Generic;

namespace TrainingDB.Models
{
    public partial class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
            SubCategories = new HashSet<SubCategory>();
        }

        public int BookId { get; set; }
        public string BookReferenceNo { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int NumberOfPages { get; set; }
        public int NumberOfVolume { get; set; }
        public DateTime PublishDate { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
