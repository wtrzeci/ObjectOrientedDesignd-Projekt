using ObjectOrientedDesigndProject.classes;
using ObjectOrientedDesigndProject.classes_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectOrientedDesigndProject.classes__map
{
    public class Author_map : InterfaceBasse
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

        public Dictionary<string, object> Properties()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"name",data["name"] },
               {"surname",data["surname"]},
               {"birthYear",data["birthYear"] },
               {"awards",data["awards"] }
            };
            return properties;
        }
    }
}
