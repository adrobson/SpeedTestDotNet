CREATE TABLE [dbo].[ArticleRating]
(
	[ArticleRatingId] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [ArticleId] INT NOT NULL,   
    [SiteUserId] INT NOT NULL,
    [Rating] INT NOT NULL, 
    [RatingDate] DATETIME NOT NULL,
    CONSTRAINT [FK_ArticleRating_Article] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article] ([ArticleId]),
    CONSTRAINT [FK_ArticleRating_SiteUser] FOREIGN KEY ([SiteUserId]) REFERENCES [dbo].[SiteUser] ([SiteUserId])
)
