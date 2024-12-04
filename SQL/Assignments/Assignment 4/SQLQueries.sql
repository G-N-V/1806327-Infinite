--Assignment 4

--1.
DECLARE @Number INT=5
DECLARE @Factorial BIGINT = 1
DECLARE @Counter INT = 1

WHILE @Counter<=@Number
BEGIN
SET @Factorial = @Factorial * @Counter
SET @Factorial = @Counter+1
END

SELECT @Factorial as FactorialResult


--2.
CREATE PROCEDURE MultiplicationTable
@Number INT, @Limit INT
AS
BEGIN
DECLARE @Counter INT=1

PRINT 'Multiplication Table for' +CAST(@Number as VARCHAR(10))+ 'up to' +CAST(@Limit AS VARCHAR(10))
WHILE @Counter<=@Limit
BEGIN
PRINT CAST(@Number AS VARCHAR(10)) + 'X' +CAST(@Counter AS VARCHAR(10))+ '=' +CAST(@Number *@Counter AS VARCHAR(10))
SET @Counter=@Counter+1
END
END

EXEC MultiplicationTable @Number=9, @Limit=10


--3.
CREATE TABLE Student(
Sid INT PRIMARY KEY,
Sname VARCHAR(20))

CREATE TABLE Marks(
Mid INT PRIMARY KEY,
Sid INT FOREIGN KEY REFERENCES Student(Sid),
Score INT)

INSERT INTO Student VALUES
(1,'Jack'),
(2,'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj')

INSERT INTO Marks VALUES
(1,1,23),
(2,6,95),
(3,4,98),
(4,2,17),
(5,3,53),
(6,5,13)

CREATE FUNCTION dbo.fn_GetStudentStatus(@Score INT)
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @Status VARCHAR(10)

IF @Score>=50
SET @Status='Pass'
ELSE
SET @Status ='Fail'

RETURN @Status
END


SELECT s.Sid,s.Sname,m.Score, dbo.fn_GetStudentStatus(m.Score) as Status
FROM Student s
JOIN 
Marks m ON s.Sid = m.Sid
ORDER BY
s.Sid

