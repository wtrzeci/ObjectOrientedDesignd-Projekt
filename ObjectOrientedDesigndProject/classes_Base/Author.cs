﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes
{
    public class Author
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int birthYear { get; set; }
        public int awards { get; set; }
        public override string ToString()
        {
            return Name + " " + Surname +" born in: " + birthYear +  " Scored " + awards + " awards";
        }

    }
}
