using ObjectOrientedDesigndProject.classes_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes
{
    internal class Episode : InterfaceBasse, ListInnitializable
    {
        public string title { get; set; }
        public int duration { get; set; }

        public int releaseYear { get; set; }   

        public Author author { get; set; }

        public Dictionary<string, object> Properties()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"title",title },
                {"duration", duration },
                {"releaseYear",releaseYear },
                {"author",author }
            };
            return properties;
        }

        public void SetValuesWithList(List<string> values,Bitflix bitflix)
        {
            title = values[0];
            duration = int.Parse(values[1]);
            releaseYear = int.Parse(values[2]);
            foreach (var item in bitflix.data_main.authors)
            {
                if (item.Surname == values[3])
                {
                    author = item;
                    break;
                }
            }
        }

        public override string ToString()
        {
            return "Episode " + title + " duration: " + duration + " produced by: " + author ;
        }
    }
}
