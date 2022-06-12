CREATE TABLE Musician (
	IdMusician int NOT NULL IDENTITY AUTO_INCREMENT;
	FirstName nvarchar(30) NOT NULL;
	LastName nvarchar(50) NOT NULL;
	Nickname nvarchar(20);
	CONSTRAINT Musician_pk PRIMARY KEY (IdMusician);
)

INSERT INTO Musician(FirstName, LastName, Nickname)
VALUES {
	(Imin, Bharagjanrahda, Indian Monster),
	(Tom, Cook, Cookie Monsta),
	(Joshua, Jenkins, Zomboy),
	(Sonny, Moore, Skrillex)
}

CREATE TABLE Musician_Track (
	IdTrack int NOT NULL;
	IdMusician int NOT NULL;
	CONSTRAINT Musician_Track_pk PRIMARY KEY (IdTrack, IdMusician);
)

CREATE TABLE Track (
	IdTrack int NOT NULL IDENTITY AUTO_INCREMENT;
	TrackName nvarchar(20) NOT NULL;
	Duration float NOT NULL;
	IdMusicAlbum int;
	CONSTRAINT Track_pk PRIMARY KEY (IdTrack);
)

CREATE TABLE Album (
	IdAlbum int NOT NULL IDENTITY AUTO_INCREMENT;
	AlbumName nvarchar(30) NOT NULL;
	PublishDate datetime NOT NULL;
	IdMusicLabel int NOT NULL;
	CONSTRAINT Album_pk PRIMARY KEY (IdAlbum);
)

CREATE TABLE MusicLabel (
	IdMusicLabel int NOT NULL IDENTITY AUTO_INCREMENT;
	Name nvarchar(50) NOT NULL;
	CONSTRAINT MusicLabel_pk PRIMARY KEY (IdMusicLabel);
)

ALTER TABLE Musician_Track ADD CONSTRAINT Musician_Track_Track
    FOREIGN KEY (IdTrack)
    REFERENCES Track (IdTrack);

ALTER TABLE Musician_Track ADD CONSTRAINT Musician_Track_Musician
    FOREIGN KEY (IdMusician)
    REFERENCES Musician (IdMusician);
	
ALTER TABLE Track ADD CONSTRAINT Track_Album
    FOREIGN KEY (IdMusicAlbum)
    REFERENCES Album (IdMusicAlbum);
	
ALTER TABLE Album ADD CONSTRAINT Album_MusicLabel
    FOREIGN KEY (IdMusicLabel)
    REFERENCES MusicLabel (IdMusicLabel);
	
INSERT INTO MusicLabel(Name)
VALUES
	(Never Say Die),
	(Circus Records),
	(Indian Death Blow),
	(OWSLA);
	
INSERT INTO Album (AlbumName, PublishDate, IdMusicLabel)
VALUES
	(GRRAAAHHH!, 31-03-2011, 3),
	(The Outbreak, 04-08-2014, 1),
	(Fade To Black, 29-11-2019, 2),
	(Bangarang, 23-12-2011, 4);
	
INSERT INTO Track(TrackName, Duration, IdMusicAlbum)
VALUES {
	(Ghbharghar, 4.58, 1),
	(WTF!?, 3.34, 2),
	(Ginger Pubes, 5.09, null),
	(Bangarang, 3.37, 4),
	(Growl Throat, 2.38, 1),
	(Freak, 3.31, 3),
	(Supersonic, 2.47, null),
	(Desperado, 3.53, null)
}

