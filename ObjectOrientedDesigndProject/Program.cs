using System;

namespace ObjectOrientedDesigndProject 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Bitflix bitflix = new Bitflix();
            bitflix.LoadDataFromFile("C:\\Users\\bezi1\\source\\repos\\ObjectOrientedDesigndProject\\ObjectOrientedDesigndProject\\TextFile1.txt");
            bitflix.LoadDataToProgramFormat();
            Console.WriteLine (bitflix.data_main.authors[0]);
            foreach(var ep in bitflix.data_main.episodes) 
            {
                Console.WriteLine (ep);
            }
        }
    }
}