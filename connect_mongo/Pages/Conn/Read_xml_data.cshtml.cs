using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using connect_mongo_data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace connect_mongo.Pages.Conn
{
    public class Read_xml_dataModel : PageModel
    {
        public String Data { get; set; }
        public void OnGet()
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load("/Users/shubhamgupta/Projects/test/test_conn/EmptyXmlFile.xml");

            var json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc1);
            Console.WriteLine(json);
           

        }
    }
}
