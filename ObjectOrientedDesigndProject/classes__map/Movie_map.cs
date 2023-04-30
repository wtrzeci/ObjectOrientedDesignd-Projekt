using ObjectOrientedDesigndProject.classes_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectOrientedDesigndProject.classes__map
{
    internal class Movie_map : InterfaceBasse
    {
        public int index;
        public Dictionary<string,string> map;
        public Movie_map(string title , string genere, string directorId , string duration, string releaseYear )
        {
            map = new Dictionary<string,string>();
            map["title"] = title;
            map["genere"] = genere;
            map["releaseYear"] = releaseYear;
            map["duration"] = duration;
            map["directorId"] = directorId;
        }

        public Dictionary<string, object> Properties()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"title",map["title"] },
                {"duration", map["duration"] },
                {"releaseYear",map["releaseYear"] },
                {"genere",map["genere"] },
                {"directorId",map["directorId"] }
            };
            return properties;
        }
    }
}
