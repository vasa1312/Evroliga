CREATE TABLE Tim (
	timID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	naziv NVARCHAR(50) NOT NULL,
	pobede INT NOT NULL,
	porazi INT NOT NULL,
)

INSERT INTO Tim (naziv, pobede, porazi) VALUES ('Partizan',12,11)
INSERT INTO Tim (naziv, pobede, porazi) VALUES ('Crvena zvezda',10,13)
INSERT INTO Tim (naziv, pobede, porazi) VALUES ('Efes',11,12)
INSERT INTO Tim (naziv, pobede, porazi) VALUES ('Maccabi Tel Aviv',13,10)
INSERT INTO Tim (naziv, pobede, porazi) VALUES ('Bayern Munich',6,17)
INSERT INTO Tim (naziv, pobede, porazi) VALUES ('ASVEL',10,13)

CREATE TABLE TopScorer (
	igracID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	imePrezime NVARCHAR(50) NOT NULL,
	tim NVARCHAR(50) NOT NULL,
	ppg FLOAT NOT NULL
)

SELECT imePrezime, tim, ppg
FROM TopScorer
ORDER BY ppg DESC

INSERT INTO TopScorer (imePrezime,tim,ppg) VALUES ('Sasha Vezenkov','Olympiakos',17)
INSERT INTO TopScorer (imePrezime,tim,ppg) VALUES ('Mathias Lessort','Partizan',14.8)
INSERT INTO TopScorer (imePrezime,tim,ppg) VALUES ('Kevin Punter','Partizan',12.2)
INSERT INTO TopScorer (imePrezime,tim,ppg) VALUES ('Luca Vildoza','Crvena zvezda',11.9)
INSERT INTO TopScorer (imePrezime,tim,ppg) VALUES ('Nemanja Nedovic','Crvena zvezda', 11.8)

CREATE TABLE Fantasy (
	fantasyID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	imePrezime NVARCHAR(50) NOT NULL,
	brojFantasyPoena FLOAT NOT NULL,
)