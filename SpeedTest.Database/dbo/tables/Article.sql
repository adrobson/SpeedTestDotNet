CREATE TABLE [dbo].[Article]
(
	[ArticleId] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [ArticleName] NVARCHAR(50) NOT NULL, 
    [ArticleContent] NVARCHAR(MAX) NOT NULL, 
    [AuthorId] INT NOT NULL
    CONSTRAINT [FK_Article_Author] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Author] ([AuthorId])
)
