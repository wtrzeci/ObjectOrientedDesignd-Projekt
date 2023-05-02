using ObjectOrientedDesigndProject.classes;
using ObjectOrientedDesigndProject.classes__map;
using ObjectOrientedDesigndProject.classes_txt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject
{
    public class Bitflix
    {
        public data_from_txt data_From_Txt;
        public data data_main;
        private Dictionary<int,Author_txt>authorDict = new Dictionary<int,Author_txt>();
        private Dictionary<int,Episode_txt>episodeDict = new Dictionary<int,Episode_txt>();
        private Dictionary<int, Author> _mainAuthorDict = new Dictionary<int, Author>();
        private Dictionary<int, Episode>_mainEpisodeDict = new Dictionary<int, Episode>();
        public static Bitflix instance { get; private set; }
        Dictionary<string, Func<object, object, bool>> comparisonOperators = new Dictionary<string, Func<object, object, bool>>()
{
    { "=", (x, y) => x.Equals(y) },
    { "<", (x, y) => Comparer.Default.Compare(x, y) < 0 },
    { ">", (x, y) => Comparer.Default.Compare(x, y) > 0 },
    { "<=", (x, y) => Comparer.Default.Compare(x, y) <= 0 },
    { ">=", (x, y) => Comparer.Default.Compare(x, y) >= 0 },
};

        public Bitflix() 
        {
            data_From_Txt = new data_from_txt();
            data_main = new data();
            instance = this;
        }
        public void LoadDataFromFile(string _path)
        {
            StreamReader sr = new StreamReader(_path);
            string? line;
            line = sr.ReadLine();
            int numOfAuthors = 1;
            int numOfSeries = 1;
            int numOfEpisode = 1;
            while (line != null) 
            {
                if (line.Contains("Movie"))
                {
                    data_From_Txt.movies.Add(Readmovie_txt(line));
                }
                else if (line.Contains("Series"))
                {
                    Series_txt series = ReadSeries_txt(line);
                    series.SeriesId = numOfSeries;
                    numOfSeries++;
                    data_From_Txt.series.Add(series);
                }
                else if (line.Contains("Episode"))
                {
                    Episode_txt episode = ReadEpisodes_txt(line);
                    episode.episodeId = numOfEpisode;//we count the number of episodes :)
                    numOfEpisode++;
                    data_From_Txt.episodes.Add(episode);
                }
                else if (line.Contains("Author"))
                {
                    Author_txt author = ReadAuthor_txt(line);
                    author.authorIndex = numOfAuthors;
                    authorDict.Add(numOfAuthors, author);
                    numOfAuthors++;
                    data_From_Txt.authors.Add(author);
                }
                line = sr.ReadLine();
            }
            
            
        }
        public void LoadDataToProgramFormatFromTxt()
        {
            foreach(var author in data_From_Txt.authors)
            {
                Author temp = ReadAuthorFromTxtClass(author);
                _mainAuthorDict.Add(author.authorIndex, temp);
                data_main.authors.Add(temp);
            }
            foreach (var episode in data_From_Txt.episodes)
            {
                Episode temp = ReadEpisodeFormTxtClass(episode);
                _mainEpisodeDict.Add(episode.episodeId, temp);
                data_main.episodes.Add(temp);
            }

            foreach (var series in data_From_Txt.series)
            {
                Series _series = ReadSeriesFromTxtClass(series);
                foreach(var v in  series.episodesId) 
                {
                    _series.episodes.Add(_mainEpisodeDict[v]);
                }
                data_main.series.Add(_series);
            }
            foreach (var movie in data_From_Txt.movies)
            {
                Movie temp = ReadMovieFromTxtClass(movie);
                data_main.movies.Add(temp);
            }

        }
        internal void LoadDataToTxtFormatFromMap(List<Author_map> authors, List<Episode_map> episodes, List<Movie_map> movies, List<Series_map> series)
        {
            int numOfAuthors = 1;
            int numOfSeries = 1;
            int numOfEpisode = 1;
            foreach (var author in authors)
            {
                Author_txt temp = ReadAuthor_txtFromMapClass(author);
                temp.authorIndex = numOfAuthors;
                authorDict.Add(numOfAuthors, temp);
                numOfAuthors++;
                data_From_Txt.authors.Add(temp);
            }
            foreach ( var episode in episodes)
            {
                Episode_txt temp = ReadEpisode_txtFromMapClass(episode);
                temp.episodeId = numOfEpisode;//we count the number of episodes :)
                episodeDict.Add(numOfEpisode, temp);
                numOfEpisode++;
                data_From_Txt.episodes.Add(temp);
            }
            foreach ( var movie in movies)
            {
                Movie_txt temp = ReadMovie_txtFromMapClass(movie);
                data_From_Txt.movies.Add(temp);
            }
            foreach (var ser in series)
            {
                Series_txt temp = ReadSeries_txtFromMapClass(ser);
                temp.SeriesId = numOfSeries;
                numOfSeries++;
                data_From_Txt.series.Add(temp);
            }
            return;

        }
        #region TranslateFromTxt
        public static Author ReadAuthorFromTxtClass (Author_txt author)
        {
            Author temp = new Author();
            temp.Name = author.Name;
            temp.Surname = author.Surname;
            temp.birthYear = author.birthYear;
            temp.awards = author.awards;
            return temp;
        }
        public  Series ReadSeriesFromTxtClass (Series_txt series)
        {
            Series temp = new Series();
            temp.title=series.title;
            temp.genere =series.genere;
            temp.showrunner = _mainAuthorDict[series.showrunnerId];
            temp.episodes = new List<Episode>();
            return temp;
        }
        public Episode ReadEpisodeFormTxtClass (Episode_txt episode)
        {
            Episode temp = new Episode();
            temp.title = episode.title;
            temp.duration = episode.duration;
            temp.releaseYear = episode.releaseYear;
            temp.author = _mainAuthorDict[episode.authorId];
            return temp;
        }
        public Movie ReadMovieFromTxtClass (Movie_txt movie)
        {
            Movie temp = new Movie();
            temp.genere=movie.genere;
            temp.releaseYear=movie.releaseYear;
            temp.director = _mainAuthorDict[movie.directorId];
            temp.name = movie.title;
            temp.duration = movie.duration;
            return temp;
        }

        public static Author_txt ReadAuthor_txtFromMapClass(Author_map author )
        {
            Author_txt temp = new Author_txt();
            temp.Name = author.data["name"];
            string surname;
            author.data.TryGetValue("surname", out surname);
            temp.Surname = surname;
            temp.authorIndex = author.index;
            string awards;
            author.data.TryGetValue("awards", out awards);
            temp.awards = int.Parse(awards);
            temp.birthYear = int.Parse(author.data["birthYear"]);
            return temp;

        }
        private Episode_txt ReadEpisode_txtFromMapClass (Episode_map episode)
        {
            Episode_txt temp = new Episode_txt();
            temp.title = episode.data["title"];
            temp.authorId = int.Parse(episode.data["authorId"]);
            temp.duration = int.Parse(episode.data["duration"]);
            temp.episodeId = episode.index;
            temp.releaseYear = int.Parse(episode.data["releaseYear"]);
            return temp;

        }
        private Movie_txt ReadMovie_txtFromMapClass (Movie_map movie)
        {
            Movie_txt temp = new Movie_txt();
            temp.title = movie.map["title"];
            temp.genere = movie.map["genere"];
            temp.duration = int.Parse( movie.map["duration"]);
            temp.releaseYear = int.Parse(movie.map["releaseYear"]);
            temp.directorId = int.Parse(movie.map["directorId"]);
            return temp;
        }

        public static Series_txt ReadSeries_txtFromMapClass (Series_map series)
        {
            Series_txt temp = new Series_txt();
            temp.title = series.map["title"];
            temp.genere = series.map["genere"];
            temp.SeriesId = series.index;
            temp.showrunnerId = int.Parse(series.map["showrunnerId"]);
            foreach(var num in series.map.Where(i=>i.Key == "episode"))
            {
                foreach (var item in num.Value.Split(" "))
                {
                    temp.episodesId.Add(int.Parse(item));
                }
            }
            return temp;
        }
        #endregion
        #region TranslateFromBaseToMap


        #endregion
        //parse lines from txt functions
        #region ClasesFromLine
        private Movie_txt Readmovie_txt(string line)
        {
            string movieString = line.Substring(9,line.Length-10);

            // Regular expression pattern to extract the fields
            string pattern = @"^<title> - (.+);<genre> - (.+?)\(<releaseYear> - (.+)\/<duration> - (.*?)\)@\(<author id> - (.*)\)";

            // Create a Regex object and match the pattern against the string
            Regex regex = new Regex(pattern);
            Match match = regex.Match(movieString);

            // Extract the fields from the Match object
            string title = match.Groups[1].Value;
            string genre = match.Groups[2].Value;
            int releaseYear = int.Parse(match.Groups[3].Value);
            int duration = int.Parse(match.Groups[4].Value);
            int authorId = int.Parse(match.Groups[5].Value);

            // Print the extracted fields
            Movie_txt temp = new Movie_txt();
            temp.title = title;
            temp.genere = genre;
            temp.releaseYear = releaseYear;
            temp.duration = duration;
            temp.directorId = authorId;
            return temp;
        }

        private Series_txt ReadSeries_txt(string line)
        {
            string movieString = line.Substring(10, line.Length - 11);

            // Regular expression pattern to extract the fields
            string pattern = @"^<title> - (.+);<genre> - (.+?)\@\(<showrunner id> - (.*?)\)\-\((.+)\)(.+)";

            // Create a Regex object and match the pattern against the string
            Regex regex = new Regex(pattern);
            Match match = regex.Match(movieString);

            // Extract the fields from the Match object
            string title = match.Groups[1].Value;
            string genre = match.Groups[2].Value;
            int show_runner = int.Parse(match.Groups[3].Value);
            string episodes = match.Groups[5].Value;
            // Print the extracted fields
            Series_txt temp = new Series_txt();
            temp.title = title;
            temp.genere = genre;
            temp.showrunnerId = show_runner;
            foreach(var num in episodes.Split(' ')) 
            { 
                if (num!=null)
                {
                    int numer = int.Parse(num);
                    temp.episodesId.Add(numer);
                }
            }

            return temp;
        }
        private Episode_txt ReadEpisodes_txt(string line)
        {
            string movieString = line.Substring(11, line.Length - 12);

            // Regular expression pattern to extract the fields
            string pattern = @"^<title> - (.+)\/<duration> - (.+?)\(<releaseYear> - (.+?)\);\(<author id> - (.+?)\)";

            // Create a Regex object and match the pattern against the string
            Regex regex = new Regex(pattern);
            Match match = regex.Match(movieString);

            // Extract the fields from the Match object
            string title = match.Groups[1].Value;
            int duration = int.Parse(match.Groups[2].Value); ;
            int release_year = int.Parse(match.Groups[3].Value);
            int author_id = int.Parse(match.Groups[4].Value);
            // Print the extracted fields
            Episode_txt temp = new Episode_txt();
            temp.title = title;
            temp.authorId = author_id;
            temp.duration = duration;
            temp.releaseYear = release_year;
            return temp;
        }
        private Author_txt ReadAuthor_txt(string line)
        {
            string movieString = line.Substring(10, line.Length - 11);

            // Regular expression pattern to extract the fields
            string pattern = @"^<name> - (.+?)\+<surname> - (.+?)\+<birthYear> - (.+?)\^<awards>\^(.+)";

            // Create a Regex object and match the pattern against the string
            Regex regex = new Regex(pattern);
            Match match = regex.Match(movieString);

            // Extract the fields from the Match object
            string name = match.Groups[1].Value;
            string surname = match.Groups[2].Value;
            int year = int.Parse(match.Groups[3].Value);
            int awards = int.Parse(match.Groups[4].Value);
            // Print the extracted fields
            Author_txt temp = new Author_txt();
            temp.Name = name;
            temp.Surname = surname;
            temp.birthYear = year;
            temp.awards = awards;
            return temp;
        }


        #endregion

        #region Bitfilix commands

        public object GetTableOfName(string name)
        {
             return data_main.CommandArrayDict[name];
        }
        public object GetTableSecondaryOfName(string name)
        {
            return data_From_Txt.CommandArrayDict[name];
        }

        public Func<object, object, bool> GetFuncOfName(string name)
        {
            return comparisonOperators[name];
        }


        #endregion
    }

    //structs declaration
    #region structs
    public struct data_from_txt
    {
        internal List<Author_txt>? authors { get; set; }
        internal List<Series_txt>? series { get; set; }
        internal List<Movie_txt>? movies { get; set; }
        internal List<Episode_txt>? episodes { get; set; }
        public Dictionary<string, object> CommandArrayDict;
        public data_from_txt()
        {
            authors = new List<Author_txt>();
            series = new List<Series_txt>();
            movies = new List<Movie_txt>();
            episodes = new List<Episode_txt>();
            CommandArrayDict = new Dictionary<string, object>
            {
                {"authors",authors },
                {"series",series },
                {"movies",movies },
                {"episodes",episodes }
            };
        }
    }
    public struct data
    {
        internal List<Author>? authors { get; set; }
        internal List<Series>? series { get; set; }
        internal List<Movie>? movies { get; set; }
        internal List<Episode>? episodes { get; set; }

        public Dictionary<string, object> CommandArrayDict;
        public data()
        {
            authors = new List<Author>();
            series = new List<Series>();
            movies = new List<Movie>();
            episodes = new List<Episode>();
            CommandArrayDict = new Dictionary<string, object>
            {
                {"authors",authors },
                {"series",series },
                {"movies",movies },
                {"episodes",episodes }
            };

        }
    }
    #endregion
}
