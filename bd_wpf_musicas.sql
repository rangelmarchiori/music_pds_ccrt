create database bd_wpf_musicas;
use bd_wpf_musicas;

create table Musica (
id_mus int primary key auto_increment,
nome_mus varchar (50),
duracao_mus varchar(20),
album_mus varchar (50),
banda_mus varchar (50),
estilo_mus varchar (100)
);