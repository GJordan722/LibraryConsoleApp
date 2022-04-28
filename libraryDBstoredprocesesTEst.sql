USE [LibraryDB]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[userCreate] @account_id=1337,@username=N'gbread223',@password=N'passwordpasses',@role_id=3;


GO

USE [LibraryDB]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[checkUserValid] @username=N'gbread223',@password=N'passwordpasses'


GO

USE [LibraryDB]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[deleteUser] @account_id=1337,@username=N'gbread223',@password=N'passwordpasses'



GO

USE [LibraryDB]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[updateMedia] @media_name=N'The Divine Comedy',@media_type=N'Book',@account_id=101


GO
