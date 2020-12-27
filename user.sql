--Create Database Base
--Use Base

--Create Table Table1
--(
--	Table1_ID int identity(1,1) primary key,
--	Name varchar(30) not null
--)

--Create Table Table2
--(
--	ID int identity(1,1) primary key,
--	Table1_ID int foreign key references Table1(ID) not null,
--	Descr varchar(100) not null
--)

--Create Login "1" With Password = '1'
--Create User "User" For Login "1"

--Grant Select On dbo.Table1 To "User"
--Grant Select On dbo.Table2 To "User"