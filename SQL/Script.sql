create database minimusDB
go
use minimusDB
go

create table users(
iduser int primary key identity(1,1),
mail nvarchar(50),
pasword nvarchar(50),
cities nvarchar(500));
go

insert into users
values
('jorgereg1998@gmail.com','1234abcD','')
go

create procedure getusers
as
select * from users
go

create procedure adduser
(
	@mail nvarchar(50),
	@pasword nvarchar(50),
	@cities nvarchar(500),
	@haserror bit out
)
as
begin try
	set @haserror = 0;
	insert into users
	values
	(@mail,@pasword,@cities)
end try
begin catch
	set @haserror = 1;
end catch
go

create procedure deleteuser
(
	@iduser int,
	@haserror bit out
)
as
set @haserror = 1
begin try
if exists(select top 1 1 from users where iduser = @iduser)
begin
	set @haserror = 0
	delete users where iduser = @iduser
end
end try
begin catch
	set @haserror = 1;
end catch
go

create procedure updateuser
(
	@mail nvarchar(50),
	@pasword nvarchar(50),
	@cities nvarchar(500),
	@haserror bit out
)
as
set @haserror = 1
begin try
if exists(select top 1 1 from users where mail = @mail)
begin
	set @haserror = 0
	update users
	set mail = @mail, pasword = @pasword, cities = @cities
	where mail = @mail
end
end try
begin catch
	set @haserror = 1;
end catch
go

create procedure exist
(
	@mail nvarchar(50),
	@haserror bit out
)
as
set @haserror = 1
begin try
if exists(select top 1 1 from users where mail = @mail)
begin
	set @haserror = 0
end
end try
begin catch
	set @haserror = 1;
end catch
go

create procedure verify
(
	@mail nvarchar(50),
	@pasword nvarchar(50),
	@haserror bit out
)
as
set @haserror = 1
begin try
if exists(select top 1 1 from users where mail = @mail and pasword = @pasword)
begin
	set @haserror = 0
end
end try
begin catch
	set @haserror = 1;
end catch
go