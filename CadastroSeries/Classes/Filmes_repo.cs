using CadastroSeries.Interfaces;
using System.Collections.Generic;


namespace CadastroSeries.Classes
{
    public class Filmes_repo : I_repo<Filmes>
    {
        private List<Filmes> lista_Filmes = new List<Filmes>();
        public void Atualiza(int id, Filmes entidade)
        {
           lista_Filmes[id] = entidade;
        }

        public void Exclui(int id)
        {
            lista_Filmes[id].Excluir();
        }

        public void Insere(Filmes entidade)
        {
            lista_Filmes.Add(entidade);
        }

        public List<Filmes> Lista()
        {
            return lista_Filmes;
        }

        public int ProximoId()
        {
            return lista_Filmes.Count;
        }

        public Filmes RetornaPorId(int id)
        {
            return lista_Filmes[id];
        }
    }
}