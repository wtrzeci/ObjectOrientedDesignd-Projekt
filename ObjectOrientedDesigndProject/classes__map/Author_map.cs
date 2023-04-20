using ObjectOrientedDesigndProject.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes__map
{
    public class Author_map
    {
        public int index;
        public Dictionary<string, string> data;
        private static int numOfAuthors=0;
        public Author_map(string name, string surname, string birthYear, string awards)
        {
            data = new Dictionary<string, string>();
            data["name"] = name;
            data["surname"] = surname;
            data["birthYear"] = birthYear;
            data["awards"] = awards;
            index = numOfAuthors++;
        }
        public static implicit operator Author(Author_map author_Map)
        {
            return Bitflix.ReadAuthorFromTxtClass(Bitflix.ReadAuthor_txtFromMapClass(author_Map));
        }
    }
}
