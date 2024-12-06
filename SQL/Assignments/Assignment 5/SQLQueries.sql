--1.
CREATE PROCEDURE GeneratePaySlip @EmployeeID INT
AS 
BEGIN

DECLARE @Name VARCHAR(30)
DECLARE @Salary FLOAT
DECLARE @HRA FLOAT
DECLARE @DA FLOAT
DECLARE @PF FLOAT
DECLARE @IT FLOAT
DECLARE @Deductions FLOAT
DECLARE @GrossSalary FLOAT
DECLARE @NetSalary FLOAT

SELECT @Name = NAME, @Salary = SALARY
FROM Employees
WHERE ID = @EmployeeID

SET @HRA = @Salary*0.10
SET @DA = @Salary*0.20
SET @PF = @Salary*0.08
SET @IT = @Salary*0.05
SET @Deductions = @PF+@IT
SET @GrossSalary = @Salary+@HRA+@DA
SET @NetSalary = @GrossSalary-@Deductions

PRINT 'Payslip for Employee ID: ' +CAST(@EmployeeID AS VARCHAR(10))
PRINT 'Name: '+@Name
PRINT 'Salary: '+CAST(@Salary AS VARCHAR(20))
PRINT 'HRA: ' +CAST(@HRA AS VARCHAR(20))
PRINT 'DA: ' +CAST(@DA AS VARCHAR(20))
PRINT 'PF: ' +CAST(@PF AS VARCHAR(20))
PRINT 'IT: ' +CAST(@IT AS VARCHAR(20))
PRINT 'Gross Salary: ' +CAST(@GrossSalary AS VARCHAR(20))
PRINT 'Deductions: '+CAST(@Deductions AS VARCHAR(20))
PRINT 'Net Salary: ' +CAST(@NetSalary AS VARCHAR(20))

END

EXEC GeneratePaySlip @EmployeeID = 1


--2.
CREATE TABLE Holidays(
holiday_date DATE PRIMARY KEY,
holiday_name VARCHAR(30)
)

INSERT INTO Holidays VALUES
('2025-01-01', 'New Year'),
('2025-01-26', 'Republic Day'),
('2025-05-01', 'May Day'),
('2025-08-15', 'Independence Day'),
('2025-12-25', 'Christmas')

CREATE TRIGGER RestrictManipOnHolidays ON EMP
BEFORE INSERT, UPDATE, DELETE
AS
BEGIN
DECLARE @Today DATE
DECLARE @HolidayName VARCHAR(30)

SET @Today = CAST(GETDATE() AS DATE)

SELECT @HolidayName = holiday_name
FROM Holidays
WHERE holiday_date = @Today

IF @HolidayName IS NOT NULL
BEGIN
RAISERROR('Due to %s, you cannot manipulate data today!',0,1,@HolidayName)
ROLLBACK TRANSACTION
END
END

INSERT INTO EMP VALUES
(7999,'NIKHIL',4500,10)

