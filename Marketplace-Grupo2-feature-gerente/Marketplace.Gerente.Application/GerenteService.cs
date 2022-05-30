using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Gerente.Application;
using Marketplace.Gerente.Domain;
using Newtonsoft.Json;

namespace Marketplace.Gerente.Application
{
    public class GerenteService : IGerenteService
    {
        private readonly IGerenteRepository _repository;

        public GerenteService(IGerenteRepository repository)
        {
            _repository = repository;
        }

        public void Create()
        {
            var gerentes = _repository.DeserializarObjetos();

            _repository.SerializerListaDeObjetos(gerentes);
        }
        public void Up(Guid id, string nome, decimal salario, decimal comissao)
        {
            _repository.UpdateJson(id, nome, salario, comissao);
        }
        public void Del(Guid id)
        {
            _repository.Delete(id);
        }
        public void LerDezGerentes()
        {
            _repository.LerDez();
        }
        public void LerGerenteId(Guid id)
        {
            _repository.LerId(id);
        }
    }
}
