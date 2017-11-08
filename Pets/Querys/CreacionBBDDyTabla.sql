

Create Database Pets

Go

Use Pets

Go

Create table Veterinarios
(
	ID int primary key identity,
	Nombre nvarchar(50),
	Especialidad nvarchar(50)
)

Go

Insert into Veterinarios values ('Rafael Ortega','surgery')
Insert into Veterinarios values ('Helen Leary','radiology')
Insert into Veterinarios values ('Henry Stevens','radiology')
Insert into Veterinarios values ('James Carter','none')
Insert into Veterinarios values ('Sharon Jenkins','none')
Insert into Veterinarios values ('Linda Douglas','dentistry surgery')


Select * from Veterinarios