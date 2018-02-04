CREATE TABLE [dbo].[Student]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(150) NOT NULL, 
    [LastName] NVARCHAR(150) NOT NULL, 
    [Phone] NVARCHAR(10) NULL, 
    [Mobile ] NVARCHAR(15) NULL, 
    [Address] NVARCHAR(70) NULL, 
    [CourseId] INT NULL, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [Approved] BIT NULL, 
    CONSTRAINT [FK_User_ToTable] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([Id])
)
