use BleedrFinal
go

create table Adresa
(
	Id int primary key identity(1,1),
	Judet nvarchar(30) not null,
	Oras nvarchar(30) not null,
	Strada nvarchar(30) not null,
	Numarul int not null,
	AdresaPostala int not null

);


create table TipInstituteAsociata
(
	Id int primary key identity(1,1),
	NumeTip nvarchar(30) not null

);

create table InstitutieAsociata
(
	Id int primary key identity(1,1),
	Adresa int foreign key references Adresa(Id),
	TipInstitutie int foreign key references TipInstituteAsociata(Id),
	Nume nvarchar(30) not null,
	NumarTelefon nvarchar(15) not null,
	Email nvarchar(30) not null
);


create table TipUtilizator
(
	Id int primary key identity(1,1),
	NumeTip nvarchar(30) not null
);

create table Utilizator
(
	Id int primary key identity(1,1),
	UserName nvarchar(30) not null,
	Password nvarchar(30) not null,
	TipUtilizator int foreign key references TipUtilizator(Id),
	InstitutieAsociata int foreign key references InstitutieAsociata(Id)
);


create table Medic
(
	Id int primary key identity(1,1),
	IdUtilizator int foreign key references Utilizator(Id),
	Nume nvarchar(30) not null,
	Prenume nvarchar(30) not null,
	IdentificatorMedic nvarchar(30) not null
	
);

create table GrupaDeSange
(
	Id int primary key identity(1,1),
	Nume nvarchar(10) not null

)


create table Pacient
(
	Id int primary key identity(1,1),
	Nume nvarchar(30) not null,
	Prenume nvarchar(30) not null,
	DataNastere datetime not null,
	GrupaDeSange int foreign key references GrupaDeSange(Id),
	InstitutieAsociata int foreign key references InstitutieAsociata(Id)

);

create table Donator
(
	Id int primary key identity(1,1),
	IdUtilizator int foreign key references Utilizator(Id),
	Nume nvarchar(30) not null,
	Prenume nvarchar(30) not null,
	DataDonarePosibila datetime not null,
	GrupaDeSange int foreign key references GrupaDeSange(Id)
);


/*
create table GlobuleRosii
(
	Id int primary key identity(1,1),
	DataDepunere datetime not null,
	IdPrimitor int foreign key references Pacienti(Id)
);

create table Trombocite
(
	Id int primary key identity(1,1),
	DataDepunere datetime not null,
	IdPrimitor int foreign key references Pacienti(Id)
);

create table Plasma
(
	Id int primary key identity(1,1),
	DataDepunere datetime not null,
	IdPrimitor int foreign key references Pacienti(Id)
);
*/
create table EtapaDonare
(
	Id int primary key identity(1,1),
	NumeEtapa nvarchar(30) not null,
);

create table Donatie
(
	Id int primary key identity(1,1),
	IdDonator int foreign key references Donator(id),
	Etapa int foreign key references EtapaDonare(id),
	MotivRefuz nvarchar(1024)
);


create table TipAnuntDonator
(
	Id int primary key identity(1,1),
	NumeTip nvarchar(20) not null
);

create table AnuntDonator
(
	Id int primary key identity(1,1),
	IdDonator int foreign key references Donator(Id),
	TipAnunt int foreign key references TipAnuntDonator(Id),
	Mesaj nvarchar(1024) not null,
	DataAnunt datetime not null
);




create table Personal
(
	Id int primary key identity(1,1),
	IdUtilizator int foreign key references Utilizator(Id),
	Nume nvarchar(30) not null,
	Prenume nvarchar(30) not null

);

create table TipComponenta
(
	Id int primary key identity(1,1),
	NumeTip nvarchar(10)
);

create table CerereMedicPacient
(
	Id int primary key identity(1,1),
	IdPacient int foreign key references Pacient(Id),
	IdMedic int foreign key references Medic(id),
	GrupaDeSange int foreign key references GrupaDeSange(Id),
	TipComponenta int foreign key references TipComponenta(Id)
);

create table Componenta
(
	Id int primary key identity(1,1),
	Tip int foreign key references TipComponenta(Id) not null,
	IdDonatie int foreign key references Donatie(id) not null,
	DataDepunere datetime not null,
	IdPrimitor int foreign key references Pacient(id),
	InstitutieAsociata int foreign key references InstitutieAsociata(Id),
	GrupaDeSange int foreign key references GrupaDeSange(Id)
);
