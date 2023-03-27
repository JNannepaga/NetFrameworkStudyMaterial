Use EF_DAA_One_One_Mapping
GO

Select * from Customer
Select * from CustomerRequisite
Select * from Catelogs

USE EF_One_One_Mapping
GO
ALTER DATABASE EF_DAA_One_One_Mapping
SET SINGLE_USER
WITH ROLLBACK IMMEDIATE 
GO
DROP DATABASE EF_DAA_One_One_Mapping
GO

DROP Procedure SP_RegularCustomer_Insert
DROP Procedure SP_CustomerRequisite_Insert
DROP Procedure SP_CustomerCateloges_Insert

CREATE PROCEDURE SP_RegularCustomer_Insert(
@FirstName VARCHAR(50), 
@LastName VARCHAR(50),
@Gender INT, 
@AdvCredits MONEY,
@Perks VARCHAR(25)
)
AS
BEGIN
INSERT INTO Customers (FirstName, LastName, Gender) Values (@FirstName, @LastName, @Gender)
INSERT INTO RegularCustomers (AdvCredits, Perks) Values (@AdvCredits, @Perks)
END
GO

CREATE PROCEDURE SP_CustomerRequisite_Insert(
@MobileNum VARCHAR(10),
@IdProofType INT,
@IdProof VARCHAR(25)
)

AS
BEGIN
INSERT INTO CustomerRequisite(MobileNum, IdProofType, IdProof) Values(@MobileNum, @IdProofType, @IdProof)
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
VALUES (@CatelogName, @CatelogPassword, @isActivated)
END
GO

 
Truncate Table Customer
Truncate Table RegularCustomer
Truncate Table GeneralCustomer
Truncate Table CustomerRequisite
Truncate Table Catelogs
