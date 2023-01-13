



using ProjetoAula02.Entities;
using ProjetoAula02.Repositories;

namespace ProjetoAula02
{
    public class Program
    {
        /// <summary>
        /// Método para execução da classe
        /// </summary>
        public static void Main(string[] args)
        {

            Console.WriteLine("\n *** CADASTRO DE FUNCIONÁRIOS *** \n");


            //criando um objeto para funcionário
            var funcionario = new Funcionario();
            funcionario.Funcao = new Funcao();


            try
            {
                funcionario.Id = Guid.NewGuid();
                funcionario.Funcao.Id = Guid.NewGuid();

                Console.Write("Informe o Nome do funcionário...:");
                funcionario.Nome = Console.ReadLine();

                Console.Write("Informe o cpf.....:");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("Informe a matrícula.....:");
                funcionario.matricula = Console.ReadLine();

                Console.Write("Informe a data de admissão.....:");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                Console.Write("INFORME A DESCRIÇÃO DA FUNÇÃO.....: ");
                funcionario.Funcao.Descricao = Console.ReadLine();

                //imprimindo

                Console.WriteLine("\nDados do funcionário:");
                Console.WriteLine($"\tId........:{funcionario.Id}");
                Console.WriteLine($"\tNome........: {funcionario.Nome}");
                Console.WriteLine($"\tCpf........:{funcionario.Cpf}");
                Console.WriteLine($"\tMatrícula.....:{funcionario.matricula}");
                Console.WriteLine($"\tData de Admissão.........:{funcionario.DataAdmissao}");
                Console.WriteLine($"\tId da Função........: {funcionario.Funcao.Id}");
                Console.WriteLine($"\tDescrição.........{funcionario.Funcao.Descricao}");

                Console.Write("\nEscolha (1)JSON ou (2)XML...: ");
                var opcao = int.Parse(Console.ReadLine());

                //criando um objeto para a classe FuncionárioRepository
                var funcionarioRepository = new FuncionarioRepository();

                switch (opcao)
                {
                    case 1:
                        funcionarioRepository.ExportarJson(funcionario);
                        Console.WriteLine("\nArquivo JSON gravado com sucesso!");
                        break;

                    case 2:
                        funcionarioRepository.ExportarXml(funcionario);
                        Console.WriteLine("\nArquivo XML gravado com sucesso!");

                        break;

                    default:
                        Console.WriteLine("\nOpção Inválida!");
                        break;
                }


            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nErro de validação:");
                Console.WriteLine(e.Message);

                Console.Write("\nDeseja Tentar Novamente? (S,N)");

                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))

                {
                    Console.Clear(); //limpar o texto do console
                    Main(args);// Recursividade
                }
                else
                {
                    Console.WriteLine("\nFim!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO EXECUTAR O PROGRAMA:");
                Console.WriteLine(e.Message);

            }

            //agauardar uma tecla para continuar...
            Console.ReadKey();

        }
    }
}

