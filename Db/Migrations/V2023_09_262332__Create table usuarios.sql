CREATE TABLE Usuarios (
	Id TEXT NOT NULL,
	Nome TEXT NOT NULL,
	PRIMARY KEY (Id),
	CHECK (length(Nome) >= 3 AND length(Nome) <= 50)
);