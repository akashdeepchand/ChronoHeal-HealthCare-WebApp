create database ChronoHealDb
use ChronoHealDb

create table States
(StateId int primary key identity,
States nvarchar(50) not null unique)

create table Gender(
GId int primary key identity,
gender nvarchar(10) not null unique)

create table Marital(
MId int primary key identity,
MStatus nvarchar(50) not null unique)

create table Timing
(TId int primary key identity,
Timing nvarchar(50) not null unique)

create table Ward
(WId int primary key identity,
WardNo nvarchar(10) not null unique)

create table Department
(DepId int primary key identity,
Department nvarchar(50) not null unique)

create table Doctor
(DId int primary key identity,
DName varchar(50) not null,
Dep int foreign key references Department(DepId) on delete cascade on update cascade,
Timing int foreign key references Timing(TId) on delete cascade on update cascade,
Ward int foreign key references Ward(WId) on delete cascade on update cascade)



--create table Symptoms
--(SymId int primary key identity,
--Symptoms nvarchar(50) not null unique,
--department int foreign key references Department(DepId) on delete cascade on update cascade)


create table Appointment
(AId int primary key identity,
AFName nvarchar(50) not null,
ALName nvarchar(50) not null,
AContact nvarchar(10) not null,
AEmail nvarchar(50) not null,
AGender int foreign key references Gender(GId) on delete cascade on update cascade,
DOB Date not null,
Addrss nvarchar(50) not null,
City nvarchar(10) not null,
State1 int foreign key references States(StateId) on delete cascade on update cascade,
ASymptoms nvarchar(100) not null,
ADate Date not null,
RecieptId as right(AContact,3)+left(AFName,2)+Convert(nvarchar(50),AId)+left(AEmail,2))

-------------------------------------------------------------------
create table Career_Registration
(CRId int primary key identity,
CRName nvarchar(15) not null,
Gender int foreign key references Gender(GId) on delete cascade on update cascade,
Contact nvarchar(10) not null unique,
Email nvarchar(20) not null unique,
MartialStatus int foreign key references Marital(MId) on delete cascade on update cascade,
Aadhar nvarchar(12) not null unique,
DateOfBirth datetime not null,
Addrss nvarchar(50) not null,
City nvarchar(10) not null,
State1 int foreign key references States(StateId) on delete cascade on update cascade,
DoctorRegistration nvarchar(20) not null unique,
Qualification nvarchar(20) not null,
EducationBoard nvarchar(30) not null,
Specialization nvarchar(30),
ExperienceInYears int not null,
CRId1 as convert(nvarchar(50),CRId)+right(CRName,3)+left(Contact,2)+right(Aadhar,4) persisted)

--create table PDetails
--(PRId int primary key identity,
--PFName nvarchar(50) not null,
--PLName nvarchar(50) not null,
--Email nvarchar(128) foreign key references AspNetUsers(Id) on delete cascade on update cascade,
--Gender int foreign key references Gender(GId) on delete cascade on update cascade,
--Contact nvarchar(10) not null unique,
--DOB date not null,
--MartialStatus int foreign key references Marital(MId) on delete cascade on update cascade,
--Aadhar nvarchar(12) not null unique,
--MedicalHistory nvarchar(100) not null,
--Adrss nvarchar(100) not null,
--City nvarchar(50) not null,
--State1 int foreign key references States(StateId) on delete cascade on update cascade,
--Pin int not null,
--EmergencyContact nvarchar(10) not null unique,
--Insurance nvarchar(50) not null check(Insurance in('Yes','No','yes','no','y','n','Y','N','YES','NO')))







--create table PRegistration
--(PId int primary key,
--PName nvarchar(50) not null,
--Gender nvarchar(50) not null check(Gender in('Male','Female')),
--Contact nvarchar(50) not null unique,
--Aadhar int not null unique,
--Adrss nvarchar(100) not null,
--Ilness nvarchar(100) not null,
--ADId int foreign key references Doctor(DId),
--ADate date not null,
--AId as convert(nvarchar(50),ADId)+right(PName,2)+convert(nvarchar(50),PId)+left(Contact,2)+right(Aadhar,2) persisted)
--drop table doctor
--drop table Appointment
--select * from Doctor
--select * from Appointment
--insert into Department values(1,'Neurology'),(2,'Cardiology'),(3,'Gynocology'),(4,'Pediatrics'),(5,'General Medicine')
--insert into Doctor values(1,'Neurology','Shreyash','10am-12pm')
--insert into Appointment values(1,'Priyanka','Female','9876543210',098765432,'Delhi','fever','1','10/10/2022')
 
  
create table Roles  
(  
   Id int primary key identity(1,1),  
   RoleName nvarchar(50)  
)  
  
create table UserRoleMapping  
(  
   Id int primary key identity(1,1),  
   UserId nvarchar(128) foreign key references AspNetUsers(Id) on delete cascade on update cascade,  
   RoleId int foreign key references Roles(Id) on delete cascade on update cascade
) 

INSERT INTO Roles VALUES('Admin')
INSERT INTO Roles VALUES('User')

INSERT INTO UserRoleMapping VALUES('98fd0fa1-b997-4b46-a8c9-59926d2eeae0',1)
select*from UserRoleMapping 

create table Contact
(CtId int primary key identity(1,1),
CtName nvarchar(50) not null,
CtEmail nvarchar(50) not null unique,
CtSubject nvarchar(100) not null,
CtMessage nvarchar(256) not null)

Insert into States values
('Andaman and Nicobar Islands'),
('Andhra Pradesh'),
('Arunachal Pradesh'),
('Assam'),
('Bihar'),
('Chandigarh'),
('Chhattisgarh'),
('Dadra and Nagar Haveli'), 
('Daman and Diu'),
('Delhi'),
('Goa'),
('Gujarat'),
('Haryana'),
('Himachal Pradesh'),
('Jammu and Kashmir'),
('Jharkhand'),
('Karnataka'),
('Kerala'),
('Ladakh'),
('Lakshadweep'),
('Madhya Pradesh'),
('Maharashtra'),
('Manipur'),
('Meghalaya'),
('Mizoram'),
('Nagaland'),
('Odisha'),
('Puducherry'),
('Punjab'),
('Rajasthan'),
('Sikkim'),
('Tamil Nadu'),
('Telangana'),
('Tripura'),
('Uttar Pradesh'),
('Uttarakhand'),
('West Bengal')

--drop table Appointment
--drop table Symptoms
--drop table PDetails