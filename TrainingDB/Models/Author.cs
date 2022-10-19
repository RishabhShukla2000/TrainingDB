using System;
using System.Collections.Generic;

namespace TrainingDB.Models
{
    public partial class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public int Experience { get; set; }
        public int? BookId { get; set; }

        public virtual Book? Book { get; set; }
    }
}
