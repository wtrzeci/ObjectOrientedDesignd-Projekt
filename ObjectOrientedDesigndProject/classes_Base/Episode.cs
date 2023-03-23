using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes
{
    internal class Episode
    {
        public string title { get; set; }
        public int duration { get; set; }

        public int releaseYear { get; set; }   

        public Author author { get; set; }

        public override string ToString()
        {
            return "Episode " + title + " duration: " + duration + " produced by: " + author ;
        }
    }
}
