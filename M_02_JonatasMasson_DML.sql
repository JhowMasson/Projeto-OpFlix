Use M_Opflix;		

set dateformat ymd

insert into TipoUsuario (Nome) values ('Administrador'), ('Cliente'), ('Parceiro');

insert into Genero (Nome) 
	values ('Com�dia'), ('Terror'), ('A��o'), ('Fantasia');

insert into TipoMetragem (Nome) values ('Filmes'),('S�ries');

insert into Lancamento (Nome, TempoDuracao, DataLancamento, Sinopse, IdGenero, IdTipoMetragem) values 
	('Letras: Em Busca da Palavra', '20:00:00', '2030-05-10', 'Um jovem tem um sonho de ser Doutor em Letras,  mas para isso, o jovem ir� passar por grandes aventuras', 3, 2),
	('Velozes e Furiosos 15: Opera��o Guinea Francesa', '03:00:00', '2013-01-15', 'Ap�s a Opera��o no Himalaia, os Tataranetos de Toretto, precisam provar que eles tem o sangue de seu antepassado nas pistas da Guinea Francesa', 3, 1),
	('Vingadores 7', '02:30:00', '2010-10-17', 'Depois do ocorrido em Nepal, o grupo de Vingadores precisam defender a terra dos Reptilianos, mas tudo desmorona quando Dilma vem em busca de seu companheiro Lula,  que est� preso na Terra', 4, 1),
	('A Volta Dos Que N�o Foram', '10:00:00', '2005-08-02', 'No universo de Ch�o-Teto, alguns jovens se reunem para voltar ao lugar que eles nunca foram antes, mas para isso, eles acabam passando por diver�as aventuras que nunca aconteceram' , 2, 2),
	('As Tran�as do Rei Careca', '02:45:00', '2017-03-28', 'Tudo parece perdido no reino de Cabel�ndia, quando um rei careca perde o seu renomado shampoo para suas tran�as naturais. Para recuperar seu produto muitas pessoas pagaram caro', 4, 1); 

insert into Usuario (Nome, Email, Senha, IdTipoUsuario) values
	('Erik', 'erik@email.com', '123456', 1),
	('Cassiana', 'cassiana@email.com', '123456', 1),
	('Helena', 'helena@email.com', '123456', 2),
	('Roberto', 'rob@email.com', '3110', 2);

insert into LancamentoFavorito (IdLancamento, IdUsuario) values
	(5, 2), (3, 1), (1, 3), (2, 4);