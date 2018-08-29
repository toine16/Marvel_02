CREATE TABLE [dbo].[Equipe]
(
	[IdEquipe] INT NOT NULL PRIMARY KEY identity(1,1),
	IdPersonne int not null,
	Nom nvarchar(50) NOT NULL, 
    CONSTRAINT [FK_Equipe_Personne] FOREIGN KEY (IdPersonne) REFERENCES Personne([IdPersonne])
)
