
USE [AdventureWorksLT2019]
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'SalesLT', @level1type=N'TABLE',@level1name=N'CustomerAddress', @level2type=N'CONSTRAINT',@level2name=N'FK_CustomerAddress_Customer_CustomerID'
GO

ALTER TABLE [SalesLT].[CustomerAddress] DROP CONSTRAINT [FK_CustomerAddress_Customer_CustomerID]
GO

ALTER TABLE [SalesLT].[CustomerAddress]  WITH NOCHECK ADD  CONSTRAINT [FK_CustomerAddress_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [SalesLT].[Customer] ([CustomerID])ON Delete cascade
GO

ALTER TABLE [SalesLT].[CustomerAddress] CHECK CONSTRAINT [FK_CustomerAddress_Customer_CustomerID]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key constraint referencing Customer.CustomerID.' , @level0type=N'SCHEMA',@level0name=N'SalesLT', @level1type=N'TABLE',@level1name=N'CustomerAddress', @level2type=N'CONSTRAINT',@level2name=N'FK_CustomerAddress_Customer_CustomerID'
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'SalesLT', @level1type=N'TABLE',@level1name=N'CustomerAddress', @level2type=N'CONSTRAINT',@level2name=N'FK_CustomerAddress_Address_AddressID'
GO

ALTER TABLE [SalesLT].[CustomerAddress] DROP CONSTRAINT [FK_CustomerAddress_Address_AddressID]
GO

ALTER TABLE [SalesLT].[CustomerAddress]  WITH noCHECK ADD  CONSTRAINT [FK_CustomerAddress_Address_AddressID] FOREIGN KEY([AddressID])
REFERENCES [SalesLT].[Address] ([AddressID]) on delete cascade
GO

ALTER TABLE [SalesLT].[CustomerAddress] CHECK CONSTRAINT [FK_CustomerAddress_Address_AddressID]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key constraint referencing Address.AddressID.' , @level0type=N'SCHEMA',@level0name=N'SalesLT', @level1type=N'TABLE',@level1name=N'CustomerAddress', @level2type=N'CONSTRAINT',@level2name=N'FK_CustomerAddress_Address_AddressID'
GO


CREATE PROCEDURE [dbo].[DeleteCustomers]

 @custID int,
 @addressID int
 as
 	DELETE FROM saleslt.Customer WHERE CustomerID= @custID
	delete from SalesLT.CustomerAddress where CustomerID = @custID
	delete from SalesLT.[Address] where AddressID = @addressID
	delete from SalesLT.SalesOrderHeader where CustomerID = @custID

GO


CREATE PROCEDURE [dbo].[getlastCustID]
as select top 1 SalesLT.Customer.CustomerID from SalesLT.Customer order by CustomerID desc
go

CREATE PROCEDURE [dbo].[getlastaddID] as select top 1 SalesLT.[Address].AddressID from SalesLT.[Address] order by AddressID desc

GO

CREATE PROCEDURE [dbo].[GetCustomers]
as
SELECT 
	   SalesLT.[Customer].CustomerID
      ,[Title]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[Suffix]
      ,[CompanyName]
      ,[SalesPerson]
      ,[EmailAddress]
      ,[Phone]
      ,[PasswordHash]
      ,[PasswordSalt]
      ,SalesLT.CustomerAddress.[AddressID]
      ,[AddressType]
	  ,[AddressLine1]
      ,[AddressLine2]
      ,[City]
      ,[StateProvince]
      ,[CountryRegion]
      ,[PostalCode]
	  ,SalesLT.[Customer].[rowguid]
	  ,SalesLT.Customer.ModifiedDate



  FROM (([AdventureWorksLT2019].[SalesLT].[Customer]
  left outer join SalesLT.CustomerAddress on SalesLT.Customer.CustomerID = SalesLT.CustomerAddress.CustomerID)
  left outer join SalesLT.[Address] on SalesLT.CustomerAddress.AddressID = SalesLT.[Address].AddressID)
GO

create view [dbo].[productView]
as
SELECT 
ProductID,
[Product].[Name]as 'product name', 
ProductCategory.[Name] as 'catigory name',
Color,
Size,
[Weight],
ListPrice,
ProductDescription.[Description],
StandardCost,
ProductNumber,
SellStartDate,
SellEndDate,
Product.rowguid

from ((((SalesLT.Product
inner join SalesLT.ProductModel on SalesLT.Product.ProductModelID = SalesLT.ProductModel.ProductModelID)
inner join SalesLT.ProductCategory on SalesLT.Product.ProductCategoryID = SalesLT.ProductCategory.ProductCategoryID)
inner join SalesLT.ProductModelProductDescription on SalesLT.ProductModel.ProductModelID =SalesLT.ProductModelProductDescription.ProductModelID)
inner join SalesLT.ProductDescription on SalesLT.ProductModelProductDescription.ProductDescriptionID = SalesLT.ProductDescription.ProductDescriptionID)
where Culture = 'en'
GO


create PROCEDURE [dbo].[getProducts]
as
SELECT TOP (1000) [ProductID]
      ,[product name]
      ,[catigory name]
      ,[Color]
      ,[Size]
      ,[Weight]
      ,[ListPrice]
      ,[Description]
      ,[StandardCost]
      ,[ProductNumber]
      ,[SellStartDate]
      ,[SellEndDate]
      ,[rowguid]
  FROM [AdventureWorksLT2019].[dbo].[productView]
GO

CREATE PROCEDURE  [dbo].[InsertAddress]
       @addressLine1 NVARCHAR(40)
      ,@addressLine2 NVARCHAR(40)
      ,@city NVARCHAR(40)
      ,@stateProvince NVARCHAR(40)
      ,@countryRegion NVARCHAR(40)
      ,@postalCode NVARCHAR(40)
      ,@ModifiedDate NVARCHAR(40)
	  as
	  insert into SalesLT.[Address] (AddressLine1, AddressLine2, City, StateProvince, CountryRegion, PostalCode, ModifiedDate)
			values				 (@addressLine1, @addressLine2, @city, @stateProvince, @countryRegion, @postalCode, @ModifiedDate)
GO


CREATE PROCEDURE [dbo].[InsertCustomerAddress]

		@custID int,
		@addID int,
       @addressType NVARCHAR(40)
      ,@modifiedDate NVARCHAR(40)
	  as
	  insert into SalesLT.CustomerAddress (CustomerID,AddressID, AddressType,  ModifiedDate)
			values						 (@custID,@addID, @addressType, @modifiedDate)
GO

CREATE PROCEDURE [dbo].[InsertCustomers]

 @Title NVARCHAR(40),
 @firstName NVARCHAR(40),
 @lastName NVARCHAR(40),
 @middleName NVARCHAR(40),
 @suffix NVARCHAR(40),
 @companyName NVARCHAR(40),
 @salesPerson NVARCHAR(40),
 @emailAddress NVARCHAR(40),
 @phone NVARCHAR(40),
 @PasswordHash NVARCHAR(40),
 @PasswordSalt NVARCHAR(40),
 @modifydate NVARCHAR(40)
 as 

 INSERT INTO salesLT.Customer(Title, FirstName, LastName, MiddleName, Suffix, CompanyName, SalesPerson, EmailAddress, Phone, PasswordHash, PasswordSalt, ModifiedDate )
					values(@Title, @Firstname, @lastName, @middleName, @suffix, @companyName, @salesPerson, @emailAddress, @phone, @PasswordHash, @PasswordSalt, @modifydate)
GO

CREATE PROCEDURE [dbo].[updateAddress]
	   @addressID int
      ,@addressLine1 NVARCHAR(40)
      ,@addressLine2 NVARCHAR(40)
      ,@city NVARCHAR(40)
      ,@stateProvince NVARCHAR(40)
      ,@countryRegion NVARCHAR(40)
      ,@postalCode NVARCHAR(40)
      ,@ModifiedDate NVARCHAR(40)
	  as 
	  update SalesLT.Address
	  set
	  AddressLine1 = @addressLine1,
	  AddressLine2 = @addressLine2,
	  City = @city,
	  StateProvince = @stateProvince,
	  CountryRegion = @countryRegion,
	  PostalCode = @postalCode,
	  ModifiedDate=@ModifiedDate
	  where AddressID = @addressID
GO


CREATE PROCEDURE [dbo].[updateCustomerAddress]
	   @customerID int
      ,@addressID int
      ,@addressType NVARCHAR(40)
      ,@modifiedDate NVARCHAR(40)
	  as
	  update SalesLT.CustomerAddress
	  set
	  AddressType = @addressType,
	  ModifiedDate = @modifiedDate
	  where CustomerID = @customerID and AddressID = @addressID
GO


CREATE PROCEDURE [dbo].[UpdateCustomers]

 @custID int,
 @Title NVARCHAR(40),
 @firstName NVARCHAR(40),
 @lastName NVARCHAR(40),
 @middleName NVARCHAR(40),
 @suffix NVARCHAR(40),
 @companyName NVARCHAR(40),
 @salesPerson NVARCHAR(40),
 @emailAddress NVARCHAR(40),
 @phone NVARCHAR(40),
 @PasswordHash NVARCHAR(40),
 @PasswordSalt NVARCHAR(40),
 @modifydate nvarchar(40)

 as 
 UPDATE SalesLT.Customer SET

 Title = @Title,
 FirstName = @firstName,
 LastName = @lastName,
 MiddleName =@middleName,
 Suffix = @suffix,
 CompanyName = @companyName,
 SalesPerson = @salesPerson,
 EmailAddress= @emailAddress,
 Phone = @phone,
 PasswordHash = @PasswordHash,
 PasswordSalt = @PasswordSalt,
 ModifiedDate = @modifydate
 
 where  CustomerID =@custID
GO







