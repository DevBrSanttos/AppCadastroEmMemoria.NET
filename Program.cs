using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();

        public static void Main(string[] args){

            string opcaoUsuario = obterOpcaoUsuario();
            while(opcaoUsuario != "X"){
                switch(opcaoUsuario){
                    case "1":
                        listarSeries();
                        break;
                    case "2":
                        inserirSerie();
                        break;
                    case "3":
                        atualizarSerie();
                        break;
                    case "4":
                        excluir();
                        break;
                    case "5":
                        visualizarSerie();
                        break;
                    case "C":
                        //Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                    
                }
                opcaoUsuario = obterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();

        }

      private static void listarSeries(){
            Console.WriteLine("Listar series");
            var lista = serieRepositorio.listar();
            if(lista.Count == 0){
                Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }

            foreach(Serie serie in lista){
                
                Console.WriteLine("#ID: {0}: - {1} - {2} ", serie.retornaID(), serie.retornaTitulo(), (serie.retornaExcluido() ? "Excluido" : ""));
            }

        }

        private static void inserirSerie(){
            Console.WriteLine("Inserir nova serie");

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i,  Enum.GetName(typeof(Genero), i));
            }
            
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int numGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento da série: ");
            int ano = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite a Descrição da série: ");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: serieRepositorio.proximoId(),
                                        genero: (Genero)numGenero,
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);
            
            serieRepositorio.insere(novaSerie);


        }

        private static void atualizarSerie(){
            Console.WriteLine("Qual Id você deseja atualizar");
            int id = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i,  Enum.GetName(typeof(Genero), i));
            }
            
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int numGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento da série: ");
            int ano = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite a Descrição da série: ");
            string descricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: id,
                                        genero: (Genero)numGenero,
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);
            
            serieRepositorio.atualizar(id, atualizarSerie);


        }

        private static void excluir(){
            Console.WriteLine("Qual id deseja excluir?");
            int id = int.Parse(Console.ReadLine());
            serieRepositorio.excluir(id);
        }
    
        public static void visualizarSerie(){
            Console.WriteLine("Qual serie deseja verificar? digite o Id");
            int id = int.Parse(Console.ReadLine());

            var serie = serieRepositorio.retornaPorId(id);

            Console.WriteLine(serie);
        }
        
        public static void clear(){

        }
        private static string obterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            
            Console.WriteLine();
            string opcao = Console.ReadLine().ToUpper();
            return opcao;
        }
    
    
    }
}
