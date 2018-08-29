CREATE TABLE [dbo].[Combat]
(
	[IdCombat] INT NOT NULL PRIMARY KEY identity (1,1),
	IdEquipeVisiteur int not null,
	IdEquipeMaison int not null,
	IdGagnant int not null,
	Tnbr int not null,
	Score int not null, 
    CONSTRAINT [FK_Combat_Equipe1] FOREIGN KEY (IdEquipeVisiteur) REFERENCES Equipe(IdEquipe),
	CONSTRAINT [FK_Combat_Equipe2] FOREIGN KEY (IdEquipeMaison) REFERENCES Equipe(IdEquipe),
)
