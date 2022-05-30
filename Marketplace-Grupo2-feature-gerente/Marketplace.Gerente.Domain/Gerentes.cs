using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Gerente.Domain
{
    public class Gerentes
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("dataAdmissao")]
        public string DataAdmissao { get; set; }

        [JsonProperty("salario")]
        public decimal Salario { get; set; }

        [JsonProperty("comissao")]
        public decimal Comissao { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("dataInclusao")]
        public DateTime DataInclusao { get; set; }

        [JsonProperty("dataAlteracao")]
        public DateTime DataAlteracao { get; set; }

    }
}
