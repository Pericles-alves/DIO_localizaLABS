using CadastroSeries.Interfaces;
using System.Collections.Generic;

namespace CadastroSeries.Classes
{
    public class Serie_repo : I_repo<Series>
    {
        private List<Series> lista_Series = new List<Series>();
        public void Atualiza(int id, Series entidade)
        {
            lista_Series[id] = entidade;
        }

        public void Exclui(int id)
        {
            lista_Series[id].Excluir();
        }

        public void Insere(Series entidade)
        {
            lista_Series.Add(entidade);
        }

        public List<Series> Lista()
        {
            return lista_Series;
        }

        public int ProximoId()
        {
            return lista_Series.Count;
        }

        public Series RetornaPorId(int id)
        {
            return lista_Series[id];
        }
    }
}