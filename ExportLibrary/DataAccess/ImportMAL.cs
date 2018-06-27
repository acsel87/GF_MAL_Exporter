using ExportLibrary.Models;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ExportLibrary.DataAccess
{
    public static class ImportMAL
    {
        public static List<MALModel> ParseXML(string filePath)
        {
            List<MALModel> models = new List<MALModel>();            

            XDocument doc = XDocument.Load(filePath);

            var myTag = doc.XPathSelectElements("//my_status");

            foreach (XElement elem in myTag)
            {
                MALModel tempModel = new MALModel();
                tempModel.Status = elem.Value;
                tempModel.Name = elem.Parent.XPathSelectElement("./series_title").Value.Replace(',', ' ').Replace(';', ' ');
                models.Add(tempModel);
            }

            return models;
        }
    }
}
