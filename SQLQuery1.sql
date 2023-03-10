use TestDB
create table Employee
(Empid int identity primary key,
FirstName varchar(50),
LastName varchar(50),
Age int,
Salary int,
);
insert into Employee values('ajay','mishra',23,250000);
insert into Employee values('rahual','jadhav',23,350000);
insert into Employee values('akash','biradar',53,450000);
select*from Employee;
S
   select top 1000[Empid],
   [FirstName],
   [LastName],
   [Age],
   [Salary] from[dbo].[Employee]
   select*from Employee

create  procedure spInsert
   @fname varchar(50),
   @lname varchar(50),
   @age int , 
   @salary int
   AS
   BEGIN
   insert into Employee values(@fname,@lname,@age,@salary);
   END


   create procedure spGetData
   AS
   BEGIN
   select*from Employee
   END

   create procedure spDelete
   @Empid int
   as
   begin
   delete from Employee where  Empid=@Empid
   end

   create procedure spUpdate
   @Empid int,
   @FirstName varchar(50),
   @LastName varchar(50),
   @Age int,
   @Salary int
   AS
   begin
   update Employee set FirstName= @FirstName, LastName= @LastName,Age= @Age ,Salary= @Salary where Empid=@Empid
   end
