using System;
using System.Collections.Generic;

namespace SpeedTest.Context.Models;

public partial class ArticleRating
{
    public int ArticleRatingId { get; set; }

    public int ArticleId { get; set; }

    public int SiteUserId { get; set; }

    public int Rating { get; set; }

    public DateTime RatingDate { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual SiteUser SiteUser { get; set; } = null!;
}
