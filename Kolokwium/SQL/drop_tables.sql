ALTER TABLE Musician_Track DROP CONSTRAINT Musician_Track_Track;

ALTER TABLE Musician_Track DROP CONSTRAINT Musician_Track_Musician;
	
ALTER TABLE Track DROP CONSTRAINT Track_Album;
	
ALTER TABLE Album DROP CONSTRAINT Album_MusicLabel;

DROP TABLE Musician;

DROP TABLE Musician_Track;

DROP TABLE Track;

DROP TABLE Album;

DROP TABLE MusicLabel;