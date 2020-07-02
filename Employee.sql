IF DB_ID('Employee') IS NULL
CREATE DATABASE Employee
GO
USE Employee;


if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblManager')
drop table tblManager;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblAccessLevel')
drop table tblAccessLevel;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblReport')
drop table tblReport;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmployee')
drop table tblEmployee;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblSector')
drop table tblSector;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'vwEmployee')
drop view vwEmployee;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'vwEmployees')
drop view vwEmployees;


Create table tblAccessLevel (
AccessLevelID int identity (1,1) primary key,
AccessLevel varchar(10)
)

Create table tblSector (
SectorID int identity (1,1) primary key,
SectorName varchar(10)
)

create table tblEmployee(
EmployeeID int identity(1,1) primary key,
EmployeeName varchar(30) not null,
EmployeeLastName varchar(30) not null,
DateOfBirth date not null,
JMBG varchar(30) check(len(JMBG) = 13)  not null unique,
BankAccountNumber varchar(30) not null,
Email varchar(30),
Salary int,
Position varchar(30),
UserName varchar(30) not null unique,
Pass varchar(30) not null,
constraint checkBankAccountNumber check(BankAccountNumber not like '%[^0-9]%'),
constraint checkJMBG check(JMBG not like '%[^0-9]%'))

create table tblManager(
ManagerID int identity(1,1) primary key,
EmployeeID int foreign key (EmployeeID) references tblEmployee(EmployeeID) not null unique,
SectorID int foreign key (SectorID) references tblSector(SectorID) not null,
AccessLevelID int foreign key (AccessLevelID) references tblAccessLevel(AccessLevelID) not null)

create table tblReport(
ReportID int identity(1,1) primary key,
EmployeeID int foreign key (EmployeeID) references tblEmployee(EmployeeID) not null,
FullName varchar(30) not null,
ReportDate date not null,
Project varchar(30),
Position varchar(30),
HoursWorking int not null
)


insert into tblAccessLevel (AccessLevel)
values('modify');

insert into tblAccessLevel (AccessLevel)
values('read-only');

insert into tblSector (SectorName)
values('HR');

insert into tblSector (SectorName)
values('Finances');

insert into tblSector (SectorName)
values('R&D');

