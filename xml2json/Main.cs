using System;
using System.IO;
using System.Xml;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JsonFormatting = Newtonsoft.Json.Formatting;

namespace xml2json
{
	class MainClass
	{
		/// <summary>
		/// Convert the NYS Thruway authority Park ANd Ride xml file to json.
		/// </summary>
		/// <param name="args">Command line arguments.</param>
		public static void Main (string[] args)
		{
			var xml = new XmlDocument();
			//xml.Load("parkridelots.xml");
			xml.Load("testcase.xml");
			var json = JsonConvert.SerializeXmlNode(xml, JsonFormatting.Indented);
			File.WriteAllText("testcase.json", json);
			Console.WriteLine(json);
		}
	}
}

