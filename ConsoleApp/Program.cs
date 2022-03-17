using CodeExamples;
using System;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Console.ReadLine();
        }
        public static async Task Test()
        {
            var fl = new FlurlExample();
            var genres = await fl.GetGenres();
            string gn = "";
            foreach (var genre in genres)
            {
                gn += "_" + genre.name + "_" + genre.id + "  ";
            }
            Console.WriteLine(gn);

        }

        public static async Task Test1()
        {
            var fl = new PrivatBankApi();
            var genres = await fl.GetExchange();
            string gn = "";
            foreach (var genre in genres)
            {
                gn += genre.ccy + " " + genre.base_ccy + " " + genre.buy + " " + genre.sale + "\n";
            }
            Console.WriteLine(gn);

        }
    }
}
