create database ecomm;
use ecomm;
create table Users(Id int primary key Identity(1,1),FirstName varchar(30),LastName Varchar(30),
Email varchar(30),Password varchar(30));
drop table Users;

create table Users(UserId int primary key Identity(1,1),FirstName varchar(30),LastName Varchar(30),
Email varchar(30),Password varchar(30));

create table Role(
RoleId int primary key identity (1,1),
RoleName varchar(20));
insert into Role Values('Admin');
insert into Role Values('Customer');

create table OrderDetails(OrderId int Primary key identity(1,1),
UserId int,ProductId int,Quantity int);
 select * from OrderDetails;


create table Category
(CategoryId int primary key identity(1,1),
CategoryName varchar(50));
select * from Category;
insert into Category Values('Electronics');
insert into Category Values('Furniture');
create table Product
(
	ProductId int primary key identity(1,1),
	Name varchar(50),
	price int,
	CategoryId int,
);
insert into Product values('laptop',22222,1);
insert into Product values('Mouse',1500,1);
insert into Product values('Speaker',3300,1);
insert into Product values('Table',5000,2);
select*from Product;

create table Cart(
CartId int primary key identity(1,1),
ProductId int,
UserId int 
);
insert into Cart values(1,1);
select p.ProductId,p.Name,p.price,p.CategoryId, c.CartId,c.UserId from Product p  
                         inner join Cart c on c.CartId = p.ProductId  
                        where c.UserId =1;

select * from Product;
select * from Cart;
select * from  Users;
truncate table Cart;
select * from OrderDetails;
select p.ProductId,p.Name,p.price,p.CategoryId, c.CartId,c.UserId from Product p 
                        inner join Cart c on c.ProductId = p.ProductId 
                         where c.UserId = 2;

select * from Product where ProductId = 2;
