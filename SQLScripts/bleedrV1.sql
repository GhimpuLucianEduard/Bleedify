use bleedr
go

create table Adrese
(
	Id int primary key identity(1,1),
	Judet nvarchar(30) not null,
	Oras nvarchar(30) not null,
	Strada nvarchar(30) not null,
	Numarul int not null,
	AdresaPostala int not null

);


create table TipuriInstitutiiAsociate
(
	Id int primary key identity(1,1),
	NumeTip nvarchar(30) not null

);

create table InstitutieAsociata
(
	Id int primary key identity(1,1),
	Adresa int foreign key references Adrese(Id),
	TipInstitutie int foreign key references TipuriInstitutiiAsociate(Id),
	Nume nvarchar(30) not null,
	NumarTelefon nvarchar(15) not null,
	Email nvarchar(30) not null
);


create table TipuriUtilizatori
(
	Id int primary key identity(1,1),
	NumeTip nvarchar(30) not null
);

create table Utilizatori
(
	Id int primary key identity(1,1),
	UserName nvarchar(30) not null,
	Password nvarchar(30) not null,
	TipUtilizator int foreign key references TipuriUtilizatori(Id),
	InstitutieAsociata int foreign key references InstitutieAsociata(Id)

);








create table Medici
(
	Id int primary key identity(1,1),
	IdUtilizator int foreign key references Utilizatori(Id),
	Nume nvarchar(30) not null,
	Prenume nvarchar(30) not null,
	IdentificatorMedic nvarchar(30) not null
	
);

create table GrupeDeSange
(
	Id int primary key identity(1,1),
	Nume nvarchar(10) not null

)


create table Pacienti
(
	Id int primary key identity(1,1),
	Nume nvarchar(30) not null,
	Prenume nvarchar(30) not null,
	DataNastere datetime not null,
	GrupaDeSange int foreign key references GrupeDeSange(Id),
	InstitutieAsociata int foreign key references InstitutieAsociata(Id)

);

create table Donatori
(
	Id int primary key identity(1,1),
	IdUtilizator int foreign key references Utilizatori(Id),
	Nume nvarchar(30) not null,
	Prenume nvarchar(30) not null,
	DataDonarePosibila datetime not null,
	GrupaDeSange int foreign key references GrupeDeSange(Id)
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
create table EtapeDonare
(
	Id int primary key identity(1,1),
	NumeEtapa nvarchar(30) not null,
);

create table Donatii
(
	Id int primary key identity(1,1),
	IdDonator int foreign key references Donatori(id),
	Etapa int foreign key references EtapeDonare(id),
	MotivRefuz nvarchar(1024)
);


create table TipuriAnunturiDonatori
(
	Id int primary key identity(1,1),
	NumeTip nvarchar(20) not null
);

create table AnunturiDonatori
(
	Id int primary key identity(1,1),
	IdDonator int foreign key references Donatori(Id),
	TipAnunt int foreign key references TipuriAnunturiDonatori(Id),
	Mesaj nvarchar(1024) not null,
	DataAnunt datetime not null
);




create table Personal
(
	Id int primary key identity(1,1),
	IdUtilizator int foreign key references Utilizatori(Id),
	Nume nvarchar(30) not null,
	Prenume nvarchar(30) not null

);

create table TipuriComponente
(
	Id int primary key identity(1,1),
	NumeTip nvarchar(10)
);

create table CereriMedicPacient
(
	Id int primary key identity(1,1),
	IdPacient int foreign key references Pacienti(Id),
	IdMedic int foreign key references Medici(id),
	TipComponenta int foreign key references TipuriComponente(Id)
);

create table Componente
(
	Id int primary key identity(1,1),
	Tip int foreign key references TipuriComponente(Id) not null,
	IdDonatie int foreign key references Donatii(id) not null,
	DataDepunere datetime not null,
	IdPrimitor int foreign key references Pacienti(id)

);