INSERT INTO [dbo].[Users] ([UserGuid], [Login])
VALUES
(NEWID(), 'klucyszyn'),
(NEWID(), 'kszumlewicz')

INSERT INTO [dbo].[Books] ([ISBN], [Author], [Title], [Category])
VALUES
('isbn1', 'Author 1', 'Title 1', 0),
('isbn2', 'Author 1', 'Title 2', 0),
('isbn3', 'Author 2', 'Title 3', 1),
('isbn4', 'Author 2', 'Title 4', 2)


INSERT INTO [dbo].[BooksOnLoan]
([IssueDate], [DueReturnDate],[UserId], [BookId])
VALUES    
(GETDATE(), DATEADD(MONTH, 1, GETDATE()), 1, 1)


INSERT INTO [dbo].[UserFavoriteBooks]
([Rate],[UserId],[BookId])
VALUES
(8, 1, 1),
(7, 2, 2)


select * from dbo.[Users]
select * from Books
select * from BooksOnLoan
select * from UserFavoriteBooks

select * from BooksOnLoan
inner join Books on BooksOnLoan.BookId = Books.Id
inner join [Users] on BooksOnLoan.UserId = [Users].Id
 
