using ObjectOrientedDesigndProject.classes;
using ObjectOrientedDesigndProject.classes_Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes_txt
{
    public class Series_txt : InterfaceBasse
    {
        public string title {  get; set; }
        public string genere { get; set; }
        public int showrunnerId { get; set; }
        public List<int> episodesId { get; set; }

        public Series_txt() 
        {
            episodesId = new List<int>();
        }
        public int SeriesId { get; set; }

        public Dictionary<string, object> Properties()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"title",title},
               {"genere",genere},
                {"showrunnerId",showrunnerId},
                {"episodesId",episodesId }
            };
            return properties;
        }
        public void SetValuesWithList(List<string> values,Bitflix bitflix)
        {
            title = values[0];
            genere = values[1];
            showrunnerId = int.Parse(values[2]);
            string [] temp = values[3].Split(' ');
            foreach(string s in temp)
            {
                episodesId.Add(int.Parse(s));
            }
        }
        public Series ChangeToBase (Series_txt series)
        {
            return Bitflix.instance.ReadSeriesFromTxtClass(series);
        }
    }
}
