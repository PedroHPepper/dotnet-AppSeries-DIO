using Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Series.Classes
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> SeriesList = new List<Serie>();
        public void Delete(int Id)
        {
            SeriesList[Id].Delete();
        }

        public void Insert(Serie entity)
        {
            SeriesList.Add(entity);
        }

        public List<Serie> List()
        {
            return SeriesList;
        }

        public int NextId()
        {
            return SeriesList.Count();
        }

        public Serie ReturnById(int Id)
        {
            return SeriesList[Id];
        }

        public void Update(int Id, Serie entity)
        {
            SeriesList[Id] = entity;
        }
    }
}
