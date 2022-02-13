using System;

namespace dio.Series
{

    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
         string opcaoUsuario = ObterOpcaoUsuario();
         while(opcaoUsuario.ToUpper() != "X"){   

        switch(opcaoUsuario){ 
            case "1":
            ListaSerie();
            break;
            case "2":
            InserirSerie();
            break;
            case "3":
            AtualizaSerie();
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
        Console.WriteLine("obrigado por utilizar nossos servicos");
        Console.ReadLine();
        }

        public static void ListaSerie()
        {
            Console.WriteLine("listar series");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("nenhuma serie cadastrada");
                return;
            }

            foreach (var serie in lista){
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1}  {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "excluido" : ""));
            }
        }

        public static void InserirSerie()
        {
            Console.WriteLine("inserir nova serie ");

            foreach ( int  i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o genero entre as opçoes acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano:entradaAno,
                                        descricao: entradaDescricao);
                repositorio.Insere(novaSerie);                                        
            }
        
            public static void ExcluirSerie()
            {
                Console.WriteLine("Digite o id da serie");
                int indiceSerie = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceSerie);
            }

            private static void VisualizarSerie()
            {
                Console.Write("digite o id da serie");
                int indiceSerie = int.Parse(Console.ReadLine());
                var serie = repositorio.RetornaPorId(indiceSerie);

                Console.WriteLine(serie);
            }

          public static void AtualizaSerie()
          {
            Console.WriteLine("Digite o id da serie ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach ( int  i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o genero entre as opçoes acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id:indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano:entradaAno,
                                        descricao: entradaDescricao);
                repositorio.Atualiza(indiceSerie,atualizaSerie);                                        
            }



        public static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Dio Series a seu Dispor");
            Console.WriteLine("Informe a  opção desejada");

            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir series");
            Console.WriteLine("3- Atualizar series");
            Console.WriteLine("4- Excluir series");
            Console.WriteLine("5- Visualizar series");
            Console.WriteLine("C- Limpar a sua tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
