using System;
using System.Collections.Generic;

namespace SpeedTest.Context.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
