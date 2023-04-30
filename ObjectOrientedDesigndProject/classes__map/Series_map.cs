using ObjectOrientedDesigndProject.classes_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes__map
{
    public class Series_map : InterfaceBasse
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
        public Dictionary<string, object> Properties()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"title",map["title"] },
                {"genere", map["genere"] },
                {"showrunnerId",map["showrunnerId"] },
                {"episode",map["episode"] }
            };
            return properties;
        }
    }
}
