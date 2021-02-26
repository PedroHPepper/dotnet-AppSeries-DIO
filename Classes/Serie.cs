using System;
using System.Collections.Generic;
using System.Text;

namespace Series.Classes
{
    public class Serie : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        private bool Excluded { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            Id = id;
            Genre = genre;
            Title = title;
            Description = description;
            Year = year;
            Excluded = false;
        }

        public override string ToString()
        {
            string returnString = "";
            returnString += "Gênero: " + Genre + Environment.NewLine;
            returnString += "Título: " + Title + Environment.NewLine;
            returnString += "Descrição: " + Description + Environment.NewLine;
            returnString += "Ano: " + Year + Environment.NewLine;
            returnString += "Excluído: " + Excluded;
            return returnString;
        }

        public string returnTitle()
        {
            return Title;
        }
        public int returnId()
        {
            return Id;
        }

        public bool ReturnDeleted()
        {
            return Excluded;
        }

        public void Delete()
        {
            Excluded = true;
        }
    }
}
