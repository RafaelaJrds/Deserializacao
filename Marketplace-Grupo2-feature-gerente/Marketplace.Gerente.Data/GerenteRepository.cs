using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Gerente.Domain;
using Newtonsoft.Json;

namespace Marketplace.Gerente.Data
{
    public class GerenteRepository : IGerenteRepository
    {
        public List<Gerentes> DeserializarObjetos()
        {
            List<Gerentes> gerentes = null;

            using (StreamReader stream = new StreamReader(@"C:\Users\rafae\OneDrive\Área de Trabalho\Marketplace-Grupo2-feature-gerente\Marketplace-Grupo2-feature-gerente\Marketplace.Gerente.Console\gerentesInput.json"))
            {
                string jsonString = stream.ReadToEnd();

                gerentes = JsonConvert.DeserializeObject<List<Gerentes>>(jsonString);

            }
            foreach (Gerentes gerente in gerentes)
            {
                gerente.Id = Guid.NewGuid();
                gerente.DataInclusao = DateTime.Now;
                gerente.DataAlteracao = DateTime.Now;
            }
            return gerentes;
        }
        public List<Gerentes> DeserializarObjetosOutput()
        {
            List<Gerentes> gerentes = null;

            using (StreamReader stream = new StreamReader(@"C:\Users\rafae\OneDrive\Área de Trabalho\Marketplace-Grupo2-feature-gerente\Marketplace-Grupo2-feature-gerente\Marketplace.Gerente.Console\gerentesOutput.json"))
            {
                string jsonString = stream.ReadToEnd();

                gerentes = JsonConvert.DeserializeObject<List<Gerentes>>(jsonString);

            }
            
            return gerentes;
        }
        public void SerializerListaDeObjetos(List<Gerentes> listaGerentes)
        {
            using (StreamWriter stream = new StreamWriter(Path.Combine(@"C:\Users\rafae\OneDrive\Área de Trabalho\Marketplace-Grupo2-feature-gerente\Marketplace-Grupo2-feature-gerente\Marketplace.Gerente.Console", "gerentesOutput.json")))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(stream, listaGerentes);
                                
            }
        }
        //Realizar update usando Id
        public void UpdateJson(Guid id, string nome, decimal salario, decimal comissao)
        {
            
            List<Gerentes> listadegerentes = DeserializarObjetosOutput();

            foreach (Gerentes g in listadegerentes)
            {
                if (g.Id == id)
                {
                    if (nome != null && !nome.Equals(""))
                    {
                        g.Nome = nome;


                    }
                    if (salario != null && !salario.Equals(""))
                    {

                        g.Salario = salario;
                    }
                    if (comissao != null && !comissao.Equals(""))
                    {
                        g.Comissao = comissao;

                    }
                    g.DataInclusao = DateTime.Now;
                    g.DataAlteracao = DateTime.Now;
                }
            }

            SerializerListaDeObjetos(listadegerentes);
        }
        // Deletar arquivo usando id
        public void Delete(Guid id)
        {
            List<Gerentes> listadegerentes = DeserializarObjetosOutput();
            {
                for (int i = 0; i < listadegerentes.Count; i++)
                {
                 if (listadegerentes[i].Id ==id)
                    {
                        listadegerentes.Remove(listadegerentes[i]);
                    }
                }
                 
            }
            
        }
        // Ler 10 arquivos
        public void LerDez()
        {
            List<Gerentes> listadegerentes = DeserializarObjetosOutput();
            {
                for(int i = 0; i < 10; i++)
                {
                    Gerentes gerentes = listadegerentes[i];
                }
            }
        }

        // Ler por Id
        public void LerId(Guid id)
        {
            List<Gerentes> listadegerentes = DeserializarObjetosOutput();
            {
                foreach (Gerentes g in listadegerentes)
                {
                    if (g.Id == id)
                    {
                        return;
                    }
                }
            }
        }
    }
}
