using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes__map
{
    internal class Episode_map
    {
        public int index;
        public Dictionary<string, string> data;
        public static int numOfEpisodes = 0;
        public Episode_map(string title,string duration,string releaseYear,string authorId,string episodeId) {
            data = new Dictionary<string, string>();
            data["title"] = title;
            index = numOfEpisodes++;
            data["duration"] = duration;
            data["releaseYear"] = releaseYear;
            data["authorId"] = authorId;
            data["episodeId"] = episodeId;
        }
    }
}
