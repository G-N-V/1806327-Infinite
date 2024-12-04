use assignment2

--1. 
DECLARE @Birthday DATE = '2003-04-18'
SELECT DATENAME(WEEKDAY, @Birthday) as DayOfWeek

--2.
DECLARE @Birthdate DATE = '2003-04-18'
SELECT DATEDIFF(DAY, @Birthdate, GETDATE()) as AgeInDays


SELECT * FROM EMP

--3.
SELECT * FROM EMP
WHERE DATEDIFF(YEAR, hiredate, GETDATE())>=5
AND MONTH(hiredate) = MONTH(GETDATE())

--4.
CREATE TABLE Employee(
empno INT PRIMARY KEY,
ename varchar(30),
sal DECIMAL(10,2),
doj DATE)

BEGIN TRANSACTION

INSERT INTO Employee VALUES
(1, 'Phil Dunphy',500000,'2017-12-23'),
(2, 'Claire Pritchett',400000,'2018-01-13'),
(3, 'Cameron Tucker',300000,'2019-06-09')

SAVE TRANSACTION s1

SELECT * FROM Employee


--4b
UPDATE Employee
SET sal = sal*1.15
WHERE empno = 2

SELECT * FROM Employee

SAVE TRANSACTION s2

--4c
DELETE FROM Employee
WHERE empno=1

SELECT * FROM Employee

ROLLBACK TRANSACTION s2

COMMIT

SELECT * FROM Employee


--5.
SELECT * FROM EMP
SELECT * FROM DEPT

CREATE FUNCTION CalcBonus(@deptno INT, @sal DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
DECLARE @bonus DECIMAL(10,2)

IF @deptno=10
BEGIN
SET @bonus = @sal*0.15
END
ELSE IF @deptno=20
BEGIN
SET @bonus = @sal*0.20
END
ELSE
BEGIN
SET @bonus = @sal*0.05
END
RETURN @bonus
END


SELECT empno, ename, sal, deptno, dbo.CalcBonus(deptno, sal) as BONUS
FROM EMP


--6.
CREATE PROCEDURE UpdateSalesSalary
AS
BEGIN
UPDATE EMP
SET sal = sal+500
WHERE deptno = (SELECT deptno FROM DEPT WHERE dname = 'Sales')
AND sal<1500
END

EXEC UpdateSalesSalary

SELECT * FROM EMP