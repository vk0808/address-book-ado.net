CREATE PROCEDURE [dbo].[SpAddPersonDetails]
(
	@FirstName VARCHAR(255),
	@LastName VARCHAR(255),
	@Address VARCHAR(250),
	@City VARCHAR(100),
	@State VARCHAR(100),
	@Zip VARCHAR(6),
	@PhoneNumber VARCHAR(12),
	@Email VARCHAR(100),
	@BookName VARCHAR(20),
	@BookType VARCHAR(10) 
)
AS
BEGIN
	INSERT INTO address VALUES
	(@FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @Email, @BookName, @BookType)
END
GO