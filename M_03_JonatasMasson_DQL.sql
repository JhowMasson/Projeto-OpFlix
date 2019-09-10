use M_Opflix

-- TESTE TIPO USU�RIO
select * from TipoUsuario
-- TESTE LAN�AMENTO
select * from Lancamento
-- TESTE G�NERO
select * from Genero order by IdGenero asc;
-- TESTE TIPO METRAGEM
select * from TipoMetragem order by IdTipoMetragem asc;
--TESTE  USU�RIO
select * from Usuario
--TESTE FILME FAVORITO
select * from LancamentoFavorito order by IdLancamento asc;

create view vwUsuario as 
select U.IdUsuario as CodigoId	
, U.Nome as NomeDoUsuario, T.Nome as TipoUsuario from Usuario as U
inner join TipoUsuario as T
on U.IdTipoUsuario = T.IdTipoUsuario

select * from vwUsuario

create procedure NumeroFilmesPorGenero 
	@IdGenero int as select count(@IdGenero) 
	as FilmesDoGenero from Lancamento
	where IdGenero = @IdGenero
	go

--SERVE PARA VOC� VER QUANTOS FILMES S�O POR CATEGORIA 
exec NumeroFilmesPorGenero 1
exec NumeroFilmesPorGenero 2
exec NumeroFilmesPorGenero 3
exec NumeroFilmesPorGenero 4


select count(IdUsuario) as NumeroUsuario from Usuario

select count(IdLancamento) as CadastroLancamento from Lancamento

--UPDATE

Update Genero
Set Nome = 'Romance'
Where Nome = 'Terror';


--FAZER O DELETE


