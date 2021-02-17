USE [AdventureWorksLT2019]
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'SalesLT', @level1type=N'TABLE',@level1name=N'CustomerAddress', @level2type=N'CONSTRAINT',@level2name=N'FK_CustomerAddress_Customer_CustomerID'
GO

ALTER TABLE [SalesLT].[CustomerAddress] DROP CONSTRAINT [FK_CustomerAddress_Customer_CustomerID]
GO

ALTER TABLE [SalesLT].[CustomerAddress]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAddress_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [SalesLT].[Customer] ([CustomerID])
GO

ALTER TABLE [SalesLT].[CustomerAddress] CHECK CONSTRAINT [FK_CustomerAddress_Customer_CustomerID]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key constraint referencing Customer.CustomerID.' , @level0type=N'SCHEMA',@level0name=N'SalesLT', @level1type=N'TABLE',@level1name=N'CustomerAddress', @level2type=N'CONSTRAINT',@level2name=N'FK_CustomerAddress_Customer_CustomerID'
GO


EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'SalesLT', @level1type=N'TABLE',@level1name=N'CustomerAddress', @level2type=N'CONSTRAINT',@level2name=N'FK_CustomerAddress_Address_AddressID'
GO

ALTER TABLE [SalesLT].[CustomerAddress] DROP CONSTRAINT [FK_CustomerAddress_Address_AddressID]
GO

ALTER TABLE [SalesLT].[CustomerAddress]  WITH NOCHECK ADD  CONSTRAINT [FK_CustomerAddress_Address_AddressID] FOREIGN KEY([AddressID])
REFERENCES [SalesLT].[Address] ([AddressID])
ON DELETE CASCADE
GO

ALTER TABLE [SalesLT].[CustomerAddress] CHECK CONSTRAINT [FK_CustomerAddress_Address_AddressID]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key constraint referencing Address.AddressID.' , @level0type=N'SCHEMA',@level0name=N'SalesLT', @level1type=N'TABLE',@level1name=N'CustomerAddress', @level2type=N'CONSTRAINT',@level2name=N'FK_CustomerAddress_Address_AddressID'
GO






DROP PROCEDURE [dbo].[GetCustomers]
DROP PROCEDURE [dbo].[DeleteCustomers]
DROP PROCEDURE [dbo].[getlastaddID]
DROP PROCEDURE [dbo].[getlastCustID]
DROP PROCEDURE [dbo].[InsertAddress]
DROP PROCEDURE [dbo].[InsertCustomerAddress]
DROP PROCEDURE [dbo].[InsertCustomers]
DROP PROCEDURE [dbo].[updateAddress]
DROP PROCEDURE [dbo].[updateCustomerAddress]
DROP PROCEDURE [dbo].[UpdateCustomers]
drop procedure [dbo].getProducts

DROP VIEW [dbo].[productView]
GO




