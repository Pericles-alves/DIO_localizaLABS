using System;
using System.Collections.Generic;
using InterfaceBancaria.conta;
using InterfaceBancaria.Enum;



namespace InterfaceBancaria
{
    class Program
    {
        static List<contas_B> lista_contas = new List<contas_B>();
        static void Main(string[] args)
        {
            string comando = comando_usuario();
            while (comando != "E")
            {
                switch (comando)
                {
                    case "1":
                        listar_contas();
                    break;
                    
                    case "2":
                        criar_conta();
                    break;

                    case "3":
                        sacar();
                    break;

                    case "4":
                        depositar();
                    break;

                    case "5":
                        transferencia();
                    break;

                    //case "L":
                    //Console.Clear();
                    //break; 

                    default:
                    throw new ArgumentOutOfRangeException();
                }
                comando = comando_usuario();
            }
            Console.WriteLine("Obrigado por escolher o Banco DIO!");
            Console.ReadLine();
        }

         private static void transferencia()
        {
             if(lista_contas.Count == 0 || lista_contas.Count<2)
            {
                Console.WriteLine("Não é possível realizar Transferência: número de contas cadastradas insuficiente!!!");
                limpa_menu();
                return;
            }
            Console.WriteLine("Digite o número da conta de origem!");
            int conta1 = int.Parse(Console.ReadLine());
            while(conta1+1 > lista_contas.Count )
            {
                Console.WriteLine();
                Console.WriteLine("Número de conta inválido ou não cadastrado!!!");
                Console.WriteLine();
                Console.WriteLine("Digite a conta de qual o montante será transferido");
            }

            Console.WriteLine("Digite o número da conta de destino");
            int conta2 = int.Parse(Console.ReadLine());
            while(conta2+1 > lista_contas.Count || conta1==conta2)
            {
                Console.WriteLine();
                Console.WriteLine("Número de conta inválido ou não cadastrado!!!");
                Console.WriteLine();
                Console.WriteLine("Digite o número da conta de destino");
            }

            Console.WriteLine("Informe o valor da transferência");
            double valor_transferencia = double.Parse(Console.ReadLine());
            if(lista_contas[conta1].sacar(valor_transferencia))
            {
                lista_contas[conta2].depositar(valor_transferencia);
            }
            limpa_menu();
        }

        private static void depositar()
        {
            if(lista_contas.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Não há contas cadastradas!!!");
                limpa_menu();
                return;
            }

            Console.WriteLine("Digite o número da conta para qual deseja depositar: ");
            int n_conta = int.Parse(Console.ReadLine());
            
            if(n_conta+1 > lista_contas.Count || n_conta <0)
            {
                Console.WriteLine();
                Console.WriteLine("Número de conta inválido ou não cadastrado!!!");
                limpa_menu();
                return;
            }

            Console.WriteLine("Digite o valor do deposito: ");
            double valor = double.Parse(Console.ReadLine());
            lista_contas[n_conta].depositar(valor);
            limpa_menu();
            //throw new NotImplementedException();
        }

        private static void sacar()
        {
            if(lista_contas.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas!!!");
                limpa_menu();
                return;
            }
            Console.WriteLine("Digite o número da conta da qual deseja sacar: ");
            int n_conta = int.Parse(Console.ReadLine());

            if(n_conta > lista_contas.Count || n_conta <0)
            {
                Console.WriteLine("Número de conta inválido ou não cadastrado!!!");
                limpa_menu();
                return;
            }
            Console.WriteLine("Digite o Valor do saque: ");
            double valor = double.Parse(Console.ReadLine());
            lista_contas[n_conta].sacar(valor);

            //throw new NotImplementedException();
            limpa_menu();
        }

        private static void limpa_menu()
        {
                Console.WriteLine("");
                Console.WriteLine("Pressione ENTER para retornar ao menu inicial");
                Console.ReadLine();
                Console.Clear();
        }

        private static void listar_contas()
        {
            if(lista_contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta foi cadastrada!!!");
                limpa_menu();
                return;
            }
            else
            {
                Console.WriteLine("Lista de contas cadastradas: ");
                for (int i = 0; i < lista_contas.Count; i++)
                {
                    Console.Write("{0} -", i);
                    Console.WriteLine(lista_contas[i]);
                }
            }
                limpa_menu();
        }

        private static void criar_conta()
        {
            Console.WriteLine("Inserir nova conta");
            
            Console.WriteLine("Informe o tipo da conta:");
            Console.WriteLine("1 - Pessoa física ");
            Console.WriteLine("2 - Pessoa jurídica");
            Console.WriteLine();
            int tipodeconta = int.Parse(Console.ReadLine());
            while (tipodeconta!=1 && tipodeconta!=2)
            {   
                Console.WriteLine("Este tipo de conta não existe!!!");
                Console.WriteLine("Digite 1 para PESSOA FÍSICA OU 2 para PESSOA JURÍDICA");
                tipodeconta = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();

            Console.WriteLine("Informe o nome do Cliente");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe o saldo inicial");
            double saldo = double.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Informe o crédito inicial");
            double credito = double.Parse(Console.ReadLine());
            while (credito<0)

            Console.WriteLine();

            contas_B novaconta = new contas_B(Tipoconta: (Tipo_conta)tipodeconta,
                                              Saldo: saldo, 
                                              Nome: nome,
                                              credito: credito);

            lista_contas.Add(novaconta); 
            //throw new NotImplementedException();
            limpa_menu();
        }

        private static string comando_usuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao banco DIO!");
            Console.WriteLine("Insira o valor correspondente a opção desejada:");

            Console.WriteLine(" 1- Listar contas cadastradas.");
            Console.WriteLine(" 2- Criar nova conta.");
            Console.WriteLine(" 3- Sacar.");
            Console.WriteLine(" 4- Depositar.");
            Console.WriteLine(" 5- Transferência.");
            //Console.WriteLine(" L- Limpar tela.");
            Console.WriteLine(" E- Encerrar operaçoes.");
            Console.WriteLine();

            string comando = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return comando;
        }
    }
}
