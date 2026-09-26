--------------------------------------------------------------------
/*
 SQL Server آشنایی با قابلیت های مهم 
 برای برنامه نویسان دات نت

SitC:        http://www.NikAmooz.com
Email:       Info@NikAmooz.com
Instagram:   https://instagram.com/nikamooz/
Telegram:	 https://telegram.me/nikamooz
Created By:  Masoud Taheri 
*/
--------------------------------------------------------------------
--Rowversion آموزش کار با 
--ساخت بانک اطلاعاتی + جداول مورد نظر
USE master
GO
IF DB_ID('RowversionDemo')>0
BEGIN
	ALTER DATABASE RowversionDemo SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE RowversionDemo 
END
GO
CREATE DATABASE RowversionDemo
GO
USE RowversionDemo
GO
DROP TABLE IF EXISTS Employees
GO
CREATE TABLE Employees
(
	EmployeeID INT PRIMARY KEY,
	FullName NVARCHAR(100),
	EmployeeGroup VARCHAR(10),
	CurrentRowversion Rowversion -- RowVersion -- به این فیلد دقت کنید
)
GO
INSERT INTO Employees(EmployeeID,FullName,EmployeeGroup) VALUES 
	(1,N'Masoud Taheri','G1'),
	(2,N'Farid Taheri','G1'),
	(3,N'Majid Taheri','G2'),
	(4,N'Ali Taheri','G2'),
	(5,N'Alireza Taheri','G3')	
GO
--Rowversion مشاهده رکوردها  + وضعیت فیلد 
SELECT * FROM Employees
SELECT * ,CAST(CurrentRowversion AS INT) FROM Employees
GO
--مشاهده حجم فیلدها
SELECT * , DATALENGTH(CurrentRowversion) FROM Employees
SELECT SUM(DATALENGTH(CurrentRowversion))/1024.0 FROM Employees
GO
--به روز رسانی رکورد
SELECT * ,CAST(CurrentRowversion AS INT) FROM Employees WHERE EmployeeID=4
GO
UPDATE Employees SET EmployeeGroup+='*' WHERE EmployeeID=4
GO
SELECT * ,CAST(CurrentRowversion AS INT) FROM Employees WHERE EmployeeID=4
GO
SELECT max(CurrentRowversion) FROM Employees
GO
--------------------
--کنترل همزمانی
--بررسی جهت وجود جدول و حذف آن
IF OBJECT_ID('Students')>0
	DROP TABLE Students
GO
--ایجاد جدول
CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(100),
	LastName NVARCHAR(100),
	HomeAddress NVARCHAR(200),
	Phone VARCHAR(20),
	CurrentRowversion Rowversion -- به این فیلد دقت کنید
)
GO
--درج تعدادی رکورد تستی در بانک اطلاعاتی
INSERT INTO Students (FirstName,LastName,HomeAddress,Phone) VALUES 
	(N'مسعود',N'طاهری',N'تهران','123456'),
	(N'فرید',N'طاهری',N'تهران','3214'),
	(N'مجید',N'طاهری',N'میانه','654321'),
	(N'علی',N'طاهری',N'میانه','321'),
	(N'علیرضا',N'طاهری',N'تهران','55555')
GO
--واکشی رکوردهای درج شده
SELECT * ,CAST(CurrentRowversion AS INT) FROM Students
GO
--بررسی وجود پروسیجر
IF OBJECT_ID('usp_Students_Update')>0
	DROP PROCEDURE usp_Students_Update
GO
--ایجاد یک پروسیجر جهت به روز رسانی رکوردها
CREATE PROCEDURE usp_Students_Update
(
	@StudentID INT,
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@HomeAddress NVARCHAR(200),
	@Phone VARCHAR(20),
	@OldRowversion Rowversion 
)
AS
BEGIN
	--به روز رسانی رکورد
	UPDATE Students SET 
		FirstName=@FirstName,
		LastName=@LastName,
		HomeAddress=@HomeAddress,
		Phone=@Phone
	WHERE StudentID=@StudentID AND CurrentRowversion=@OldRowversion
	--آیا تغییرات مورد نظر انجام شده است
	IF @@ROWCOUNT=0
		THROW 59999,'Concurrency Problem!',1
END
GO
/*
--بررسی می شود Rowversion توجه شود که هنگام به روز رسانی رکورد وضعیت 
--چنانچه به واسطه دستور به روز رسانی رکوردی تغییر نکند به سمت کلاینت یک خطا ارسال می شود
*/
GO

