create database assessments

create table books(id INT PRIMARY KEY,
				   title varchar(30),
				   author varchar(20), 
				   isbn BIGINT UNIQUE,
				   published_date DATETIME)

INSERT INTO books values
(1, 'My first SQL Book', 'Mary Parker',981483029127,'2012-02-22 12:08:17'),
(2, 'My second SQL Book', 'John Mayer', 857300923713,'1972-07-03 09:22:45'),
(3, 'My third SQL Book', 'Cary Flint',523120967812,'2015-10-18 14:05:44')

select*from books

--query
--Write a query to fetch the details of the books written by author whose name ends with er.
select * from books 
where author LIKE '%er'


create table reviews(id INT,
					 book_id INT,
					 reviewer_name VARCHAR(20),
					 content VARCHAR(25),
					 rating INT,
					 published_date DATETIME)

ALTER TABLE reviews
ADD FOREIGN KEY (id) REFERENCES books(id)

INSERT INTO reviews VALUES
(1,1,'''John Smith''','''My first review''',4,'2017-12-10 05:50:11'),
(2,2,'''John Smith''', '''My Second review''',5,'2017-10-13 15:05:12'),
(3,2,'''Alice Walker''', '''Another review''',1,'2017-10-22 23:47:10')


select*from reviews

--query
--Display the reviewer name who reviewed more than one book.
SELECT reviewer_name
FROM reviews
GROUP BY reviewer_name
HAVING COUNT(DISTINCT book_id) > 1

--query
--Display the Title ,Author and ReviewerName for all the books from the above table
SELECT b.title, b.author, r.reviewer_name
FROM books b
INNER JOIN 
reviews r ON b.id=r.book_id


--customers table
CREATE TABLE customers(ID INT PRIMARY KEY,
					   NAME VARCHAR(10),
					   AGE INT,
					   ADDRESS VARCHAR(15),
					   SALARY DECIMAL(10,2))


INSERT INTO customers VALUES
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', 4500.00),
(7, 'Muffy', 24, 'Indore', 10000.00)

SELECT * FROM customers

--QUERY
--Display the Name for the customer from above customer table who 
--live in same address which has character o anywhere in address
SELECT NAME,ADDRESS FROM customers
WHERE address LIKE '%o%'

CREATE TABLE ORDERS(OID INT,
					[DATE] DATETIME,
					CUSTOMER_ID INT,
					AMOUNT INT)

INSERT INTO ORDERS VALUES
(102, '2009-10-08 00:00:00',3,3000),
(100, '2009-10-08 00:00:00',3,1500),
(101, '2009-11-20 00:00:00',2,1560),
(103, '2008-05-20 00:00:00',4,2060)

SELECT*FROM ORDERS

--Write a query to display the Date,Total no of customer placed order on same Date
SELECT DATE, COUNT(CUSTOMER_ID) AS total_count
FROM ORDERS
GROUP BY DATE

CREATE TABLE Employees(ID INT PRIMARY KEY,
					   NAME VARCHAR(10),
					   AGE INT,
					   ADDRESS VARCHAR(15),
					   SALARY DECIMAL(10,2))

INSERT INTO Employees VALUES
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', NULL),
(7, 'Muffy', 24, 'Indore', NULL)

SELECT*FROM EMPLOYEES

--query
SELECT LOWER(NAME) AS lower_case_name
FROM Employees
WHERE SALARY IS NULL

CREATE TABLE StudentDetails(RegisterNo INT,
							Name VARCHAR(10),
							Age INT,
							Qualification VARCHAR(10),
							MobileNo BIGINT,
							Mail_id VARCHAR(20),
							Location VARCHAR(10),
							Gender VARCHAR(2))

INSERT INTO StudentDetails VALUES
(2,'Sai',22,'B.E',9952836777,'Sai@gmail.com','Chennai','M'),
(3,'Kumar',20,'BSC',7890125648,'Kumar@gmail.com','Madurai','M'),
(4,'Selvi',22,'B.Tech',8904567342,'selvi@gmail.com','Salem','F'),
(5,'Nisha',25,'M.E',7834672310,'Nisha@gmail.com','Theni','F'),
(6,'SaiSaran',21,'B.A',7890345678,'saran@gmail.com','Madurai','F'),
(7,'Tom',23,'BCA',8901234675,'Tom@gmail.com','Pune','M')

SELECT * FROM StudentDetails

--Write a sql server query to display the Gender,Total no of male and female from the above 
--relation
SELECT Gender, COUNT(*) AS TotalCount
FROM StudentDetails
GROUP BY Gender


