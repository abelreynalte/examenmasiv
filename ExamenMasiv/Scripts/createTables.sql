create table colour(
	id tinyint identity(1,1) primary key,
	description varchar(50)
)
go

create table ruleta(
	id int identity(1,1) primary key,
	date datetime default(getdate()),
	active bit
)
go

create table ruletadetail(
	id int identity(1,1) primary key,
	ruletaid int foreign key references ruleta(id),
	number int,
	colourid tinyint foreign key references colour(id),
	amount decimal
)
go

create table users(
	userid int identity(1,1) primary key,
	username varchar(100),
	password varchar(100),
	fullname varchar(100),
	date datetime default(getdate())
)
go

create table userbet(
	userid int foreign key references users(userid),
	ruletadetailid int foreign key references ruletadetail(id),
	amount decimal(18,2),
	date datetime default(getdate())
)
go

create table resultruleta(
	ruletadetailid int foreign key references ruletadetail(id),
	date datetime default(getdate())	
)
go

create table resultbet(
	userid int,
	ruletadetailid int,
	awardamount decimal(18,2),
	date datetime default(getdate())
)
go

insert into users(username, password, fullname) values('pedro', '123', 'Pedro Ramirez')
insert into users(username, password, fullname) values('juan', '123', 'Juan Gonzales')
insert into users(username, password, fullname) values('roberto', '123', 'Roberto Priale')
insert into users(username, password, fullname) values('jazmin', '123', 'Jazmin Prieto')
insert into users(username, password, fullname) values('nicole', '123', 'Nicole Kitman')

insert into colour(description) values('rojo'), ('negro')

/*
select * from users
select * from colour

drop table resultbet
drop table resultruleta
drop table userbet
drop table users
drop table ruletadetail
drop table ruleta
drop table colour
*/