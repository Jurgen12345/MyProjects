/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ID]
      
  FROM [ERP].[dbo].[CUSTOMER]


Alter table CUSTOMER 
drop column CUSTOMER_CATEGORY_CID