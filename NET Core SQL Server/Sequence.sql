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
--Sequence شکل کلی دستور جهت ایجاد
CREATE SEQUENCE [schema_name . ] Sequence_Name
    [ AS [ built_in_integer_type | user-defined_integer_type ] ] --Sequence نوع داده مربوط به
    [ START WITH <constant> ] --مقدار شروع
    [ INCREMENT BY <constant> ] -- گام افزایش
    [ { MINVALUE [ <constant> ] } | { NO MINVALUE } ] -- حداقل مقدار
    [ { MAXVALUE [ <constant> ] } | { NO MAXVALUE } ] -- حداکثر مقدار
    [ CYCLE | { NO CYCLE } ] --دارای حالت دوار/حلقه باشد و یا خیر
    [ { CACHE [ <constant> ] } | { NO CACHE } ] -- چه مقدار آیتم در کش وجود داشته باشد مقدار پیش فرض 50
    [ ; ]
-------------------------------------
USE tempdb
GO
--Sequence بررسی جهت وجود 
IF OBJECT_ID('SequenceTest')>0
	DROP SEQUENCE SequenceTest
GO
--Sequence ایجاد 
CREATE SEQUENCE dbo.SequenceTest AS INT
	START WITH 1
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 30
	CYCLE 
	CACHE 
GO
--View In Object Explorer
GO
--Sequence واکشی مقدار از
SELECT NEXT VALUE FOR dbo.SequenceTest AS VALUE
GO
-------
SELECT NEXT VALUE FOR dbo.SequenceTest AS VALUE
GO 10
-------------------------------------
--هنگام کار با جداول Sequence نحوه استفاده از 
use Test01
--بررسی جهت وجود جدول
IF OBJECT_ID('TestTB1')>0
	DROP TABLE TestTB1
GO
IF OBJECT_ID('TestTB2')>0
	DROP TABLE TestTB2
GO
--ایجاد جداول
CREATE TABLE TestTB1
(
	ID INT,
	Name VARCHAR(50)  COLLATE PERSIAN_100_CI_AI
)
Go
CREATE TABLE TestTB2
(
	ID INT,
	Name VARCHAR(50) COLLATE PERSIAN_100_CI_AI
)
Go
--Sequence درج رکورد در جدول به همراه استفاده از 
INSERT TestTB1 VALUES (NEXT VALUE FOR dbo.SequenceTest,N'مسعود طاهری')
INSERT TestTB1 VALUES (NEXT VALUE FOR dbo.SequenceTest,N'فرید طاهری')
INSERT TestTB1 VALUES (NEXT VALUE FOR dbo.SequenceTest,N'مجید طاهری')
INSERT TestTB2 VALUES (NEXT VALUE FOR dbo.SequenceTest,N'علی طاهری')
INSERT TestTB2 VALUES (NEXT VALUE FOR dbo.SequenceTest,N'علیرضا طاهری')
GO
SELECT * FROM TestTB1
SELECT * FROM TestTB2
GO
-------------------------------------
--Sequence واکشی اطلاعاتی درباره 
SELECT * FROM SYS.sequences
GO
-------------------------------------
-- با در نظر گرفتن تمامی حالت ها Sequence ایجاد یک
IF OBJECT_ID('Seq1')>0
	DROP SEQUENCE Seq1	
GO
CREATE SEQUENCE Seq1
    AS DECIMAL(3,0) 
    START WITH 125
    INCREMENT BY 25
    MINVALUE 100
    MAXVALUE 200
    CYCLE
    CACHE 3
GO
--استخراج مقدار
--چند بار اجرا شود
SELECT NEXT VALUE FOR dbo.Seq1 AS VALUE
GO
--Sequences مشاهده اطلاعاتی درباره
SELECT 
	cache_size, current_value 
FROM sys.sequences
WHERE name = 'Seq1' ;
GO
--Sequence ویرایش 
ALTER SEQUENCE Seq1
    RESTART WITH 100  --به این قسمت توجه شود
    INCREMENT BY 10
    MINVALUE 100
    MAXVALUE 200
    NO CYCLE
    CACHE 3
GO
--استخراج مقدار
--چند بار اجرا شود
SELECT NEXT VALUE FOR dbo.Seq1 AS VALUE
GO
--Sequences مشاهده اطلاعاتی درباره
SELECT 
	cache_size, current_value 
FROM sys.sequences
WHERE name = 'Seq1' ;
GO
-------------------------------------
USE tempdb
GO
--Sequence بررسی جهت وجود 
IF OBJECT_ID('EventCounter')>0
	DROP SEQUENCE EventCounter
GO
--Sequence ایجاد یک 
CREATE SEQUENCE EventCounter
    AS int
    START WITH 1
    INCREMENT BY 1 ;
GO
--بررسی جهت وجود جدول
IF OBJECT_ID('ProcessEvents')>0
	DROP TABLE ProcessEvents
GO
--ایجاد یک جدول
CREATE TABLE ProcessEvents
(
    EventID INT PRIMARY KEY CLUSTERED 
        DEFAULT (NEXT VALUE FOR EventCounter), --به عنوان مقدار پیش فرض Sequence  استفاده از
    EventTime DATETIME NOT NULL DEFAULT (GETDATE()),
    EventCode NVARCHAR(5) NOT NULL,
    Comments NVARCHAR(300) NULL
) 
GO
--EventID برای تخصیص  Sequence درج رکورد تستی*استفاده از 
INSERT INTO ProcessEvents (EventCode,Comments) VALUES (1,'EVent1')
INSERT INTO ProcessEvents (EventCode,Comments) VALUES (1,'EVent1')
GO
--نمایش رکوردهای درج شده در جدول
SELECT * FROM ProcessEvents
GO
--EventID برای تخصیص  Sequence درج رکورد تستی*عدم استفاده از 
INSERT INTO ProcessEvents (EventID,EventCode,Comments) VALUES (4,10,'EVent10')
GO
SELECT * FROM ProcessEvents
GO
-------------------------------------
--استفاده از پروسیجر 
--Sequence استخراج تعداد آیتم های دلخواه از 
EXEC sys.sp_sequence_get_range 
GO
SP_HELPTEXT sp_sequence_get_range
/*
	@sequence_name      nvarchar(776), --Sequence نام 
	@range_size         bigint, --مقدار ورودی
	@range_first_value  sql_variant output, --مقدار خروجی
	@range_last_value   sql_variant = null output, --مقدار خروجی
	@range_cycle_count  int = null output, --مقدار خروجی
	@sequence_increment sql_variant = null output, --مقدار خروجی
	@sequence_min_value sql_variant = null output, --مقدار خروجی
	@sequence_max_value sql_variant = null output --مقدار خروجی
*/
GO
CREATE SEQUENCE RangeSeq
    AS int 
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 100
    CYCLE
    CACHE 10
GO
DECLARE @range_first_value_output sql_variant 
EXEC sp_sequence_get_range
	@sequence_name = N'RangeSeq'
	, @range_size = 4
	, @range_first_value = @range_first_value_output OUTPUT 
SELECT @range_first_value_output AS FirstNumber 
GO
DECLARE  
	 @FirstSeqNum sql_variant
	, @LastSeqNum sql_variant
	, @CycleCount int
	, @SeqIncr sql_variant
	, @SeqMinVal sql_variant
	, @SeqMaxVal sql_variant 

EXEC sys.sp_sequence_get_range
	  @sequence_name = N'RangeSeq'
	, @range_size = 5
	, @range_first_value = @FirstSeqNum OUTPUT 
	, @range_last_value = @LastSeqNum OUTPUT 
	, @range_cycle_count = @CycleCount OUTPUT
	, @sequence_increment = @SeqIncr OUTPUT
	, @sequence_min_value = @SeqMinVal OUTPUT
	, @sequence_max_value = @SeqMaxVal OUTPUT 

-- The following statement returns the output values
SELECT
  @FirstSeqNum AS FirstVal
, @LastSeqNum AS LastVal
, @CycleCount AS CycleCount
, @SeqIncr AS SeqIncrement
, @SeqMinVal AS MinSeq
, @SeqMaxVal AS MaxSeq 
-------------------------------------
--بررسی سناریو کاربردی و مفید
--شماره مرجع تراکنش بر روی رسیدهای بانکی
GO

/*
SqlCommand cmd = new SqlCommand();
cmd.Connection = conn;
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "sys.sp_sequence_get_range";
cmd.Parameters.AddWithValue("@sequence_name", "RangeSeq");
cmd.Parameters.AddWithValue("@range_size", 10);

// Specify an output parameter to retreive the first value of the generated range.
SqlParameter firstValueInRange = new SqlParameter("@range_first_value", SqlDbType.Variant);
firstValueInRange.Direction = ParameterDirection.Output;
cmd.Parameters.Add(firstValueInRange);

conn.Open();
cmd.ExecuteNonQuery();

// Output the first value of the generated range.
Console.WriteLine(firstValueInRange.Value);
*/
-------------------------------------
--