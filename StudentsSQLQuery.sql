use [4875-BlogDB];

if exists (select 1 from sys.tables where OBJECT_ID = OBJECT_ID(N'[dbo].Students'))
drop table Students;

create table Students
(
	ID int identity(1,1) primary key,
	FirstName varchar(50),
	LastName varchar(50),
	Age int,
	Course varchar(50)
)

if exists (select 1 from sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].fetchData'))
drop procedure fetchData;
go
create procedure fetchData
as
begin
	select * from Students
end
exec fetchData

insert into Students
	values('Sufyan', 'Ghani', 25, '.NET')
insert into Students
	values('Muhammad', 'Faraz', 27, 'DevOps')
insert into Students
	values('Khushnood', 'Ali', 24, '.NET')
insert into Students
	values('Ahsan', 'Hanif', 25, 'SQA')
insert into Students
	values('Muhammad', 'Ali', 20, 'AI')


if exists (select 1 from sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].fetchDataByName'))
drop procedure fetchDataByName;
go
create procedure fetchDataByName
	@text varchar(50)
as
begin
	select * from Students
	where FirstName like N'%' + @text + N'%';
end

exec fetchDataByName a