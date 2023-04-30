using ObjectOrientedDesigndProject.classes;
using ObjectOrientedDesigndProject.classes_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectOrientedDesigndProject.classes_txt
{
    internal class Episode_txt : InterfaceBasse, ListInnitializable
    {

        public string title { get; set; }
        public int duration { get; set; }

        public int releaseYear { get; set; }   

        public int authorId { get; set; }

        public int episodeId { get; set; }

        public void SetValuesWithList(List<string> values)
        {
            title = values[0];
            duration = int.Parse(values[1]);
            releaseYear = int.Parse(values[2]);
            authorId = int.Parse(values[3]);
            episodeId = int.Parse(values[4]);
        }
        public Dictionary<string, object> Properties()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"title",title},
               {"duration",duration},
               {"releaseYear ",releaseYear },
               {"episodeId",episodeId}
            };
            return properties;
        }

        public void SetValuesWithList(List<string> values, Bitflix bitflix)
        {
            title = values[0];
            duration = int.Parse(values[1]);
            releaseYear = int.Parse(values[2]);
            authorId = int.Parse(values[3]);
            episodeId= int.Parse(values[4]);
        }
    }
}
