using System;
using System.Collections.Generic;
using DIO.Series.interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public List<Serie> listar(){
            return listaSerie;
        }

        public Serie retornaPorId(int id){
            return listaSerie[id];
        }
        public void insere(Serie obj){
            listaSerie.Add(obj);
        }
        public void excluir(int id){
            listaSerie[id].excluir();
        }
        public void atualizar(int id, Serie obj){
            listaSerie[id] = obj;
        }
        public int proximoId(){
            return listaSerie.Count;
        }
    }
}