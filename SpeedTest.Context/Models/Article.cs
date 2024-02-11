using System;
using System.Collections.Generic;

namespace SpeedTest.Context.Models;

public partial class Article
{
    public int ArticleId { get; set; }

    public string ArticleName { get; set; } = null!;

    public string ArticleContent { get; set; } = null!;

    public int AuthorId { get; set; }

    public virtual ICollection<ArticleRating> ArticleRatings { get; set; } = new List<ArticleRating>();

    public virtual Author Author { get; set; } = null!;
}
