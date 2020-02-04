INSERT INTO [dbo].[User] ([Id], [Login])
VALUES
(NEWID(), 'klucyszyn'),
(NEWID(), 'kszumlewicz')

INSERT INTO [dbo].[Book] ([ISBN], [Author], [Title], [Category])
VALUES
('isbn1', 'Author 1', 'Title 1', 0),
('isbn2', 'Author 1', 'Title 2', 0),
('isbn3', 'Author 2', 'Title 3', 1),
('isbn4', 'Author 2', 'Title 4', 2)


INSERT INTO [dbo].[BookOnLoan]
([IssueDate], [DueReturnDate],[UserId], [BookISBN])
VALUES    
(GETDATE(), DATEADD(MONTH, 1, GETDATE()), 'D0F4EB79-4AC6-41E4-8F12-DD5FAFA9474A', 'isbn1')


INSERT INTO [dbo].[UserFavoriteBook]
([Rate],[UserId],[BookISBN])
VALUES
(8, 'FB1691EA-32A8-474E-A2B6-E6A25C7CC56B', 'isbn1'),
(7, 'D0F4EB79-4AC6-41E4-8F12-DD5FAFA9474A', 'isbn2')


select * from dbo.[User]
select * from Book
select * from BookOnLoan
select * from UserFavoriteBook

select * from BookOnLoan
inner join Book on BookOnLoan.BookISBN = Book.ISBN
inner join [User] on BookOnLoan.UserId = [User].Id 
