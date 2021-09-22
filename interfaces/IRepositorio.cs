using System.Collections.Generic;

namespace DIO.Series.interfaces
{
    public interface IRepositorio<T>{
         
        List<T> listar();
        T retornaPorId(int id);
        void insere(T obj);
        void excluir(int id);
        void atualizar(int id, T obj);
        int proximoId();
    }
}