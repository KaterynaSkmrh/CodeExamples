using NUnit.Framework;
using CodeExamples;
using System.Threading.Tasks;

namespace CodeExamples.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public static async  Task Test1()
        {
            var fl = new FlurlExample();
            var genres =await  fl.GetGenres();
            string gn = "";
            foreach(var genre in genres)
            {
                gn += genre.name + "  ";
            }
            Assert.Pass(gn);
        }
    }
}