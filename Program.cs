using System;

namespace SeriesApp
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcao = ObterOpcaoUsuario();

            while (opcao!="7")
            {
                switch (opcao)
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
                        DetalharSerie();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcao = ObterOpcaoUsuario();
            }

            Console.WriteLine("Volte sempre");
            Console.ReadLine();
        }

        public static void ListarSeries()
        {
            Console.WriteLine("Lista de Séries");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nada para mostrar");
                return;
            }

            foreach(var serie in lista)
            {
                Console.WriteLine("{0}: {1}", serie.getId(), serie.getTitulo());
            }
        }

        public static void InserirSerie()
        {
            Console.WriteLine("Selecione Gênero:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero),i));
            }
            int opcaoGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Titulo:");
            string entTitulo = Console.ReadLine();
            Console.WriteLine("Ano:");
            int entAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Descricao:");
            string entDescricao = Console.ReadLine();

            Serie nova = new Serie(id: repositorio.ProximoID(),
                                   genero: (Genero)opcaoGenero,
                                   titulo: entTitulo,
                                   descricao: entDescricao,
                                   ano: entAno);
            repositorio.Inserir(nova);
        }

        public static void AtualizarSerie()
        {
            Console.WriteLine("ID da série:");
            int indice = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Selecione Gênero:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            int opcaoGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Titulo:");
            string entTitulo = Console.ReadLine();
            Console.WriteLine("Ano:");
            int entAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Descricao:");
            string entDescricao = Console.ReadLine();

            Serie nova = new Serie(id: indice,
                                   genero: (Genero)opcaoGenero,
                                   titulo: entTitulo,
                                   descricao: entDescricao,
                                   ano: entAno);
            repositorio.Atualiza(indice, nova);
        }

        public static void ExcluirSerie()
        {
            Console.WriteLine("ID da série:");
            int indice = int.Parse(Console.ReadLine());

            repositorio.Excluir(indice);
        }

        public static void DetalharSerie()
        {
            Console.WriteLine("ID da série:");
            int indice = int.Parse(Console.ReadLine());

            Console.WriteLine(repositorio.RetornaPorId(indice).ToString());
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Locadora retrô");
            Console.WriteLine("Selecione uma opção");
            Console.WriteLine("1 - lista de séries");
            Console.WriteLine("2 - Nova Série");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Excluir");
            Console.WriteLine("5 - Ver detalhes");
            Console.WriteLine("6 - Limpar tela");
            Console.WriteLine("7 - Sair");

            String opcao = Console.ReadLine();
            return opcao;
        }
    }
}
