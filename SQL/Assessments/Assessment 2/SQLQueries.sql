CREATE DATABASE assessment2

use assessment2

CREATE TABLE Coursedetails(
C_id VARCHAR(6),
C_Name VARCHAR(30),
Start_date DATE,
End_date DATE,
Fee INT
)

INSERT INTO Coursedetails VALUES
('DN003', 'DotNet', '2018-02-01', '2018-02-28', 15000),
('DV004', 'DataVisualization', '2018-03-01', '2018-04-15',15000),
('JA002', 'AdvancedJava', '2018-01-02', '2018-01-20', 10000),
('JC001', 'CoreJava', '2018-01-02', '2018-01-12', 3000)

SELECT * FROM Coursedetails

--1. Function to calculate course duration

CREATE FUNCTION CalcCourseDuration(@StartDate DATE, @EndDate DATE)
RETURNS INT
AS
BEGIN
RETURN DATEDIFF(DAY, @StartDate, @EndDate)
END

SELECT C_id,C_Name,Start_date,End_date, dbo.CalcCourseDuration(Start_date,End_date) AS CourseDuration
FROM Coursedetails


CREATE TABLE T_CourseInfo(
C_Name VARCHAR(30),
Start_date DATE)

--2.Trigger
CREATE TRIGGER CourseInsertionTrg ON Coursedetails
AFTER INSERT AS
BEGIN
INSERT INTO T_CourseInfo(C_Name, Start_date)
SELECT C_Name, Start_date FROM inserted 
END

INSERT INTO Coursedetails VALUES
('IB001','InternationalBusiness','2019-01-02','2019-01-22',12000)

SELECT * FROM T_CourseInfo


--3. Stored Procedure ProductsDetails Table
CREATE TABLE ProductsDetails(
ProductID INT IDENTITY(1,1),
ProductName VARCHAR(20),
Price INT,
DiscountedPrice as (Price*0.90)
)

CREATE PROCEDURE ProdDetailsInsertion @ProductName VARCHAR(25), 
@Price INT, @ProductID INT OUTPUT as
BEGIN
INSERT INTO ProductsDetails(ProductName, Price) VALUES(@ProductName,@Price)
SET @ProductID = SCOPE_IDENTITY()
END

DECLARE @NewProductID INT
EXEC ProdDetailsInsertion 
@ProductName = 'Pringles',
@Price = 110,
@ProductID = @NewProductID OUTPUT

SELECT @NewProductID as ProductID
SELECT * FROM ProductsDetails