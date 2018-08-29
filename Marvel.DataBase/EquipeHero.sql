CREATE TABLE [dbo].[EquipeHero]
(
	IdHero int not null,
	IdEquipe int not null, 
    CONSTRAINT [FK_EquipeHero_Equipe] FOREIGN KEY ([IdEquipe]) REFERENCES Equipe(IdEquipe), 
    CONSTRAINT [FK_EquipeHero_Hero] FOREIGN KEY (IdHero) REFERENCES Hero(IdHero)
)
