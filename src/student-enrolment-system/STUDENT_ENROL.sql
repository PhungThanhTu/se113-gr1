
create database STUDENTENROL
use STUDENTENROL
SET DATEFORMAT DMY
go
create table Account
(
 Account_id int primary key,
 Username nvarchar(50) not null,
 Password nvarchar(50) not null,
 Account_type nvarchar(50) not null
)
create table Benchmark
(
 Benchmark_id int primary key,
 Benchmark float,
 School nvarchar(50) not null,
 Faculty nvarchar(50) not null
)
create table Student
(
 Student_id int primary key,
 Student_name nvarchar(50) not null,
 Sex nvarchar(10) not null,
 Date_of_birth date,
 Total_score float,
 Benchmark_id int foreign key (Benchmark_id) references Benchmark(Benchmark_id)
)
create table Subject
(
 Subject_id int primary key,
 Subject_name nvarchar(50) not null
)
create table Score
(
 NumberOfBeats int primary key,
 Score float,
 Student_id int foreign key (Student_id) references Student(Student_id),
 Subject_id int foreign key (Subject_id) references Subject(Subject_id)
)
insert into Account values(1,'vodongphu','123456','Admin')
insert into Account values(2,'phungthanhtu','tu123abc',N'Teacher')

insert into Benchmark values(1,26,N'TRƯỜNG ĐẠI HỌC CÔNG NGHỆ THÔNG TIN',N'KỸ THUẬT PHẦN MỀM')
insert into Benchmark values(2,24,N'TRƯỜNG ĐẠI HỌC CÔNG NGHỆ THÔNG TIN',N'KỸ THUẬT MÁY TÍNH')
insert into Benchmark values(3,23,N'TRƯỜNG ĐẠI HỌC CÔNG NGHỆ THÔNG TIN',N'MẠNG MÁY TÍNH VÀ TRUYỀN THÔNG DỮ LIỆU')
insert into Benchmark values(4,25.3,N'TRƯỜNG ĐẠI HỌC KINH TẾ',N'QUẢN TRỊ KINH DOANH')
insert into Benchmark values(5,24.5,N'TRƯỜNG ĐẠI HỌC KINH TẾ',N'KẾ TOÁN')
insert into Benchmark values(6,24,N'TRƯỜNG ĐẠI HỌC KINH TẾ',N'LUẬT KINH TẾ')
insert into Benchmark values(7,27.5,N'TRƯỜNG ĐẠI HỌC NGOẠI THƯƠNG',N'KINH DOANH QUỐC TẾ')
insert into Benchmark values(8,27,N'TRƯỜNG ĐẠI HỌC NGOẠI THƯƠNG',N'KINH TẾ ĐỐI NGOẠI')

insert into Student values(1,N'Nguyễn Văn Hoàng','Nam','12/2/2004',23.6,3)
insert into Student values(2,N'Nguyễn Lan Anh',N'Nữ','1/5/2004',28,8)

insert into Score values(1,7,1,1)
insert into Score values(2,8,1,2)
insert into Score values(3,8.3,1,3)
insert into Score values(4,9,2,1)
insert into Score values(5,9,2,2)
insert into Score values(6,10,2,3)

insert into Subject values(1,N'Toán')
insert into Subject values(2,N'Văn')
insert into Subject values(3,N'Anh')
insert into Subject values(4,N'Lý')
insert into Subject values(5,N'Hóa')
insert into Subject values(6,N'Sinh')
insert into Subject values(7,N'Sử')
insert into Subject values(8,N'Địa')
insert into Subject values(9,N'GDCD')


