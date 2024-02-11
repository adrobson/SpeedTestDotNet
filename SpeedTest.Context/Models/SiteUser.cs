using System;
using System.Collections.Generic;

namespace SpeedTest.Context.Models;

public partial class SiteUser
{
    public int SiteUserId { get; set; }

    public string? SiteUserName { get; set; }

    public virtual ICollection<ArticleRating> ArticleRatings { get; set; } = new List<ArticleRating>();
}
