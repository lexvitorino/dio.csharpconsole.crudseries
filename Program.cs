using System;

namespace MI7Dev.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite o id da série: ");
            Console.WriteLine("---------------------------------");

            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            if (serie == null)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Série não encontrada");
                Console.WriteLine("---------------------------------");
                return;
            }

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite o id da série: ");
            Console.WriteLine("---------------------------------");

            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            if (serie == null)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Série não encontrada");
                Console.WriteLine("---------------------------------");
                return;
            }

            Console.WriteLine(serie);
            Console.WriteLine("---------------------------------");
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite o id da série: ");
            Console.WriteLine("---------------------------------");

            int indiceSerie = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine();
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("---------------------------------");

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Listar séries");
            Console.WriteLine("---------------------------------");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                Console.WriteLine("---------------------------------");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }

            Console.WriteLine("---------------------------------");
        }

        private static void InserirSerie()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Inserir nova série");
            Console.WriteLine("---------------------------------");


            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("---------------------------------");
            Console.Write("Digite o gênero entre as opções acima: ");

            int entradaGenero = 0;
            
			try
            {
                entradaGenero = int.Parse(Console.ReadLine());
            }
            catch (System.Exception)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Inválido, tente novamente!");
                Console.WriteLine("---------------------------------");
                return;
            }

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            
			int entradaAno = 0;
            
			try
            {
                entradaAno = int.Parse(Console.ReadLine());
            }
            catch (System.Exception)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Inválido, tente novamente!");
                Console.WriteLine("---------------------------------");
                return;
            }

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine("---------------------------------");

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("MI7Dev Séries e Filmes!");
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("X- Sair");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
