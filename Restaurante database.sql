CREATE database Restaurante;
Use Restaurante;

CREATE TABLE Usuario(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255),
    login VARCHAR(255),
    senha VARCHAR(255)
);

Create Table Reserva(
idReserva INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
nomeCleinte VARCHAR(250),
dataReserva varchar(250),
pessoasReserva int(30)
);