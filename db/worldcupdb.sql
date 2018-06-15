/*
Instituto Tecnológico de Costa Rica

Curso: Especificación y Diseño de Software

Proyecto: X-FIFA World Cuo (MySQL)

Semestre I, 2018

Miembros:
	Gustavo Fallas Carrera - 2014035394
	Randy Martínez Sandí - 2014047395
	Ricardo Chang Villalobos - 2014040801
*/

#----------Creando bases de datos llamada: WorldCupBD----------#
CREATE DATABASE IF NOT EXISTS WorldCupBD;

#----------Usaando la base----------#
USE WorldCupBD;


#----------Inicio: Creando las tablas----------#

CREATE TABLE Pais(
IdPais INT NOT NULL AUTO_INCREMENT, 
NombrePais TEXT,
PRIMARY KEY (IdPais)
);

CREATE TABLE Usuario (
IdUsuario INT NOT NULL AUTO_INCREMENT,
NombreUsuario VARCHAR(30) NOT NULL,
ApellidoUsuario VARCHAR(30) NOT NULL,
Correo VARCHAR(30) NOT NULL,
Username VARCHAR(8) NOT NULL UNIQUE,
Clave VARCHAR(8) NOT NULL UNIQUE,
PRIMARY KEY(IdUsuario)
);

CREATE TABLE Fanatico (
IdFanatico INT NOT NULL AUTO_INCREMENT,
Telefono VARCHAR (10),
Puntos INT,
IdPais INT NOT NULL,
IdUsuario INT NOT NULL,
Descripcion TEXT,
Foto BLOB,
PRIMARY KEY(IdFanatico),
FOREIGN KEY (IdPais) REFERENCES Pais(IdPais),
FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Administrador(
IdAdmin INT NOT NULL AUTO_INCREMENT,
IdUsuario INT NOT NULL,
PRIMARY KEY (IdAdmin),
FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Usuario_Desactivado(
IdUsuario INT NOT NULL,
FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Patrocinador(
IdPatrocinador INT NOT NULL AUTO_INCREMENT, 
NombrePatrocinador VARCHAR(30),
PRIMARY KEY(IdPatrocinador)
);

CREATE TABLE Estadisticas(
IdEstadisticas INT NOT NULL AUTO_INCREMENT, 
JuegosGanados INT, 
JuegosPerdido INT, 
JuegosEmpatados INT, 
TotalMinutosJugados INT, 
Goles INT, 
TirosAMarco INT, 
Asistentcias INT, 
RecupercionBalones INT, 
TarjetasAmarillas INT, 
TarjetasRojas INT, 
PenalesDetenidos INT, 
PenalesCometidos INT, 
RematesSalvados INT,
PRIMARY KEY(IdEstadisticas)
);

CREATE TABLE Futbolista(
IdFutbolista INT NOT NULL AUTO_INCREMENT, 
Pasaporte INT,
IdPais INT ,
Posicion VARCHAR(30),
NombreFutbolista VARCHAR(60),
FechaNacimiento TIME,
NombreEquipo VARCHAR(30),
Altura  INT,
Peso    INT,
Precio INT,
Activo BOOL,
IdEstadisticas INT, 
PRIMARY KEY(IdFutbolista),
FOREIGN KEY(IdEstadisticas) REFERENCES Estadisticas(IdEstadisticas),
FOREIGN KEY(IdPais) REFERENCES Pais(IdPais)
);


CREATE TABLE Seleccion(
IdSeleccion INT NOT NULL AUTO_INCREMENT,
NombreSeleccion VARCHAR (30),
IdPais INT NOT NULL,
PRIMARY KEY(IdSeleccion),
FOREIGN KEY (IdPais) REFERENCES Pais(IdPais)
);

CREATE TABLE Torneo(
IdTorneo INT NOT NULL AUTO_INCREMENT, 
Nombre VARCHAR (30),
FechaInicio TIMESTAMP, 
FechaFinaliza TIMESTAMP, 
IdPais INT NOT NULL, 
IdPatrocinador INT NOT NULL,
PRIMARY KEY(IdTorneo),
FOREIGN KEY(IdPais) REFERENCES Pais(IdPais),
FOREIGN KEY(IdPatrocinador) REFERENCES Patrocinador(IdPatrocinador)
);


CREATE TABLE Futbolista_Seleccion(
IdSeleccion INT NOT NULL,
IdFutbolista INT NOT NULL,
FOREIGN KEY(IdSeleccion) REFERENCES Seleccion(IdSeleccion),
FOREIGN KEY(IdFutbolista) REFERENCES Futbolista(IdFutbolista)
);

CREATE TABLE Seleccion_Torneo(
IdSeleccion INT NOT NULL,
IdTorneo INT NOT NULL, 
FOREIGN KEY(IdSeleccion) REFERENCES Seleccion(IdSeleccion),
FOREIGN KEY(IdTorneo) REFERENCES Torneo(IdTorneo)
);

CREATE TABLE Fanatico_Torneo(
IdFanatico INT NOT NULL,
IdTorneo INT NOT NULL, 
PuntosFanatico INT,
FOREIGN KEY(IdFanatico) REFERENCES Fanatico(IdFanatico),
FOREIGN KEY(IdTorneo) REFERENCES Torneo(IdTorneo)
);

CREATE TABLE Ganadores(
IdFanatico INT NOT NULL,
IdTorneo INT NOT NULL, 
FOREIGN KEY(IdFanatico) REFERENCES Fanatico(IdFanatico),
FOREIGN KEY(IdTorneo) REFERENCES Torneo(IdTorneo)
);

CREATE TABLE Poderes(
IdPoder INT NOT NULL AUTO_INCREMENT,
NombrePoder VARCHAR(30),
PuntajePoder INT,
IdTorneo INT NOT NULL,
IdPatrocinador INT NOT NULL, 
PRIMARY KEY (IdPoder),
FOREIGN KEY(IdTorneo) REFERENCES Torneo(IdTorneo),
FOREIGN KEY(IdPatrocinador) REFERENCES Patrocinador(IdPatrocinador)
);

CREATE TABLE EquipoIdeal(
IdEquipoIdeal INT NOT NULL AUTO_INCREMENT, 
IdFanatico INT NOT NULL, 
IdTorneo INT NOT NULL,
PRIMARY KEY (IdEquipoIdeal),
FOREIGN KEY(IdFanatico) REFERENCES Fanatico(IdFanatico),
FOREIGN KEY(IdTorneo) REFERENCES Torneo(IdTorneo)
);

CREATE TABLE ModoCampeonato(
IdModoCampeonato INT NOT NULL AUTO_INCREMENT,
IdFanatico INT NOT NULL,
IdTorneo INT NOT NULL,
PRIMARY KEY(IdModoCampeonato),
FOREIGN KEY(IdFanatico) REFERENCES Fanatico(IdFanatico),
FOREIGN KEY(IdTorneo) REFERENCES Torneo(IdTorneo)
);

CREATE TABLE Jugadres_EquipoIdeal(
IdFutbolista INT NOT NULL,
IdEquipoIdeal INT NOT NULL,
FOREIGN KEY(IdFutbolista) REFERENCES Futbolista(IdFutbolista),
FOREIGN KEY(IdEquipoIdeal) REFERENCES EquipoIdeal(IdEquipoIdeal)
);


LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Data/listCountries.txt'
INTO TABLE worldcupbd.pais
FIELDS TERMINATED BY '\n' (NombrePais);

 

 
INSERT INTO Usuario(NombreUsuario, ApellidoUsuario, Correo, UserName, Clave)
VALUES
("Gustavo", "Fallas", "gustavo@gmail.com", "tav","1234"),
("Randy", "Martinez", "randy@gmail.com", "ran","1235"),
("Ricardo", "Chang", "ricardo@gmail.com", "ric","1236");

INSERT INTO Usuario(NombreUsuario, ApellidoUsuario, Correo, UserName, Clave)
VALUES
("Root1", "too1", "root11@gmail.com", "root1","root12");
INSERT INTO Patrocinador(NombrePatrocinador) VALUES ("X-Coca-Cola");

INSERT INTO Torneo (Nombre, FechaInicio, FechaFinaliza, IdPais, IdPatrocinador)
VALUES
("Australia 2028 X-Coca-Cola", "2028-06-22 00:00:00", "2028-06-22 00:00:00", 9 ,1);


