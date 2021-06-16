using System;
using System.Collections.Generic;

namespace SeriesApp
{
    public class SerieRepositorio : IRepositorio<Serie>
    {

        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaSerie.RemoveAt(id);
        }

        public void Inserir(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoID()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }

}