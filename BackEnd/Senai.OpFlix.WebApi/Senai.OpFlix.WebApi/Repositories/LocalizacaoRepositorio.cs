using MongoDB.Driver;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LocalizacaoRepositorio : ILocalizacaoRepositorio
    {
        private readonly IMongoCollection<LocalizacaoDomain> _localizacoes;

        public LocalizacaoRepositorio()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("m_opflix");
            _localizacoes = database.GetCollection<LocalizacaoDomain>("mapas");

        }

        public void Cadastrar(LocalizacaoDomain localizacoes)
        {
            _localizacoes.InsertOne(localizacoes);
        }

        public List<LocalizacaoDomain> Listar()
        {
            return _localizacoes.Find(l => true).ToList();
        }

    }
}
