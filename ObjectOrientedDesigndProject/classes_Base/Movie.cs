using ObjectOrientedDesigndProject.classes_Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes 
{
    internal class Movie : InterfaceBasse, ListInnitializable
    {
        public string name { get; set; }
        public string genere { get; set; }

        public int releaseYear { get; set; }
        public int duration { get; set; }
        public Dictionary<string, object> Properties()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"title",name },
                {"duration", duration },
                {"releaseYear",releaseYear },
                {"genere",genere }
            };
            return properties;
        }

        public Author? director { get; set; }

        public override string ToString()
        {
            return "Movie " + name + " of genere: " + genere + " duration: " + duration + " directed by " + director;
        }

        public void SetValuesWithList(List<string> values, Bitflix bitflix)
        {
            name = values[0];
            duration = int.Parse(values[1]);
            releaseYear = int.Parse(values[2]);
            genere = values[3];
        }
    }
}
