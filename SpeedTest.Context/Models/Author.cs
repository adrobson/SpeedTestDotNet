using System;
using System.Collections.Generic;

namespace SpeedTest.Context.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = null!;

    public int CompanyId { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual Company Company { get; set; } = null!;
}
