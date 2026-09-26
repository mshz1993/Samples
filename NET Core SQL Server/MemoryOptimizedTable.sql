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
--Memory Optimized Table بررسی اولیه
USE master
GO
PRINT @@VERSION
GO
--بررسی جهت وجود بانک اطلاعاتی
IF DB_ID('SQL2019_Demo')>0
BEGIN
	ALTER DATABASE SQL2019_Demo SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE SQL2019_Demo
END
GO
--------------------------------------------------------------------
--ایجاد بانک اطلاعاتی
CREATE DATABASE SQL2019_Demo
 ON  PRIMARY
( 
    NAME = N'SQL2019_Demo', 
    FILENAME = N'C:\Dump\SQL2019_Demo.mdf', 
    SIZE = 5120KB, 
    FILEGROWTH = 1024KB 
 )
 LOG ON 
 ( 
    NAME = N'SQL2019_Demo_log', 
    FILENAME = N'C:\Dump\SQL2019_Demo_log.ldf', 
    SIZE = 64MB, 
    FILEGROWTH = 64MB
 )
GO
--MEMORY_OPTIMIZED_DATA اضافه شدن فایل گروه از نوع 
ALTER DATABASE SQL2019_Demo 
    ADD FILEGROUP MemFG CONTAINS MEMORY_OPTIMIZED_DATA 
GO
--اضافه کردن فایل به فایل گروه مورد نظر
ALTER DATABASE SQL2019_Demo ADD FILE
	( 
		NAME = MemFG_File1,
		FILENAME = N'C:\Dump\MemFG_File1'--مسیر مورد نظر بررسی شود
	) 
TO FILEGROUP MemFG
GO
--------------------------------------------------------------------
USE SQL2019_Demo
GO
--مشاهده فایل های مربوط به بانک اطلاعاتی
SELECT 
	name,type_desc,physical_name 
FROM SYS.database_files
GO
--Run Window Explorer
GO
--مشاهده فایل گروه های مربوط به بانک اطلاعاتی
SELECT * FROM SYS.filegroups
GO
-------------------------------------------------------------------- 
USE SQL2019_Demo
GO
--Memory Optimized Table  ایجاد یک جدول از نوع
DROP TABLE IF EXISTS MemOptTable
GO
--Memory Optimized Table  ایجاد یک جدول از نوع
--داده های مربوط به جدول در دیسک ثبت می گردد
--در صورت ذخیره محتوای جدول در دیسک باید حتما کلید اصلی موجود باشد
CREATE TABLE MemOptTable
(
    ID INT NOT NULL PRIMARY KEY NONCLUSTERED HASH WITH (BUCKET_COUNT = 10000),
    FullName NVARCHAR(200) NOT NULL, 
    DateAdded DATETIME NOT NULL
) WITH (MEMORY_OPTIMIZED = ON, DURABILITY = SCHEMA_AND_DATA)
GO
--Memory Optimized Table  مشاهده لیست جداول از نوع
SELECT 
	name,type_desc,durability_desc,Is_memory_Optimized 
FROM sys.tables
	WHERE Is_memory_Optimized = 1
GO
-- Native Compiled Stored Procedure از نوعSP ایجاد یک
CREATE OR ALTER PROCEDURE usp_LoadMemOptTable (@maxRows INT, @FullName NVARCHAR(200))
WITH
    NATIVE_COMPILATION, 
    SCHEMABINDING, 
    EXECUTE AS OWNER
AS
BEGIN ATOMIC
WITH (TRANSACTION ISOLATION LEVEL=SNAPSHOT, LANGUAGE='us_english')
    DECLARE @i INT = 1
    WHILE @i <= @maxRows
    BEGIN
        INSERT INTO dbo.MemOptTable VALUES(@i, @FullName, GETDATE())
        SET @i = @i+1
    END
END
GO
--------------------------------------------------------------------
--ایجاد شده به ازای جدول و پروسیجر DLL مشاهده 
SELECT
	OBJECT_ID('MemOptTable') AS MemOptTable_ObjectID,
	OBJECT_ID('usp_LoadMemOptTable') AS Native_Compiled_SP_ObjectID
GO
SELECT 
	name,description 
FROM sys.dm_os_loaded_modules
WHERE name LIKE '%XTP%'
GO
--------------------------------------------------------------------
USE SQL2019_Demo
GO
--Disk table (non-Memory Optimized) ایجاد جدول از نوع 
DROP TABLE IF EXISTS DiskTable
GO
CREATE TABLE DiskTable
(
    ID INT NOT NULL PRIMARY KEY,
    FullName NVARCHAR(200) NOT NULL, 
    DateAdded DATETIME NOT NULL
)
GO
-- برای پر کردن جدول SP ایجاد یک 
CREATE OR ALTER PROCEDURE usp_LoadDiskTable (@maxRows INT, @FullName NVARCHAR(200))
AS
BEGIN
    SET NOCOUNT ON
    DECLARE @i INT = 1
    WHILE @i <= @maxRows
    BEGIN
        INSERT INTO DiskTable VALUES(@i, @FullName, GETDATE())
        SET @i = @i+1
    END
END
GO
--------------------------------------------------------------------
--Disk Table (with simple SP) درج دیتا در جدول از نوع 
GO
DECLARE @StartTime DATETIME = GETDATE()
DECLARE @MaxRows INT = 10000
DECLARE @FullName VARCHAR(200)= REPLICATE('A',200)
DECLARE @TotalTime INT
EXEC usp_LoadDiskTable @maxRows, @FullName
SET @TotalTime = DATEDIFF(ms,@StartTime,GETDATE())
SELECT 'Disk Table Load: ' + CAST(@TotalTime AS VARCHAR) + ' ms (with simple SP)'
GO
--بررسی تعداد رکوردهای درج شده
SP_SPACEUSED 'DiskTable'
/*
Disk Table Load (with SP) :9704 ms
*/
--------------------------------------------------------------------
--Memory Optimized Table (with Native Compiled SP) درج دیتا در جدول از نوع 
DECLARE @StartTime DATETIME = GETDATE()
DECLARE @MaxRows INT = 10000
DECLARE @FullName VARCHAR(200)= REPLICATE('A',200)
DECLARE @TotalTime INT
EXEC usp_LoadMemOptTable @maxRows, @FullName
SET @TotalTime = DATEDIFF(ms,@StartTime,GETDATE())
SELECT 'Memory Optimized Table Load: ' + CAST(@TotalTime AS VARCHAR) + ' ms (with Native Compiled SP)'
GO
--بررسی تعداد رکوردهای درج شده
SP_SPACEUSED MemOptTable
GO 
/*
Memory Optimized Table  Load (without SP) :450 ms
*/
--------------------------------------------------------------------
--------------------------------------------------------------------
--Memory Optimized Table در Lock بررسی 
GO
------------------------
--Disk Based  انجام عملیات در یک جدول از نوع
GO
--بررسی جهت وجود جدول
IF OBJECT_ID('DiskTable')>0
	DROP TABLE DiskTable
GO
--Disk Based  ایجاد یک جدول از نوع
CREATE TABLE DiskTable
(
    ID INT NOT NULL PRIMARY KEY ,
    FullName NVARCHAR(200) NOT NULL, 
    DateAdded DATETIME NOT NULL
) 
GO
BEGIN TRANSACTION
--درج رکورد در جدول
INSERT INTO DiskTable(ID,FullName,DateAdded)
	VALUES (1,N'علیرضا طاهری',GETDATE())
--مشاهده لاک های مربوط به جدول
SELECT 
	dtl.request_session_id,
	dtl.resource_database_id,
	dtl.resource_associated_entity_id,
	dtl.resource_type,
	dtl.resource_description,
	dtl.request_mode,
	dtl.request_status
FROM  sys.dm_tran_locks AS dtl
	WHERE  dtl.request_session_id = @@SPID ;
ROLLBACK
GO
------------------------
--Memory Optimized Table  انجام عملیات در یک جدول از نوع
GO
--بررسی جهت وجود جدول
IF OBJECT_ID('MemOptTable')>0
	DROP TABLE MemOptTable
GO
--Memory Optimized Table  ایجاد یک جدول از نوع
CREATE TABLE MemOptTable
(
    ID INT NOT NULL PRIMARY KEY NONCLUSTERED HASH WITH (BUCKET_COUNT = 10000),
    FullName NVARCHAR(200) NOT NULL, 
    DateAdded DATETIME NOT NULL
) WITH (MEMORY_OPTIMIZED = ON, DURABILITY = SCHEMA_AND_DATA)
GO
BEGIN TRANSACTION
--درج رکورد در جدول
INSERT INTO MemOptTable(ID,FullName,DateAdded)
	VALUES (1,N'علیرضا طاهری',GETDATE())
--مشاهده لاک های مربوط به جدول
SELECT 
	dtl.request_session_id,
	dtl.resource_database_id,
	dtl.resource_associated_entity_id,
	dtl.resource_type,
	dtl.resource_description,
	dtl.request_mode,
	dtl.request_status
FROM  sys.dm_tran_locks AS dtl
	WHERE  dtl.request_session_id = @@SPID ;
ROLLBACK
GO
