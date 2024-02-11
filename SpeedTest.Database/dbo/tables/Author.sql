CREATE TABLE [dbo].[Author]
(
	[AuthorId] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [AuthorName] NVARCHAR(100) NOT NULL, 
    [CompanyId] INT NOT NULL,
    CONSTRAINT [FK_Author_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([CompanyId])
)
