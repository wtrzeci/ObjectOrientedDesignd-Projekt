using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes
{
    internal class Series
    {
        public string title {  get; set; }
        public string genere { get; set; }
        public Author showrunner { get; set; }
        public List<Episode> episodes { get; set; }

        public override string ToString()
        {
            string final;
            final = "Series " + title + " of genere " + genere + "run by: " + showrunner + " with episodes:";
            foreach (var episode in episodes)
            {
                final += episode.ToString();
            }
            return final;
        }

    }
}
