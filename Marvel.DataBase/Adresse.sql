CREATE TABLE [dbo].[Adresse]
(
	[IdAdresse] INT NOT NULL PRIMARY KEY identity(1,1),
	Ville nvarchar(50) not null,
	CP int not null,
	Rue nvarchar(50) not null,
	Numero int not null,
	Boite nvarchar(5), 
	IdPersonne int not null,
    CONSTRAINT [FK_Adresse_Personne] FOREIGN KEY (IdPersonne) REFERENCES Personne([IdPersonne])
	
)
