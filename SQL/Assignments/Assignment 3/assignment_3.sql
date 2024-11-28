use assignment2

select*from EMP

select*from DEPT

--1.
select empno,ename from EMP
WHERE job='MANAGER'

--2.
select ename, sal from EMP
WHERE sal>1000

--3.
select ename,sal from EMP
WHERE ename!='JAMES'

--4.
select * from EMP
WHERE ename LIKE 'S%'

--5.
select * from EMP
WHERE ename LIKE '%A%'

--6.
select ename from EMP
WHERE ename LIKE '__L%'

--7.
select ename,sal, (sal/30) as Daily_Salary
from EMP
WHERE ename = 'JONES'

--8.
select sum(sal) as Total_Salary
from EMP

--9.
select avg(sal)*12 as Avg_Annual_Salary
from EMP

--10.
select ename,job,sal,deptno
from EMP
where deptno=30 and job!='SALESMAN'

--11.
select DISTINCT e.deptno, d.dname
from EMP e
JOIN DEPT d on e.deptno = d.deptno

--12.
select ename as Employee, sal as Monthly_Salary
from EMP
where sal>1500 and deptno IN(10,30)

--13.
select ename,job,sal from EMP
where (job='MANAGER' or job='ANALYST')
and sal NOT IN(1000,3000,5000)

--14.
select ename,sal,comm
from emp
where comm>sal*1.1

--15.
select ename from EMP
where (ename LIKE '%L%L' and deptno=30)
or mgr_id=7782

--16.
select ename, years_of_experience
from EMP
where years_of_experience>30 and years_of_experience<40

--17.
select d.dname, e.ename
from DEPT d
join EMP e on d.deptno = e.deptno
order by d.dname ASC, e.ename DESC

--18.
select ename, years_of_experience
from EMP
where ename='MILLER'


