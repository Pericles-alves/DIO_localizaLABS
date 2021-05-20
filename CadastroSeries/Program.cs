using System;
using CadastroSeries.Classes;
using CadastroSeries.Enum;

namespace CadastroSeries
{
    class Program
    {
        static Serie_repo repo_s = new Serie_repo();
        static Filmes_repo repo_f = new Filmes_repo();
        static void Main(string[] args)
        {
            Console.Clear();
            string comando1 = comando_usuario_menu();
            string comando2 = comando_usuario(comando1);

             while (comando1 != "E")
            {
                while(comando2 != "E")
                {
                    switch (comando2)
                    {
                        case "1":
                            Console.Clear();
                            listar(comando1);
                            Console.Clear();
                        break;

                        case "2":
                            Console.Clear();
                            inserir(comando1);
                            Console.Clear();
                        break;

                        case "3":
                            Console.Clear();
                            Excluir(comando1);
                            Console.Clear();
                        break;

                        case "4":
                            Console.Clear();
                            Visualizar(comando1);
                            Console.Clear();
                        break;

                        case "5":
                            Console.Clear();
                            Atualizar(comando1);
                            Console.Clear();
                        break;

                        default:
                        throw new ArgumentOutOfRangeException();
                    }
                    comando2 = comando_usuario(comando1);
                }
                Console.Clear();
                comando1 = comando_usuario_menu();
                comando2 = comando_usuario(comando1);
            }

        }

        private static void Atualizar(string comando1)
        {
            if(lista_vazia(comando1)) {return;}

            int ID;

            if(comando1 =="1")
            {
                Console.WriteLine("ATUALIZAR SÉRIE");
                Console.WriteLine();
                Console.WriteLine("Digite o ID da série: ");
                ID = int.Parse(Console.ReadLine().ToUpper());

                Console.WriteLine("Insira as informações atuais");
                Console.WriteLine();                
                Series serie = gerar_serie(ID);
                repo_s.Atualiza(ID,serie);
                
                retorno_menu();
                return;
            }

            if(comando1 =="2")
            {
                Console.WriteLine("ATUALIZAR FILME");
                Console.WriteLine();
                Console.WriteLine("Digite o ID do filme: ");
                ID = int.Parse(Console.ReadLine().ToUpper());

                Console.WriteLine("Insira as informações atuais");
                Console.WriteLine();                
                Filmes filme = gerar_filme(ID);
                repo_f.Atualiza(ID,filme);
                
                retorno_menu();
                return;
            }
        }

        private static void retorno_menu()
        {
            Console.WriteLine();
            Console.WriteLine("Operação Concluida!");
            Console.WriteLine("Pressione ENTER voltar ao menu!"); 
            Console.ReadLine();
        }

        private static void Visualizar(string comando1)
        {
            if(lista_vazia(comando1)) {return;}
            int ID;

            if (comando1=="1")
            {
                Console.WriteLine("VIZUALIZAR SÉRIE");
                Console.WriteLine();
                Console.WriteLine("Digite o ID da série: ");
                ID = int.Parse(Console.ReadLine().ToUpper());
                Console.WriteLine();
                var serie = repo_s.RetornaPorId(ID);    
                Console.WriteLine(serie);
                retorno_menu();
                return;
            }
            if (comando1=="2")
            {
                Console.WriteLine("VIZUALIZAR FILME");
                Console.WriteLine();
                Console.WriteLine("Digite o ID do filme: ");
                Console.WriteLine();
                ID = int.Parse(Console.ReadLine().ToUpper());
                var filme = repo_f.RetornaPorId(ID);    
                Console.WriteLine(filme);
                retorno_menu();
                return;
            }
        }

        private static void Excluir(string comando1)
        {
            if(lista_vazia(comando1)) {return;}
               int ID;

            if (comando1=="1")
            {
                Console.WriteLine("EXCLUIR SÉRIE");
                Console.WriteLine();
                Console.WriteLine("Digite o ID da série: ");
                ID = int.Parse(Console.ReadLine().ToUpper());
                repo_s.Exclui(ID);
                retorno_menu();
                return;
            }
            if (comando1=="2")
            {
                Console.WriteLine("EXCLUIR FILME");
                Console.WriteLine();
                Console.WriteLine("Digite o ID do filme: ");
                ID = int.Parse(Console.ReadLine().ToUpper());
                repo_f.Exclui(ID);
                retorno_menu();
                return;
            }
        }

        private static void inserir(string comando1)
        {
        
            if(comando1=="1")
            {
                Console.WriteLine("INSERIR NOVA SÉRIE:");
                Console.WriteLine();
                Series novaSerie = gerar_serie(repo_s.ProximoId());

                repo_s.Insere(novaSerie);
                retorno_menu();
                return;
            }

            if (comando1=="2")
            {
                Console.WriteLine("INSERIR NOVO FILME:");
                Console.WriteLine();
                Filmes novoFilme = gerar_filme(repo_f.ProximoId());

                repo_f.Insere(novoFilme);
                retorno_menu();
                return;
            }


        }

        private static Filmes gerar_filme(int id)
        {
            foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.Genero.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filmes novoFilme = new Filmes(id: id,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            return novoFilme;
        }

        private static Series gerar_serie(int id)
        {
            foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.Genero.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();
            
            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();
            
            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: id,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            return novaSerie;
        }

        private static void listar(string comando1)
        {
            if(lista_vazia(comando1)) {return;}

            var lista1 = repo_s.Lista();
            var lista2 = repo_f.Lista();

            if(comando1=="1")
            {
                Console.WriteLine("LISTA DE SÉRIES:");
                Console.WriteLine();

                foreach(var series in lista1)
                {
                    var Excluido = series.r_excluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", series.r_id(), series.r_titulo(), (Excluido ? "*Excluída*" : ""));
                }
                retorno_menu();
                return;
            }

            if(comando1=="2")
            {
                Console.WriteLine("LISTA DE FILMES:");
                Console.WriteLine();

                foreach(var filmes in lista2)
                {
                    var Excluido = filmes.r_excluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", filmes.r_id(), filmes.r_titulo(), (Excluido ? "*Excluído*" : ""));
                }
                retorno_menu();
                return;
            }
            
        }

        private static bool lista_vazia(string comando1)
        {           
            if(comando1=="1")
            {
                var lista1 = repo_s.Lista();
                if(lista1.Count==0)
                {
                    Console.WriteLine("Nenhuma série cadastrada!!!");
                    retorno_menu();
                    return true;
                }
                else return false;
            }

            if(comando1=="2")
            {
                var lista2 = repo_f.Lista();
                if(lista2.Count==0)
                {
                    Console.WriteLine("Nenhum filme cadastrado!!!");
                    retorno_menu();
                    return true;
                }
                else return false;
            }

            return false;
            
        }

        private static string comando_usuario(string comando1)
        {
            string comando2="";
            if(comando1=="1")
            {
                Console.WriteLine("Bem vindo ao menu da DIO SÉRIES");
                Console.WriteLine("Insira o valor correspondente a opção desejada:");
                Console.WriteLine(" 1- Listar séries.");
                Console.WriteLine(" 2- Inserir nova série.");
                Console.WriteLine(" 3- Excluir série.");
                Console.WriteLine(" 4- Visualizar série.");
                Console.WriteLine(" 5- Atualizar série.");
                Console.WriteLine(" E- Retornar ao menu inicial.");
                Console.WriteLine();
                comando2 = Console.ReadLine().ToUpper();
            }

            if(comando1=="2")
            {
                Console.WriteLine("Bem vindo ao menu da DIO FILMES");
                Console.WriteLine("Insira o valor correspondente a opção desejada:");
                Console.WriteLine(" 1- Listar filmes.");
                Console.WriteLine(" 2- Inserir novo filme.");
                Console.WriteLine(" 3- Excluir filme.");
                Console.WriteLine(" 4- Visualizar filme.");
                Console.WriteLine(" 5- Atualizar filme.");
                Console.WriteLine(" E- Retornar ao menu inicial.");
                Console.WriteLine();
                comando2 = Console.ReadLine().ToUpper();
            }
            return comando2;
        }

        private static string comando_usuario_menu()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo a DIO Filmes e Séries");
            Console.WriteLine("Insira o valor correspondente a opção desejada:");

            Console.WriteLine(" 1- Menu de Séries.");
            Console.WriteLine(" 2- Menu de Filmes.");
            Console.WriteLine(" E- Encerrar operaçoes.");
            Console.WriteLine();

            string comando1 = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.Clear();
            return comando1;
        }
    }
}
