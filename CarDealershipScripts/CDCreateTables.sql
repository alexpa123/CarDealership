use master
go

if exists(select * from sys.tables where name='BodyStyle')
drop table BodyStyle
go

if exists(select * from sys.tables where name='Type')
drop table [Type]
go

if exists(select * from sys.tables where name='Transmission')
drop table Transmission
go

if exists(select * from sys.tables where name='ExteriorColor')
drop table ExteriorColor
go

if exists(select * from sys.tables where name='InteriorColor')
drop table InteriorColor
go

if exists(select * from sys.tables where name='Special')
drop table Special
go

if exists(select * from sys.tables where name='Role')
drop table [Role]
go

if exists(select * from sys.tables where name='User')
drop table [User]
go

if exists(select * from sys.tables where name='RoleUser')
drop table RoleUser
go

if exists(select * from sys.tables where name='Make')
drop table Make
go

if exists(select * from sys.tables where name='Model')
drop table Model
go

if exists(select * from sys.tables where name='UserMake')
drop table UserMake
go

if exists(select * from sys.tables where name='UserMakeModel')
drop table UserMakeModel
go

if exists(select * from sys.tables where name='Car')
drop table Car
go

if exists(select * from sys.tables where name='Customer')
drop table Customer
go

if exists(select * from sys.tables where name='Sale')
drop table Sale
go

if exists(select * from sys.tables where name='Contact')
drop table Contact
go

if exists(select * from sys.databases where name='CarDealershipDB')
drop database CarDealershipDB
go

create database CarDealershipDB
go

use CarDealershipDB
go

create table [Type](
	TypeId int identity(1,1) primary key not null,
	[Type] varchar(10)
)

create table BodyStyle(
	BodyStyleId int identity(1,1) primary key not null,
	BodyStyle varchar(20)
)

create table Transmission(
	TransmissionId int identity(1,1) primary key not null,
	Transmission varchar(20)
)

create table ExteriorColor(
	ExteriorColorId int identity(1,1) primary key not null,
	Color varchar(20)
)

create table InteriorColor(
	InteriorColorId int identity(1,1) primary key not null,
	Color varchar(20)
)

create table Special(
	SpecialId int identity(1,1) primary key not null,
	Title varchar(20),
	[Description] varchar(2000)
)

create table [Role](
	RoleId int identity(1,1) primary key not null,
	Title varchar(20)
)

create table [User](
	UserName varchar(20) primary key not null,
	RoleId int foreign key references [Role](RoleId),
	FirstName varchar(20),
	LastName varchar(20),
	Email varchar(20),
	PhoneNumber varchar(20),
	[Password] varchar(20)
)

create table RoleUser(
	RoleId int foreign key references [Role](RoleId),
	UserName varchar(20) foreign key references [User](UserName),
)

create table Make(
	MakeId int identity(1,1) primary key not null,
	Make varchar(20)
)

create table Model(
	ModelId int identity(1,1) primary key not null,
	MakeId int foreign key references Make(MakeId),
	Model varchar(20)
)

create table UserMake(
	UserName varchar(20) foreign key references [User](UserName),
	MakeId int foreign key references Make(MakeId),
	DateAdded date
)

create table UserMakeModel(
	UserName varchar(20) foreign key references [User](UserName),
	ModelId int foreign key references Model(ModelId),
	MakeId int foreign key references Make(MakeId),
	DateAdded date
)

create table Car(
	CarId int identity(1,1) primary key not null,
	MakeId int foreign key references Make(MakeId),
	ModelId int foreign key references Model(ModelId),
	SpecialId int foreign key references Special(SpecialId),
	BodyStyleId int foreign key references BodyStyle(BodyStyleId),
	TransmissionId int foreign key references Transmission(TransmissionId),
	Price decimal,
	MSRP decimal,
	TypeId int foreign key references [Type](TypeId),
	ExteriorColorId int foreign key references ExteriorColor(ExteriorColorId),
	InteriorColorId int foreign key references InteriorColor(InteriorColorId),
	VIN varchar(20),
	Mileage int,
	[Description] varchar(2000),
	[Image] varchar(20),
	Sold bit,
	Featured bit,
	[Year] int
)

create table Customer(
	CustomerId int identity(1,1) primary key not null,
	FirstName varchar(30),
	LastName varchar(30),
	Phone varchar(20),
	Email varchar(50),
	Street1 varchar(100),
	Street2 varchar(100),
	City varchar(50),
	Zipcode varchar(20),
	[State] varchar(2),
)

create table Sale(
	SaleId int identity(1,1) primary key not null,
	UserName varchar(20) foreign key references [User](UserName),
	CarId int foreign key references Car(CarId),
	PurchaseType varchar(10),
	PurchasePrice decimal,
	[Name] varchar(30),
	Phone varchar(30),
	Email varchar(30),
	Street1 varchar(30),
	Street2 varchar(30),
	City varchar(30),
	[State] varchar(30),
	Zipcode varchar(30),
	[Date] date
)

create table Contact(
	ContactId int identity(1,1) primary key not null,
	[Name] varchar(30),
	Email varchar(30),
	Phone varchar(12),
	[Message] varchar(1000),
	VIN varchar(30)
)


