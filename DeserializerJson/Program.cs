using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Nancy.Json;
using Newtonsoft.Json;

namespace DeserializerJson
{
    
      
    
    class Program
    {
        static void Main(string[] args)
        {
            string nomeArquivo = DateTime.Now.ToString().Replace(@"/", "").Replace(" ", "").Replace(":", "") + ".json";
           var Teste = DeserializarListaObjetos();
                        
           SerializerListaDeObjetos(nomeArquivo);

        }
       
        private static void SerializerListaDeObjetos(string nomeArquivo)
        {
            using(StreamWriter stream = new StreamWriter(Path.Combine(@"C:\Marketplace\DeserializerJson",nomeArquivo)))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(stream, RepositorioGerente.listOfGerentesSalvos);
            }
        }
        private static List<Gerente> DeserializarListaObjetos()
        {
            List<Gerente> gerentes = null;
            
            using (StreamReader stream = new StreamReader(@"C:\Marketplace\DeserializerJson\DeserializerJson\dado\gerentesInput.json"))
            {
                string jsonString = stream.ReadToEnd();
                              
                gerentes = JsonConvert.DeserializeObject<List<Gerente>>(jsonString);
                
            }
            
            RepositorioGerente.listOfGerentesSalvos = gerentes;
            foreach (Gerente gerente in RepositorioGerente.listOfGerentesSalvos)
            {

                gerente.Id = Guid.NewGuid();
                gerente.DataInclusao = DateTime.Now;
                gerente.DataAlteracao = DateTime.Now;
                Console.WriteLine(string.Format("nome: {0}, \n dataAdmissao: {1}, \n salario: {2}, \n comissao: {3}, \n Id: {4}, \n dataInclusao: {5}, \n dataAlteracao: {6}", gerente.Nome, gerente.DataAdmissao, gerente.Salario, gerente.Comissao, gerente.Id, gerente.DataInclusao, gerente.DataAlteracao));
                Console.ReadKey();

            }
            return gerentes;
            
        }
    }
}