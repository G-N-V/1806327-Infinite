CREATE DATABASE TrainReservationSystem

USE TrainReservationSystem


CREATE TABLE Trains(
TrainID INT PRIMARY KEY IDENTITY(1,1),
TrainNumber INT NOT NULL,
TrainName VARCHAR(35) NOT NULL,
Source VARCHAR(30) NOT NULL,
Destination VARCHAR(30) NOT NULL
)

CREATE TABLE Classes(
ClassID INT PRIMARY KEY IDENTITY(1,1),
ClassName VARCHAR(20) NOT NULL
)

CREATE TABLE Berths(
BerthID INT PRIMARY KEY IDENTITY(1,1),
TrainID INT FOREIGN KEY REFERENCES Trains(TrainID),
ClassID INT FOREIGN KEY REFERENCES Classes(ClassID),
TotalBerths INT NOT NULL,
AvailableBerths INT NOT NULL
)

CREATE TABLE Bookings(
BookingID INT PRIMARY KEY IDENTITY(1,1),
TrainID INT FOREIGN KEY REFERENCES Trains(TrainID),
ClassID INT FOREIGN KEY REFERENCES Classes(ClassID),
UserID INT NOT NULL,
BookingDate DATETIME NOT NULL DEFAULT GETDATE()
)

ALTER TABLE Trains
ADD Status VARCHAR(15) DEFAULT 'Active'

ALTER TABLE Bookings
ADD IsCancelled BIT DEFAULT 0



--Procedure to add a train
CREATE or ALTER PROCEDURE AddTrain
@TrainNumber INT,
@TrainName VARCHAR(36),
@Source VARCHAR(36),
@Destination VARCHAR(36)
AS
BEGIN
DECLARE @TrainID INT
INSERT INTO Trains(TrainNumber, TrainName, Source, Destination) VALUES
(@TrainNumber, @TrainName, @Source, @Destination)

SET @TrainID = @@IDENTITY
INSERT INTO Berths(TrainID, ClassID, TotalBerths, AvailableBerths)
SELECT @TrainID, ClassID, TotalBerths, AvailableBerths FROM #ClassesBerths
END

--Procedure to update train
CREATE PROCEDURE UpdateTrain
@TrainID INT,
@TrainNumber INT,
@TrainName VARCHAR(36),
@Source VARCHAR(36),
@Destination VARCHAR(36)
AS
BEGIN 
UPDATE Trains
SET TrainNumber = @TrainNumber, TrainName = @TrainName, Source=@Source, Destination = @Destination
WHERE TrainID = @TrainID
END

ALTER TABLE Bookings
ADD PNR VARCHAR(10)

--Procedure to Book Ticket
CREATE OR ALTER PROCEDURE BookTicket
@TrainID INT,
@ClassID INT,
@UserID INT,
@NumberOfTickets INT
AS 
BEGIN
DECLARE @AvailableBerths INT
DECLARE @PNR VARCHAR(10)

SELECT @AvailableBerths = AvailableBerths FROM Berths
WHERE TrainID = @TrainID and ClassID = @ClassID
IF @AvailableBerths>=@NumberOfTickets
BEGIN
IF EXISTS(SELECT 1 FROM Trains WHERE TrainID = @TrainID and Status='Active')
BEGIN
BEGIN TRANSACTION

SET @PNR = LEFT(CONVERT(VARCHAR(36), NEWID()),10)
DECLARE @Counter INT=0
WHILE @Counter<@NumberOfTickets
BEGIN
INSERT INTO Bookings(TrainID, ClassID, UserID, PNR) VALUES
(@TrainID, @ClassID, @UserID, @PNR)
SET @Counter = @Counter+1
END

UPDATE Berths
SET AvailableBerths = AvailableBerths - @NumberOfTickets
WHERE TrainID = @TrainID and ClassID = @ClassID
COMMIT
END
ELSE
BEGIN
RAISERROR('Cannot Book Ticket for Inactive Train',16,1)
END
END
ELSE
BEGIN
RAISERROR('Berths are full for the specified class',16,1)
END
END



--Procedure to view trains
CREATE OR ALTER PROCEDURE ViewTrains
AS
BEGIN
SELECT*FROM Trains
WHERE Status='Active'
END
 

--procedure to SoftDelete
CREATE PROCEDURE SoftDeleteTrain @TrainID INT
AS BEGIN
UPDATE Trains
SET Status='Inactive'
WHERE TrainID = @TrainID
END


--Procedure to Check Availability
CREATE OR ALTER PROCEDURE CheckAvailability
@TrainID INT,
@ClassID INT
AS
BEGIN
SELECT AvailableBerths
FROM Berths
WHERE TrainID = @TrainID and ClassID=@ClassID
END

--procedure to view bookings
CREATE OR ALTER PROCEDURE ViewBookings
@UserID INT
AS
BEGIN
SELECT TrainID, ClassID,UserID, PNR, BookingDate FROM Bookings
WHERE IsCancelled=0 and UserID = @UserID
END

--Procedure to Cancel Booking
CREATE OR ALTER PROCEDURE CancelBooking
@PNR VARCHAR(10),
@NumberOfTickets INT
AS
BEGIN
DECLARE @TrainID INT
DECLARE @ClassID INT
DECLARE @TotalTickets INT

SELECT @TrainID = TrainID, @ClassID = ClassID, @TotalTickets = COUNT(*)
FROM Bookings
WHERE PNR = @PNR and IsCancelled=0
GROUP BY TrainID, ClassID

IF @TotalTickets>=@NumberOfTickets
BEGIN
BEGIN TRANSACTION
UPDATE TOP(@NumberOfTickets) Bookings
SET IsCancelled = 1
WHERE PNR = @PNR and IsCancelled=0

UPDATE Berths
SET AvailableBerths = AvailableBerths+@NumberOfTickets
WHERE TrainID = @TrainID and ClassID = @ClassID
COMMIT
END
ELSE
BEGIN
RAISERROR('Not enough tickets available to cancel',16,1)
END
END



--Procedure to view cancelled bookings
CREATE or ALTER PROCEDURE ViewCancelledBookings
@UserID INT
AS
BEGIN
SELECT * FROM Bookings
WHERE IsCancelled=1 and UserID=@UserID
END

--procedure to display ticket details
CREATE OR ALTER PROCEDURE GetTicketDetails
@PNR VARCHAR(30),
@UserID INT
AS
BEGIN
SELECT b.PNR,b.BookingDate,b.IsCancelled,u.UserName as BookedBy,t.TrainName,t.Source,t.Destination,
(SELECT COUNT(*) FROM Bookings WHERE PNR=@PNR and UserID=@UserID)AS NumberOfTickets, CASE B.ClassID
WHEN 1 THEN 'First A/C'
WHEN 2 THEN 'Second A/C'
WHEN 3 THEN 'Third A/C'
WHEN 4 THEN 'Sleeper'
ELSE 'Unknown Class'
END as ClassType
FROM Bookings b INNER JOIN Users u on b.UserID = u.UserID
INNER JOIN Trains t on b.TrainID = t.TrainID
WHERE b.PNR=@PNR and b.UserID = @UserID
END

--procedure for admin to view all bookings
CREATE OR ALTER PROCEDURE AdminViewAllBookings
AS
BEGIN
SELECT b.PNR, b.BookingDate, b.IsCancelled, u.UserName, t.TrainName, t.Source, t.Destination,
COUNT(b.PNR) as NumberOfTickets,
CASE b.ClassID
WHEN 1 THEN 'First A/C'
WHEN 2 THEN 'Second A/C'
WHEN 3 THEN 'Third A/C'
WHEN 4 THEN 'Sleeper'
ELSE 'Unknown Class'
END as ClassType
FROM Bookings b INNER JOIN Users u on b.UserID = u.UserID
INNER JOIN Trains t on b.TrainID = t.TrainID
GROUP BY
b.PNR, b.BookingDate, b.IsCancelled, u.UserName, t.TrainName, t.Source, t.Destination,b.ClassID
ORDER BY
b.BookingDate DESC
END

--procedure to view all cancelled bookings
CREATE OR ALTER PROCEDURE AdminViewAllCancelledBookings
AS
BEGIN
SELECT b.PNR, b.BookingDate, b.IsCancelled, u.UserName, t.TrainName, t.Source, t.Destination,
COUNT(b.PNR) as NumberOfTickets,
CASE b.ClassID
WHEN 1 THEN 'First A/C'
WHEN 2 THEN 'Second A/C'
WHEN 3 THEN 'Third A/C'
WHEN 4 THEN 'Sleeper'
ELSE 'Unknown Class'
END as ClassType
FROM Bookings b INNER JOIN Users u on b.UserID = u.UserID
INNER JOIN Trains t on b.TrainID = t.TrainID
WHERE b.IsCancelled=1
GROUP BY 
b.PNR, b.BookingDate, b.IsCancelled, u.UserName, t.TrainName, t.Source, t.Destination,b.ClassID
ORDER BY
b.BookingDate DESC
END

--procedure for admin to view all ticket details
CREATE OR ALTER PROCEDURE AdminViewAllTicketDetails
AS
BEGIN
SELECT b.PNR,b.BookingDate,b.IsCancelled,u.UserName as BookedBy, t.TrainName, t.Source,t.Destination,
COUNT(b.PNR) as NumberOfTickets, CASE b.ClassID
WHEN 1 THEN 'First A/C'
WHEN 2 THEN 'Second A/C'
WHEN 3 THEN 'Third A/C'
WHEN 4 THEN 'Sleeper'
ELSE 'Unknown Class'
END as ClassType
FROM
Bookings b INNER JOIN Users u on b.UserID = u.UserID
INNER JOIN Trains t on b.TrainID = t.TrainID
GROUP BY
b.PNR, b.BookingDate, b.IsCancelled, u.UserName, t.TrainName, t.Source, t.Destination, b.ClassID
ORDER BY
b.BookingDate DESC
END

--procedure for admin to view all users
CREATE OR ALTER PROCEDURE AdminViewAllUsers
AS
BEGIN
SELECT UserID, Name, UserName, Password FROM Users
ORDER BY UserID
END

INSERT INTO Classes(ClassName) VALUES
('First A/C'),('Second A/C'),('Third A/C'), ('Sleeper')

INSERT INTO Trains (TrainNumber, TrainName, Source, Destination) VALUES
(12345, 'Chennai Express', 'Chennai', 'Mumbai'),
(12346, 'Himsagar Express', 'Katra', 'Kanyakumari'),
(12347, 'Howrah Mail', 'Kolkata', 'New Delhi')

select * from Classes

INSERT INTO Berths(TrainID, ClassID, TotalBerths, AvailableBerths) VALUES
(1,1,30,30),
(1,2,70,70),
(1,3,150,150),
(1,4,250,250),
(2,1,35,35),
(2,2,75,75),
(2,3,160,160),
(2,4,270,270),
(3,1,25,25),
(3,2,100,100),
(3,3,180,180),
(3,4,300,300)

INSERT INTO Berths(TrainID, ClassID, TotalBerths, AvailableBerths) VALUES
(4,1,40,40),
(4,2,100,100),
(4,3,150,150),
(4,4,200,200)

--user table
CREATE TABLE Users(
UserID INT,
Name VARCHAR(30),
UserName VARCHAR(30),
Password VARCHAR(20)
)


--procedure for register user
CREATE OR ALTER PROCEDURE RegisterUser
@Name VARCHAR(30),
@UserName VARCHAR(30),
@Password VARCHAR(30)
AS
BEGIN
DECLARE @NewUserID INT
DECLARE @RandomID INT

WHILE 1=1
BEGIN
SET @RandomID = ABS(CHECKSUM(NEWID()))%90000+10000

IF NOT EXISTS(SELECT 1 FROM Users WHERE UserID = @RandomID)
BEGIN
SET @NewUserID = @RandomID
BREAK
END
END

INSERT INTO Users(UserID, Name, UserName, Password) VALUES
(@NewUserID, @Name, @UserName, @Password)

SELECT @NewUserID as NewUserID
END

--procedure for user login
CREATE OR ALTER PROCEDURE UserLogin
@UserName VARCHAR(30),
@Password VARCHAR(20)
AS
BEGIN
IF EXISTS(SELECT 1 FROM Users WHERE UserName = @UserName and Password = @Password)
BEGIN
SELECT UserID FROM Users
WHERE UserName = @UserName and Password = @Password
END
ELSE
BEGIN
RAISERROR('Invalid username or password',16,1)
END
END



--others(ignore)
SELECT name FROM sys.key_constraints
WHERE type='PK' and parent_object_id=OBJECT_ID('Berths')

ALTER TABLE Berths
DROP Constraint PK__Berths__1E1261F926EAF765

ALTER TABLE Berths
DROP COLUMN BerthID

ALTER TABLE Berths
ADD TrainName VARCHAR(35)

UPDATE Berths
SET TrainName = t.TrainName
FROM Berths b
JOIN Trains t ON b.TrainID = t.TrainID

SELECT * FROM Berths
where TrainID = 1 and ClassID=1

select*from Bookings
select*from Berths


