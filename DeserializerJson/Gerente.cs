using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeserializerJson
{
    public class Gerente
    {
        public string Nome { get; set; }
        public string DataAdmissao { get; set; }
        public decimal Salario { get; set; }
        public decimal Comissao { get; set; }
        public Guid Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
