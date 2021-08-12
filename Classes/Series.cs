using System;

namespace CrudSeries
{
    public class Series : BaseEntity
    {

        private Type Type { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        public bool Deleted { get; set; }

        public Series(int id, Type type, string title, string description, int year)
        {
            Id = id;
            Type = type;
            Title = title;
            Description = description;
            Year = year;
            Deleted = false;
        }

        public override string ToString()
        {
            string seriesString = "";
            seriesString += "Type: " + Type + Environment.NewLine;
            seriesString += "Title: " + Title + Environment.NewLine;
            seriesString += "Description: " + Description + Environment.NewLine;
            seriesString += "Year Started: " + Year + Environment.NewLine;
            seriesString += "Deleted: " + Deleted + Environment.NewLine;

            return seriesString;
        }

        public string returnTitle()
        {
            return Title;
        }

        public int returnId()
        {
            return Id;
        }

        public void Remove()
        {
            this.Deleted = true;
        }
    }
}
