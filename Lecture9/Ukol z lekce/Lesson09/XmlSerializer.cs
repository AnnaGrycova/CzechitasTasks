using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson09
{
    public class XmlSerializer
    {
        public void LoadXmlFile()
        {
            //string[] lines = System.IO.File.ReadAllLines("History.xml");
            var wholeXmlFile = System.IO.File.ReadAllText("History.xml");

            var doc = XDocument.Parse(wholeXmlFile);

            var rootElement = doc.Root;


        }
    }
}
