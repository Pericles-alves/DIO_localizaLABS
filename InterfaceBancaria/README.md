# InterfaceBancaria

    1º Projeto proposto pelo bootcamp da LocalizaLABS

## Objetivo

    Criar uma aplicação simples que implementa algumas funções de uma interface bancária, sendo elas: Criar conta, Listar contas, Saque, Transferência e Depósito. 
>O intuito do projeto é colocar em prática conceitos de Lógica de Programação, Estrutura de Dados e Programação Orientada a Objetos (POO).

## Classes criadas

>### contas_B.cs
    Classe do tipo pública utilizada que implementa métodos usados para a criação de contas, saque, depósito e transferência. Com override no metodo herdado ToString para retornar informações sobre as contas cadastradas. 

>### Tipo_conta.cs
    Implementa um ENUM público que atrela valor as opções "pessoafisica" e "pessoajuridica"
 

## Métodos Implementados - Conta_B.cs

>### contas_B( ... )
    Método construtor, recebe os atributos da classe e retorna uma instância.
>### sacar(valor_saque)
    Utilizado para efetuar o saque de uma das instâncias da classe. Recebe o valor do saque e retorna uma variável booleana informando se a operação foi ou não efetuada.
>### depositar(valor_deposito)
    Recebe o valor do déposito e atribui a instância da classe.

### transferencia(valor_transferencia, conta_destino)
    Recebe o valor da transferência e uma instância da classe 'conta_destino' e utiliza do método saque para realizar a transferência

## Métodos Implementados - main()

>### comando_usuario()

    Cria o menu para usuário listando as opções númericas e sua descrição. Retorna uma string com o comando do usuário.

>### listar_contas()

    Percorre e imprime o objeto do tipo list que armazena lista de contas criadas. Retorno tipo void - vazio.

>### criar_conta()

    Utiliza do método construtor da classe contas_B para cadastrar uma nova conta.

>### sacar()

    Faz o saque da conta utilizando o método da classe contas_B.

>### depositar()

    Utiliza dos métodos implementados na classe contas_B para depositar o dinheiro em conta

>### transferencia()

    Utiliza dos métodos saque e depósito para movimentar uma quantia entre duas contas.