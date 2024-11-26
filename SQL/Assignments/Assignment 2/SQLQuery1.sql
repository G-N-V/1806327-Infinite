create database assignment2

use assignment2

CREATE TABLE EMP
(empno INT, ename VARCHAR(10), job VARCHAR(10), 
mgr_id INT, hiredate DATE, sal INT, comm INT, deptno INT)

CREATE TABLE DEPT
(deptno INT PRIMARY KEY, dname varchar(10), loc varchar(10))

ALTER TABLE EMP 
ADD FOREIGN KEY(deptno) REFERENCES DEPT(deptno)

INSERT INTO DEPT VALUES
(10, 'Accounting', 'New York'),
(20, 'Research', 'Dallas'),
(30, 'Sales', 'Chicago'),
(40, 'Operations', 'Boston')

SELECT * FROM DEPT

INSERT INTO EMP(empno, ename, job, mgr_id, hiredate, sal, deptno) VALUES
(7369,'SMITH','CLERK',7902,'1980-12-17',800,20)


INSERT INTO EMP VALUES
(7499,'ALLEN','SALESMAN',7698,'1981-02-20',1600,300,30)


INSERT INTO EMP VALUES
(7521,'WARD','CLERK',7698,'1981-02-22',1250,500,30),
(7566,'JONES','MANAGER',7839,'1981-04-02',2975,NULL,20),
(7654,'MARTIN','SALESMAN',7698,'1981-09-28',1250,1400,30),
(7698,'BLAKE','MANAGER',7839,'1981-05-01',2850,NULL,30),
(7782,'CLARK','MANAGER',7839,'1981-06-09',2450,NULL,10),
(7788,'SCOTT','ANALYST',7566,'1987-04-19',3000,NULL,20),
(7839,'KING','PRESIDENT',NULL,'1981-11-17',5000,NULL,10),
(7844,'TURNER','SALESMAN',7698,'1981-09-08',1500,0,30),
(7876,'ADAMS','CLERK',7788,'1987-05-23',1100,NULL,20),
(7900,'JAMES','CLERK',7698,'1981-12-03',950,NULL,30),
(7902,'FORD','ANALYST',7566,'1981-12-03',3000,NULL,30),
(7934,'MILLER','CLERK',7782,'1982-01-23',1300,NULL,10)

SELECT * FROM EMP

--1.
SELECT * FROM EMP WHERE ename LIKE 'A%'

--2.
SELECT * FROM EMP WHERE mgr_id IS NULL

--3.
SELECT ename, empno, sal FROM EMP
WHERE sal BETWEEN 1200 AND 1400

--4.
SELECT*FROM EMP
WHERE deptno = (SELECT deptno FROM DEPT WHERE dname = 'Research')

UPDATE EMP
SET sal = sal*1.10
WHERE deptno = (SELECT deptno FROM DEPT WHERE dname = 'Research')

SELECT * FROM EMP
WHERE deptno = (SELECT deptno from DEPT where dname = 'Research')

--5.
SELECT count(*) AS "Number of Clerks" FROM EMP
WHERE job='CLERK'

--6.
SELECT job, AVG(sal) AS "Average Salary", COUNT(*) AS "No of Employees"
FROM EMP
GROUP BY job

--7.
SELECT * FROM EMP
WHERE sal = (SELECT MIN(sal) FROM EMP) 
UNION
SELECT * FROM EMP
WHERE sal = (SELECT MAX(sal) FROM EMP)

--8.
SELECT * FROM DEPT
WHERE deptno NOT IN (SELECT deptno FROM EMP)

--9.
SELECT ename, sal FROM EMP
WHERE job = 'ANALYST' and sal>1200
and deptno = 20 
ORDER BY ename ASC

--10.
SELECT d.deptno, d.dname, sum(e.sal) as Total_salary
FROM DEPT d
JOIN EMP e on d.deptno = e.deptno
GROUP BY d.deptno,d.dname

--11.
SELECT ename,sal
FROM EMP 
WHERE ename in ('MILLER','SMITH')

--12.
SELECT ename from EMP
WHERE ename LIKE 'A%' or ename LIKE 'M%'

--13.
SELECT ename,sal, (sal*12) AS YEARLY_SALARY
FROM EMP WHERE ename='SMITH'

--14.
SELECT ENAME,SAL FROM EMP
WHERE SAL NOT BETWEEN 1500 AND 2850

--15.
SELECT mgr_id, COUNT(*) AS No_of_Employees
FROM EMP
GROUP BY mgr_id
HAVING COUNT(*)>2
