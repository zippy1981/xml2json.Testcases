using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Bson;
using JsonFormatting = Newtonsoft.Json.Formatting;

namespace xml2json
{
    [TestFixture]
	class MainClass
	{
        public MainClass() {}

        private static readonly MainClass instance;

        internal static MainClass Instance
        {
            get { return instance; }
        }

        static MainClass()
        {
            instance = new MainClass();
        }

		/// <summary>
		/// Convert the NYS Thruway authority Park and Ride xml file to json.
		/// </summary>
		/// <param name="args">Command line arguments.</param>
		public static void Main (string[] args)
		{
			Instance.TestTestCase();
		}

        private static string XmlFileToJson(string filename)
        {
            var xml = new XmlDocument();
            xml.Load(filename);
            return JsonConvert.SerializeXmlNode(xml);
        }

        [Test]
        public void TestParkAndRides()
        {
            Console.WriteLine("JSON: {0}", XmlFileToJson("parkridelots.xml"));
        }

        [Test]
        public void TestTestCase()
        {
            Console.WriteLine("JSON: {0}", XmlFileToJson("testcase.xml"));
        }



        [Test]
        public void TestTestCaseDtd()
        {
            var xml = new XmlDocument();
            xml.Load("testcase.dtd");
            Console.WriteLine("Doctype Name: {0} Value{1}", xml.DocumentType.Name, xml.DocumentType.Value);
            Console.WriteLine("Child count: {0}", xml.DocumentType.ChildNodes.Count);
        }

        [Test]
        public void TestHtml401Dtd()
        {
            //Console.WriteLine("JSON: {0}", XmlFileToJson("html4.0.1-strict.dtd"));
            Console.WriteLine("JSON: {0}", XmlFileToJson("xmlspec.dtd"));
        }
	}
}

