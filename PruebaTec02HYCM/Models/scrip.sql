

CREATE DATABASE LibroAutores
USE LibroAutores

CREATE TABLE Libros
(
Id int identity(1,1) primary key,
Nombre varchar(50),
GeneroLite varchar(50),
Descripcion varchar(200),
AutorId int,

FOREIGN KEY (AutorId)references Autores(AutorId)
)

CREATE TABLE Autores
(
AutorId int identity(1,1) primary key,
Nombre varchar(50),
Nacionalidad varchar(50)
)

use LibroAutores