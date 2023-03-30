using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes__map
{
    internal class Movie_map
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
    }
}
