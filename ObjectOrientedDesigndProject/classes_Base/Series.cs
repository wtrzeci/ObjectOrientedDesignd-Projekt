using ObjectOrientedDesigndProject.classes_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes
{
    internal class Series : InterfaceBasse, ListInnitializable
    {
        public string title {  get; set; }
        public string genere { get; set; }
        public Author showrunner { get; set; }
        public List<Episode> episodes = new List<Episode>();
        public Dictionary<string, object> Properties()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"title",title },
                {"showrunner", showrunner},
                {"episodes",episodes},
                {"genere",genere}
            };
            return properties;
        }

        public void SetValuesWithList(List<string> values, Bitflix bitflix)
        {
            title = values[0];
            genere = values[3];
            foreach(var s in bitflix.data_main.authors)
            {
                if (s.Name == values[1])
                {
                    showrunner = s;
                    break;
                }
            }
            string[] temp = values[2].Split(' ');
            foreach (var s in bitflix.data_main.episodes)
            {
                foreach (var t in temp)
                {
                    if (t == s.title)
                    {
                        episodes.Add(s);
                    }
                }
            }
        }

        public override string ToString()
        {
            string final;
            final = "Series " + title + " of genere " + genere + " run by: " + showrunner + " with episodes:";
            foreach (var episode in episodes)
            {
                final += episode.ToString();
            }
            return final;
        }

    }
}
