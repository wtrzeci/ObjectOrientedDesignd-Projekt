using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes
{
    internal class Movie
    {
        public string name { get; set; }
        public string genere { get; set; }

        public int releaseYear { get; set; }
        public int duration { get; set; }

        public Author? director { get; set; }

        public override string ToString()
        {
            return "Movie" + name + " of genere: " + genere + " duration: " + duration + " directed by " + director;
        }
    }
}
