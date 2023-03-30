using ObjectOrientedDesigndProject.classes;
using ObjectOrientedDesigndProject.classes__map;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace ObjectOrientedDesigndProject 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region inputData
            /*
            1.Apocalypse now, war film, Francis Coppola, 147m, 1979
            2.The Godfather, criminal, Francis Coppola, 175m, 1972
            3.Raiders of the lost ark, adventure, Steven Spielberg, 115m, 1981
            4.The Great Dictator, comedy, Charlie Chaplin, 125m, 1940*/

            Movie_map m1 = new Movie_map("Apocalypse now", "war film", "2", "147", "1979");
            Movie_map m2 = new Movie_map("The Godfather", "criminal", "2", "175", "1972");
            Movie_map m3 = new Movie_map("Raiders of the lost ark", "adventure", "1", "115", "1981");
            Movie_map m4 = new Movie_map("The Great Dictator", "comedy", "3", "125", "1940");
            /*            Series - title, genre, showrunner, episodes
                    Episode - title, duration, releaseYear, director
            1.Breaking Bad, drama, Vince Gilligan
               1.Fly, 45, 2010, Rian Johnson
               2.Ozymandias, 50, 2013, Rian Johnson,
               3.Pilot, 43, 2008, Vince Gilligan
            2.The Office US, horror, Greg Daniels
               1.Dwight K.Schrute, (Acting)Manager; 22, 2011,Troy Miller
               2.The Carpet, 23, 2006; Victor Nelli, Jr.
               3.Dwight's Speech, 22, 2006, Charles McDougall*/
            List<string> list = new List<string>();
            list.Add("1"); list.Add("2"); list.Add("3");

            Series_map s1 = new Series_map("Breaking Bad", "drama", "4", list);
            Series_map s2 = new Series_map("The Office US", "horror", "6", list);

            Episode_map e1 = new Episode_map("Fly", "45", "2010", "5", "1");
            Episode_map e2 = new Episode_map("Ozymandias", "50", "2013", "5", "2");
            Episode_map e3 = new Episode_map("Pilot", "43", "2008", "4", "3");
            Episode_map e4 = new Episode_map("Dwight K.Schrute", "6", "2011", "7", "4");
            Episode_map e5 = new Episode_map("The Carpet", "23", "2006", "8", "5");
            Episode_map e6 = new Episode_map("Dwight's Speech", "22", "2006", "9", "6");

            /*           
            1.Steven, Spielberg, 1956, 73
            2.Francis, Coppola, 1939, 32
            3.Charlie, Chaplin, 1889, 6
            4.Vince, Gilligan, 1967, 17
            5.Rian, Johnson, 1973, 29
            6.Greg, Daniels, 1963, 5
            7.Troy, Miller, 1960, 0
            8.Victor, Nelli Jr., 1960, 0
            9.Charles, McDougall, 1960, 0*/

            Author_map a1 = new Author_map("Steven", "Spielberg", "1956", "73");
            Author_map a2 = new Author_map("Francis", "Coppola", "1939", "32");
            Author_map a3 = new Author_map("Charlie", "Chaplin", "1889", "6");
            Author_map a4 = new Author_map("Vince", "Gilligan", "1967", "17");
            Author_map a5 = new Author_map("Rian", "Johnson", "1973", "29");
            Author_map a6 = new Author_map("Greg", "Daniels", "1963", "5");
            Author_map a7 = new Author_map("Victor", "Nelli Jr", "1960", "0");
            Author_map a8 = new Author_map("Charles", "McDougall", "1960", "0");
            Author_map a9 = new Author_map("9", "9", "1960", "0");
            List<Author_map> authors = new List<Author_map> { a1, a2, a3, a4, a5, a6, a7, a8, a9 };
            List<Series_map> series = new List<Series_map> { s1, s2 };
            List<Episode_map> episodes = new List<Episode_map> { e1, e2, e3, e4, e5, e6 };
            List<Movie_map> movies = new List<Movie_map> { m1, m2, m3, m4 };
            Bitflix bitflix = new Bitflix();
            bitflix.LoadDataToTxtFormatFromMap(authors, episodes, movies, series);
            bitflix.LoadDataToProgramFormatFromTxt();
            #endregion
            foreach(var movie in bitflix.data_main.movies)
            {
                if (movie.director.birthYear > 1970)
                    Console.WriteLine(movie);
            }
            foreach (var ser in bitflix.data_main.episodes)
            {
                if (ser.author.birthYear > 1970)
                {
                    Console.WriteLine(ser);
                }
            }
            //this is the first part finished :) 
        }
    }
}