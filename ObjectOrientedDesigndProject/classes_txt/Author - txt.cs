using ObjectOrientedDesigndProject.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes_txt
{
    public class Author_txt
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int birthYear { get; set; }
        public int awards { get; set; }
        
        public int authorIndex { get;set; }
        public static implicit operator Author (Author_txt authorTxt)
        {
            return Bitflix.ReadAuthorFromTxtClass(authorTxt);
        }
    }
}
