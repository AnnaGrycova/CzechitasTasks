using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson09
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer();
            serializer.LoadXmlFile();

            var prihlasovani = new Prihlasovani();
        }
    }
}
