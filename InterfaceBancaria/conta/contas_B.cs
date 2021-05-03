
using InterfaceBancaria.Enum;
using System;

namespace InterfaceBancaria.conta
{
    public class contas_B
    {
    public string Nome{ get; set; }
    public Tipo_conta TipoConta { get; set; }
    public double Saldo { get; set; }
    public double credito { get; set; }        
    

        public contas_B(Tipo_conta Tipoconta, double Saldo, double credito, string Nome)
        {
            this.TipoConta = Tipoconta;
            this.Nome = Nome;
            this.credito = credito;
            this.Saldo = Saldo;

        }

        public bool sacar(double valor_saque)
        {
            Console.WriteLine();
            if((this.Saldo + this.credito) - valor_saque < 0)
            { 
                Console.WriteLine(" Saldo Insuficiente!");
                return false;
            }
                this.Saldo -= valor_saque;
                if (this.Saldo < 0) {this.credito -= this.Saldo;}
                Console.WriteLine(" O saldo atual da conta {0} é {1}, e o crédito disponível é {2}"
                , this.Nome, this.Saldo, this.credito);
                return true;
        }
        public void depositar(double valor_deposito)
        {
            this.Saldo += valor_deposito;
            //Console.WriteLine(" O saldo atual da conta {0} é {1}, e o crédito disponível é {2}"
            //, this.Nome, this.Saldo, this.credito);
        }

        public void transferencia(double valor_transferencia, contas_B conta_destino)
        {
            if(this.sacar(valor_transferencia))
            {
                conta_destino.depositar(valor_transferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += " Conta: " + this.TipoConta + "|";
            retorno += " Nome: " + this.Nome + "|";
            retorno += " Saldo: " + this.Saldo + "|";
            retorno += " Crédito: " + this.credito ;
            return retorno;
        }
        
    }
}