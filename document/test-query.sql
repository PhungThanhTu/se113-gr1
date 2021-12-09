select * from TAI_KHOAN_DANG_NHAP


create table test (
	id int primary key,
	name varchar(20)
)

select * from test

create table test2 (
	name varchar(20),
	age int
)

insert into test2 values ('nam',20)
insert into test2 values ('hai',23)
insert into test2 values ('binh',21)

select * from test2
select age from test2
select * from test2 where name='nam'
select name from test2 where age='23'