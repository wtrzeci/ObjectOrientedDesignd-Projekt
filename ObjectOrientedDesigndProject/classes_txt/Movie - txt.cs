using ObjectOrientedDesigndProject.classes;
using ObjectOrientedDesigndProject.classes_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes_txt
{
    public class Movie_txt : InterfaceBasse, ListInnitializable
    {
        public string title { get; set; }
        public string genere { get; set; }

        public int releaseYear { get; set; }
        public int duration { get; set; }

        public int directorId { get; set; }

        public Dictionary<string, object> Properties()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"title",title},
               {"duration",duration},
               {"releaseYear ",releaseYear },
               {"genere",genere},
                {"directorId ",directorId},

            };
            return properties;
        }
        public  void SetValuesWithList(List<string> values,Bitflix bitflix)
        {
            title = values[0];
            duration = int.Parse(values[1]);
            releaseYear = int.Parse(values[2]);
            duration = int.Parse(values[3]);
            directorId = int.Parse(values[4]);
        }
        public Movie ChangeToBase(Movie_txt movie)
        {
            return Bitflix.instance.ReadMovieFromTxtClass(movie);
        }
    }
}
