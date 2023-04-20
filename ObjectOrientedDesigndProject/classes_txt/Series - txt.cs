using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes_txt
{
    public class Series_txt
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

    }
}
