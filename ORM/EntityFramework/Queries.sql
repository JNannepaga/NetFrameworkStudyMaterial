Use EF_FAPI_One_One_Mapping
GO

Select * from Customer
Select * from CustomerRequisite
Select * from Catelogs

USE EF_One_One_Mapping
GO
ALTER DATABASE EF_DAA_One_Many_Mapping
SET SINGLE_USER
WITH ROLLBACK IMMEDIATE 
GO
DROP DATABASE EF_DAA_One_Many_Mapping
GO

DROP Procedure SP_RegularCustomer_Insert
DROP Procedure SP_CustomerRequisite_Insert
DROP Procedure SP_CustomerCateloges_Insert

CREATE PROCEDURE SP_Customer_Insert(
@FirstName VARCHAR(50), 
@LastName VARCHAR(50),
@Gender INT
)
AS
BEGIN
INSERT INTO Customers (FirstName, LastName, Gender) Values (@FirstName+'SP', @LastName, @Gender)
END
GO


CREATE PROCEDURE SP_RegularCustomer_Insert(
@AdvCredits MONEY,
@Perks VARCHAR(25)
)
AS
BEGIN
INSERT INTO RegularCustomers (AdvCredits, Perks) Values (@AdvCredits, @Perks+'SP')
END
GO

CREATE PROCEDURE SP_CustomerRequisite_Insert(
@MobileNum VARCHAR(10),
@IdProofType INT,
@IdProof VARCHAR(25)
)

AS
BEGIN
INSERT INTO CustomerRequisite(MobileNum, IdProofType, IdProof) Values(@MobileNum, @IdProofType, @IdProof+'SP')
END
GO

CREATE PROCEDURE SP_CustomerCateloges_Insert(
@CatelogName VARCHAR(25),
@CatelogPassword VARCHAR(25),
@isActivated BIT
)

AS
BEGIN
INSERT INTO CustomerCateloges(CatelogName, CatelogPassword, isActivated) 
VALUES (@CatelogName+'SP', @CatelogPassword+'SP', @isActivated)
END
GO

Select * from Customer
Select * from GeneralCustomer
Select * from RegularCustomer
 
 SP_HELPTEXT SP_GeneralCustomer_Insert
 SP_HELPTEXT SP_RegularCustomer_Insert

exec [dbo].[SP_GeneralCustomer_Insert] @FirstName='Shreya',@LastName='Nans',@Gender=1,@Credits=10.0000,@NormalCoupon='Order 40'
go
exec [dbo].[SP_CustomerRequisite_Insert] @CustomerId=7,@MobileNum='9676518138',@IdProofType=0,@IdProof='2567810986'
go
exec [dbo].[SP_RegularCustomer_Insert] @FirstName=N'Shreya',@LastName=N'Nans',@Gender=1,@AdvCredits=150.0000,@Perks='Swiggle'
go
exec [dbo].[SP_CustomerCateloges_Insert] @CatelogId=4,@CatelogName='SplZone',@CatelogPassword='ABC123',@isActivated=1
go
exec [dbo].[SP_CustomerRequisite_Insert] @CustomerId=4,@MobileNum='9676518138',@IdProofType=1,@IdProof='AQXPN5630N'
go
