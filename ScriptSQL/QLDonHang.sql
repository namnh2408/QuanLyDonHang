create database QLDonHang
go

use QLDonHang
go

create table Users(
	ID int identity(1,1) primary key,
	UserName nvarchar(255) not null default '',
	Fullname nvarchar(512) not null default '',
	Email nvarchar(255) not null default '',
	Phone varchar(20) not null default '',
	Address nvarchar(1024) not null default '',
	RoleID int not null default 0,
	IsActive int not null default 0,
	IsDeleted int not null default 0,
	CreateUser int not null default 0,
	CreateDate datetime not null default getdate(),
	UpdateUser int not null default 0,
	UpdateDate datetime not null default getdate()
)
go

create table Roles(
	ID int identity(1,1) primary key,
	Title nvarchar(255) not null default ''
)
go

create table Products(
	ID int identity(1,1) primary key,
	Code nvarchar(512) not null default '',
	Name nvarchar(max) not null default '', 
	Note nvarchar(max) not null default '',
	IsActive int not null default 0,
	IsDeleted int not null default 0,
	CreateUser int not null default 0,
	CreateDate datetime not null default getdate(),
	UpdateUser int not null default 0,
	UpdateDate datetime not null default getdate()
) 

go

create table PaymentTypes(
	ID int identity(1,1) primary key,
	Name nvarchar(max) not null default '',
	IsDeleted int not null default 0,
	CreateUser int not null default 0,
	CreateDate datetime not null default getdate(),
	UpdateUser int not null default 0,
	UpdateDate datetime not null default getdate()
)
go


create table DeliveryTypes(
	ID int identity(1,1) primary key,
	Name nvarchar(max) not null default '',
	IsDeleted int not null default 0,
	CreateUser int not null default 0,
	CreateDate datetime not null default getdate(),
	UpdateUser int not null default 0,
	UpdateDate datetime not null default getdate()
)
go


create table MaterialTypes(
	ID int identity(1,1) primary key,
	Name nvarchar(max) not null default '',
	IsDeleted int not null default 0,
	CreateUser int not null default 0,
	CreateDate datetime not null default getdate(),
	UpdateUser int not null default 0,
	UpdateDate datetime not null default getdate()
)
go


create table ConstructionTypes(
	ID int identity(1,1) primary key,
	Name nvarchar(max) not null default '',
	IsDeleted int not null default 0,
	CreateUser int not null default 0,
	CreateDate datetime not null default getdate(),
	UpdateUser int not null default 0,
	UpdateDate datetime not null default getdate()
)
go

create table Customers(
	ID int identity(1,1) primary key,
	FullName nvarchar(max) not null default '',
	Email nvarchar(max) not null default '',
	Phone varchar(20) not null default '',
	Address nvarchar(max) not null default '',
	IsDeleted int not null default 0,
	CreateUser int not null default 0,
	CreateDate datetime not null default getdate(),
	UpdateUser int not null default 0,
	UpdateDate datetime not null default getdate()
)
go

create table Orders(
	ID int identity(1,1) primary key,
	Code varchar(512) not null default '',
	CustomerID int not null default 0,
	Phone varchar(20) not null default 0,
	Address nvarchar(max) not null default '',
	PaymentTypeID int not null default 0,
	DeliveryTypeID int not null default 0,
	Hours int not null default 0,
	Minutes int not null default 0,
	Note nvarchar(max) not null default '',
	TotalMoney decimal(18,2) not null default 0,
	VAT decimal(18,2) not null default 0,
	PrePayment decimal(18,2) not null default 0,
	FinalMoney decimal(18,2) not null default 0,
	ExportDate datetime not null default getdate(),
	IsDeleted int not null default 0,
	CreateUser int not null default 0,
	CreateDate datetime not null default getdate(),
	UpdateUser int not null default 0,
	UpdateDate datetime not null default getdate()
)

create table OrderDetails(
	ID int identity(18,2) primary key,
	OrderID int not  null default 0,
	ProductID int not null default 0,
	MaterialTypeID int not null default 0,
	ConstructionTypeID int not null default 0,
	Lenght decimal(18,2) not null default 0,
	Width decimal(18,2) not null default 0,
	Quantity int not null default 0,
	Price decimal(18,2) not null default 0,
	TotalPrice decimal(18,2) not null default 0,
	IsDeleted int not null default 0,
	CreateUser int not null default 0,
	CreateDate datetime not null default getdate(),
	UpdateUser int not null default 0,
	UpdateDate datetime not null default getdate()
)
go

create table Incomes(
	ID int identity(1,1) primary key,
	OrderID int not null default 0,
	TotalMoney decimal(18,2) not null default 0,
	RealRevenue decimal(18,2) not null default 0,
	LeftMoney decimal(18,2) not null default 0,
	CreateUser int not null default 0,
	CreateDate datetime not null default getdate(),
	UpdateUser int not null default 0,
	UpdateDate datetime not null default getdate()
)
go