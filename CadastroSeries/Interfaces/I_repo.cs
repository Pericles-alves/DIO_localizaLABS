using System.Collections.Generic;
namespace CadastroSeries.Interfaces
{
    public interface I_repo<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);        
        void Insere(T entidade);        
        void Exclui(int id);        
        void Atualiza(int id, T entidade);
        int ProximoId();
         
    }
}