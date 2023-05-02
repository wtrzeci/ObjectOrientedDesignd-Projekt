using ObjectOrientedDesigndProject.classes;
using ObjectOrientedDesigndProject.classes_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes_txt
{
    public class Author_txt : InterfaceBasse, ListInnitializable
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int birthYear { get; set; }
        public int awards { get; set; }
        
        public int authorIndex { get;set; }

        public Dictionary<string, object> Properties()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"name",Name },
               {"surname",Surname},
               {"birthYear",birthYear },
               {"awards",awards }
            };
            return properties;
        }
        public void SetValuesWithList(List<string> values)
        {
            Name = values[0];
            Surname = values[1];
            birthYear = int.Parse(values[2]);
            awards = int.Parse(values[3]);
            authorIndex = int.Parse(values[4]);
        }

        public void SetValuesWithList(List<string> values, Bitflix bitflix)
        {
            Name = values[0];
            Surname = values[1];
            birthYear = int.Parse(values[2]);
            awards = int.Parse(values[3]);
            authorIndex = int.Parse(values[4]);
        }

        public Author ChangeToBase(Author_txt authorTxt)
        {
            return Bitflix.ReadAuthorFromTxtClass(authorTxt);
        }
    }
}
