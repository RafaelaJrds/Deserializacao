using Marketplace.Gerente.Application;
using Marketplace.Gerente.Domain;
using Marketplace.Gerente.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Marketplace.Gerente.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Injeção de dependência
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IGerenteService, GerenteService>()
                .AddSingleton<IGerenteRepository, GerenteRepository>()
                .BuildServiceProvider();

            var _gerenteService = serviceProvider.GetService<IGerenteService>();
            //Método Create
            _gerenteService.Create();

            //Método Update 
            Guid updateId = Guid.Empty;
            String updateNome = null;
            Decimal updateSalario = 0;
            Decimal updateComissao = 0;

            SolicitarParametrosUpdate(ref updateId, ref updateNome, ref updateSalario, ref updateComissao);



            _gerenteService.Up(updateId, updateNome, updateSalario, updateComissao);
            //_gerenteService.Create();


            // Deletar
            Guid deleteId = Guid.Empty;

            SolicitarParametrosDelete(ref deleteId);

            _gerenteService.Del(deleteId);

            // LerDezGerentes
            _gerenteService.LerDezGerentes();

            //LerPorId
            Guid lerId = Guid.Empty;
            SolicitarParametrosLerId(ref lerId);
            _gerenteService.LerGerenteId(lerId);
        }
        public static void SolicitarParametrosUpdate(ref Guid id, ref string nome, ref decimal salario, ref decimal comissao)
        {
            System.Console.WriteLine("Insira o Id do gerente que deseja realizar a atualização");
            id = Guid.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Insira o novo nome, novo salário e nova comissão do gerente que deseja realizar a atualização");
            nome = System.Console.ReadLine();
            salario = Decimal.Parse(System.Console.ReadLine());
            comissao = Decimal.Parse(System.Console.ReadLine());
        }
        public static void SolicitarParametrosDelete(ref Guid id)
        {
            System.Console.WriteLine("Insira o Id do gerente que deseja deletar");
            id = Guid.Parse(System.Console.ReadLine());
        }
        public static void SolicitarParametrosLerId(ref Guid id)
        {
            System.Console.WriteLine("Insira o Id do gerente que deseja ver as informações");
            id = Guid.Parse(System.Console.ReadLine());
            System.Console.WriteLine();
        }
    }

}

