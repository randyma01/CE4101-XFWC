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

#----------Usando la base----------#
USE WorldCupBD;


#----------Inicio: creando las tablas----------#

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
JuegosPerdidos INT, 
JuegosEmpatados INT, 
TotalMinutosJugados INT, 
Goles INT, 
TirosAMarco INT, 
Asistencias INT, 
RecuperacionBalones INT, 
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
FechaNacimiento DATE,
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
NombreTorneo VARCHAR (30),
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
PuntosModoCampeonato INT,
PuntosEquipoIdeal INT, 
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
IdTorneo INT NOT NULL,
IdFanatico INT NOT NULL, 
PRIMARY KEY (IdEquipoIdeal),
FOREIGN KEY(IdTorneo) REFERENCES Torneo(IdTorneo),
FOREIGN KEY(IdFanatico) REFERENCES Fanatico(IdFanatico)
);

CREATE TABLE Futbolista_EquipoIdeal(
IdFutbolista INT NOT NULL,
IdEquipoIdeal INT NOT NULL,
FOREIGN KEY(IdFutbolista) REFERENCES Futbolista(IdFutbolista),
FOREIGN KEY(IdEquipoIdeal) REFERENCES EquipoIdeal(IdEquipoIdeal)
);

CREATE TABLE Partido(
IdPartido INT NOT NULL AUTO_INCREMENT,
IdTorneo INT NOT NULL,
Narracion BLOB,
Fecha TIMESTAMP,
Sede VARCHAR(30),
Resultado VARCHAR(70),
PRIMARY KEY (IdPartido),
FOREIGN KEY(IdTorneo) REFERENCES Torneo(IdTorneo)
);

CREATE TABLE Seleccion_Partido(
IdSeleccion INT NOT NULL,
IdPartido INT NOT NULL,
FOREIGN KEY(IdSeleccion) REFERENCES Seleccion(IdSeleccion),
FOREIGN KEY(IdPartido) REFERENCES Partido(IdPartido)
);

CREATE TABLE Prediccion(
IdPrediccion INT NOT NULL AUTO_INCREMENT,
Resultado VARCHAR(5),
IdPartido INT NOT NULL,
IdFanatico INT NOT NULL,
PRIMARY KEY (IdPrediccion),
FOREIGN KEY(IdFanatico) REFERENCES Fanatico(IdFanatico),
FOREIGN KEY(IdPartido) REFERENCES Partido(IdPartido)
);

CREATE TABLE ModoCampeonato(
IdModoCampeonato INT NOT NULL AUTO_INCREMENT,
IdTorneo INT NOT NULL,
IdPrediccion INT NOT NULL,
IdFanatico INT NOT NULL,
PRIMARY KEY(IdModoCampeonato),
FOREIGN KEY(IdTorneo) REFERENCES Torneo(IdTorneo),
FOREIGN KEY(IdPrediccion) REFERENCES Prediccion(IdPrediccion),
FOREIGN KEY(IdFanatico) REFERENCES Fanatico(IdFanatico)
);


/*------------ Cargar datos a la base --------------*/

# Cargando paises #
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Data/listCountries.txt'
INTO TABLE worldcupbd.pais
FIELDS TERMINATED BY '\n' (NombrePais);

#---------------------------------------------------------------------------------------


# Cargando usuarios de prueba # 
INSERT INTO Usuario(NombreUsuario, ApellidoUsuario, Correo, UserName, Clave)
VALUES
("Gustavo", "Fallas", "gustavo@gmail.com", "tav","1234"),
("Randy", "Martinez", "randy@gmail.com", "ran","1235"),
("Ricardo", "Chang", "ricardo@gmail.com", "ric","1236");

INSERT INTO Usuario(NombreUsuario, ApellidoUsuario, Correo, UserName, Clave)
VALUES
("Root1", "too1", "root11@gmail.com", "root1","root12");

# Cargando usuario fanatico de prueba #
INSERT INTO Fanatico(Telefono, Puntos, IdPais, IdUsuario, Descripcion, Foto)
VALUES
("41400-9876", 0, 41, 1,"Me gusta el futbol.", "no tengo foto"),
("41400-9876", 0, 41, 2,"Me no gusta el futbol.", "no tengo foto"),
("41400-9876", 0, 41, 3,"Me gusta mucho el futbol.", "no tengo foto");


# Cargando usuario fanatico desactivado #
INSERT INTO Usuario_Desactivado(IdUsuario)
VALUE (3);

# Cargando usuario administrador de prueba #
INSERT INTO Administrador(IdUsuario)
VALUES(4);

#---------------------------------------------------------------------------------------

# Cargando patrocinadores  #
INSERT INTO Patrocinador (NombrePatrocinador)
VALUES 
("Nike"),
("Adidas"),
("Gatorade"),
("Visa"),
("Coca-Cola");


#---------------------------------------------------------------------------------------

# Cargando un torneo 1 #
INSERT INTO Torneo (NombreTorneo, FechaInicio, FechaFinaliza, IdPais,IdPatrocinador )
VALUES ("Costa Rica 2034", "2034-05-1 00:34:34", "2034-06-29 22:34:34", 41, 1);

# Cargando un torneo  2 #
INSERT INTO Torneo (NombreTorneo, FechaInicio, FechaFinaliza, IdPais,IdPatrocinador )
VALUES ("Mexico 2026", "2026-05-1 00:34:34", "2026-06-29 22:34:34", 114, 2);

# Cargando selecciones al torneo 1 #
INSERT INTO Seleccion(NombreSeleccion, IdPais)
VALUES
("Costa Rica", 41),
("Alemania",64),
("Argetina",7),
("Espana", 164);

# Cargando asociaciones de las selecciones al torneo 1 #
INSERT INTO Seleccion_Torneo(IdSeleccion, IdTorneo)
VALUES
(1,1),
(2,1),
(3,1),
(4,1);

##====================================================
##====================================================

# Cargando partido 1:  torneo 1 #
INSERT INTO Partido(IdTorneo, Narracion, Fecha, Sede, Resultado)
VALUES
(1, " sin narracion todavia " ,"2026-05-1 00:34:34", "Fello Meza", "4-4"),
(1, " sin narracion todavia " ,"2019-03-6 004:24:43", "Estadio Verde", "1-2"),
(2, " sin narracion todavia " ,"2005-02-16 04:34:34", "Estadio Azul", "3-2");

# Cargando selecciones en el partido 1: torneo 1 #
INSERT INTO Seleccion_Partido(IdSeleccion, IdPartido)
VALUES
#(1,1),
#(2,1),
(3,2),
(4,2),
(5,3),
(6,3);

#---------------------------------------------------------------------------------------

# Cargando predicciones #
INSERT INTO Prediccion(Resultado, IdPartido, IdFanatico) 
VALUES 
("2-1", 1, 1); 

# Cargando modo campeonato #
INSERT INTO ModoCampeonato(IdTorneo,IdPrediccion,IdFanatico)
VALUES
(1,1,1);

#---------------------------------------------------------------------------------------

# Cargando estadisiticas de Kante #
INSERT INTO Estadisticas
(JuegosGanados,JuegosPerdidos, JuegosEmpatados, TotalMinutosJugados,Goles, TirosAMarco, Asistencias, RecuperacionBalones, TarjetasAmarillas, TarjetasRojas, PenalesDetenidos, PenalesCometidos, RematesSalvados)
VALUES
(0,0,0,0,0,0,0,0,0,0,0,0,0);

# Cargando jugador Kante #
INSERT INTO Futbolista(Pasaporte, IdPais, Posicion, NombreFutbolista, FechaNacimiento, NombreEquipo, Altura, Peso, Precio, ActIivo, IdEstadisticas) 
VALUES
(56017835,60,"MF","KANTE Ngolo",'1991-03-29',"Chelsea FC (ENG)",168,70,10,True,1);

#---------------------------------------------------------------------------------------

# Cargando futbolista a una seleccion #
INSERT INTO Futbolista_Seleccion(IdSeleccion,IdFutbolista)
VALUES
(1,1);

# Cargando un equipo ideal a un usuario fanatico #
INSERT INTO EquipoIdeal(IdTorneo,IdFanatico)
VALUES(2,1);

# Cargando futbolista a un pinche equipo ideal #
INSERT INTO Futbolista_EquipoIdeal(IdFutbolista,IdEquipoIdeal)
VALUES
(1,1);

#---------------------------------------------------------------------------------------

# Cargando asociacon de usuarios fanaticos al torneo : 1 #
INSERT INTO Fanatico_Torneo(IdFanatico, IdTorneo, PuntosModoCampeonato, PuntosEquipoIdeal)
VALUES
(1,1,79,42);

#---------------------------------------------------------------------------------------

# Cargando poderes al torneo 1 #
INSERT INTO Poderes(NombrePoder, PuntajePoder, IdTorneo, IdPatrocinador)
VALUES
("Bonus Doble-Triple-Bien-Sadico", 33, 1, 3);

#---------------------------------------------------------------------------------------


/*------------ Queries --------------*/

SELECT * FROM Pais;