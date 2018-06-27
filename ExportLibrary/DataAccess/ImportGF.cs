using ExportLibrary.Models;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;

namespace ExportLibrary.DataAccess
{
    public static class ImportGF
    {
        public static List<GFModel> ParseHTML(string filePath)
        {
            List<GFModel> models = new List<GFModel>();            

            StreamReader gameFile = new StreamReader(filePath);

            string content = gameFile.ReadToEnd();
            gameFile.Close();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);            

            var myDiv = doc.DocumentNode.SelectNodes("//div[@class='name']");           

            for (int i = 0; i < myDiv.Count; i++)
            {
                GFModel tempModel = new GFModel();
                tempModel.Name = myDiv[i].InnerText.Replace(',',' ').Replace(';',' ');
                models.Add(tempModel);
            }

            myDiv = doc.DocumentNode.SelectNodes("//div[@class='extra']");

            for (int i = 0; i < myDiv.Count; i++)
            {
                models[i].Year = myDiv[i].InnerText;                
            }

            return models;
        }        
    }
}
