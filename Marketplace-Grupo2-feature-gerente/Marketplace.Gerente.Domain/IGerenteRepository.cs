using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Gerente.Domain
{
    public interface IGerenteRepository
    {
        List<Gerentes> DeserializarObjetos();
        void SerializerListaDeObjetos(List<Gerentes> listaGerentes);
        void UpdateJson(Guid id, string nome, decimal salario, decimal comissao);
        void Delete(Guid id);
        List<Gerentes> DeserializarObjetosOutput();
        void LerDez();
        void LerId(Guid id);
    }
}
