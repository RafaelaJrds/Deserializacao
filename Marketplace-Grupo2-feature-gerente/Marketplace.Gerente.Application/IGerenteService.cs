using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Gerente.Application
{
    public interface IGerenteService
    {
        void Create();
        void Up(Guid id, string nome, decimal salario, decimal comissao);
        void Del(Guid id);
        void LerDezGerentes();
        void LerGerenteId(Guid id);
    }
}
