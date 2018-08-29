CREATE TABLE [dbo].[Personne]
(
	[IdPersonne] INT NOT NULL PRIMARY KEY identity(1,1),
	Nom nvarchar(50) not null,
	Prenom nvarchar(50) not null,
	Age int not null,
	Sexe bit not null, 
    [Mail] NVARCHAR(50) NOT NULL, 
    [MotDePasse] NVARCHAR(MAX) NOT NULL, 
    [Pseudo] NVARCHAR(50) NOT NULL, 
    [Hash] NVARCHAR(50) NOT NULL
)
