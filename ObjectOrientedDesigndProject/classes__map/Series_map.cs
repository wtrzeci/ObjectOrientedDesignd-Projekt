using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes__map
{
    internal class Series_map
    {
        public int index;
        public Dictionary<string, string> map;
        public Series_map(string title, string genere, string showrunnerId, List<string> episodesId) 
        {
            map = new Dictionary<string, string>();
            map["title"] = title;
            map["genere"] = genere;
            map["showrunnerId"] = showrunnerId;
            foreach(var num in episodesId)
            {
                if (map.ContainsKey("episode"))
                map["episode"] += " "+ num;
                else
                    map["episode"] = num;
            }
        }
    }
}
