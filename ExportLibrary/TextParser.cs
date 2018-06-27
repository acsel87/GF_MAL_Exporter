using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ExportLibrary
{
    public class TextParser
    {
        static int maxWatchingLength = 8;
        static int maxCompletedLength = 9;
        static int maxOnHoldLength = 7;
        static int maxDroppedLength = 7;
        static int maxPlanToWatchLength = 13;        

        public static string ParserXml()
        {
            const string watchingStatus = "Watching";
            const string completedStatus = "Completed";
            const string onHoldStatus = "On Hold";
            const string droppedStatus = "Dropped";
            const string planToWatchStatus = "Plan to Watch";
            const string spacing = @"     ";

            string readFilePath = "C:\\Users\\Alex\\Desktop\\animelist.xml";
            string writeFilePath = "C:\\Users\\Alex\\Desktop\\AnimeXml.txt";           

            List<string> result = new List<string>();

            List<string> watching = new List<string>();
            List<string> completed = new List<string>();
            List<string> onHold = new List<string>();
            List<string> dropped = new List<string>();
            List<string> planToWatch = new List<string>();

            XDocument doc = XDocument.Load(readFilePath);

            var myTag = doc.XPathSelectElements("//my_status");

            foreach (XElement elem in myTag)
            {
                var title = elem.Parent.XPathSelectElement("./series_title").Value;

                switch (elem.Value)
                {
                    case watchingStatus:                        
                        watching.Add(title);

                        if (title.Length > maxWatchingLength)
                        {
                            maxWatchingLength = title.Length;
                        }
                        break;

                    case completedStatus:
                        completed.Add(title);

                        if (title.Length > maxCompletedLength)
                        {
                            maxCompletedLength = title.Length;
                        }
                        break;

                    case onHoldStatus:
                        onHold.Add(title);

                        if (title.Length > maxOnHoldLength)
                        {
                            maxOnHoldLength = title.Length;
                        }
                        break;

                    case droppedStatus:
                        dropped.Add(title);

                        if (title.Length > maxDroppedLength)
                        {
                            maxDroppedLength = title.Length;
                        }
                        break;

                    case planToWatchStatus:
                        planToWatch.Add(title);

                        if (title.Length > maxPlanToWatchLength)
                        {
                            maxPlanToWatchLength = title.Length;
                        }
                        break;
                }
            }

            int[] totals = new int[]
            {
                watching.Count,
                completed.Count,
                onHold.Count,
                dropped.Count,
                planToWatch.Count
            };

            //totals[0] = 30;
            //totals[1] = 50;
            //totals[2] = 65;
            //totals[3] = 30;
            //totals[4] = 35;

            string firstColumn = $"{watchingStatus.PadRight(maxWatchingLength)}{spacing}{completedStatus.PadRight(maxCompletedLength)}{spacing}{onHoldStatus.PadRight(maxOnHoldLength)}{spacing}{droppedStatus.PadRight(maxDroppedLength)}{spacing}{planToWatchStatus.PadRight(maxPlanToWatchLength)}";
            result.Add(firstColumn);
            result.Add($"{totals[0].ToString().PadRight(maxWatchingLength)}{spacing}{totals[1].ToString().PadRight(maxCompletedLength)}{spacing}{totals[2].ToString().PadRight(maxOnHoldLength)}{spacing}{totals[3].ToString().PadRight(maxDroppedLength)}{spacing}{totals[4].ToString().PadRight(maxPlanToWatchLength)}");

            
            for (int i = 0; i < totals.Max(); i++)
            {
                string watchingIndex = i < totals[0] ? watching[i].PadRight(maxWatchingLength) : string.Empty.PadRight(maxWatchingLength);
                string completedIndex = i < totals[1] ? completed[i].PadRight(maxCompletedLength) : string.Empty.PadRight(maxCompletedLength);
                string onHoldIndex = i < totals[2] ? onHold[i].PadRight(maxOnHoldLength) : string.Empty.PadRight(maxOnHoldLength);
                string droppedIndex = i < totals[3] ? dropped[i].PadRight(maxDroppedLength) : string.Empty.PadRight(maxDroppedLength);
                string planToWatchIndex = i < totals[4] ? planToWatch[i].PadRight(maxPlanToWatchLength) : string.Empty.PadRight(maxPlanToWatchLength);

                result.Add($"{watchingIndex}{spacing}{completedIndex}{spacing}{onHoldIndex}{spacing}{droppedIndex}{spacing}{planToWatchIndex}");                    
            }

            File.WriteAllLines(writeFilePath, result);
            return string.Join(Environment.NewLine, result);
        }

        public static string ParserHTML()
        {
            string readFilePath = "C:\\Users\\Alex\\Desktop\\games.html";
            string writeFilePath = "C:\\Users\\Alex\\Desktop\\GamesHTML.txt";

            List<string> rank = new List<string>();
            List<string> name = new List<string>();
            List<string> extra = new List<string>();
            List<string> result = new List<string>(); ;

            StreamReader theFile = new StreamReader(readFilePath);

            string content = theFile.ReadToEnd();
            theFile.Close();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);

            var myDiv = doc.DocumentNode.SelectNodes("//div[@class='rank']");

            for (int i = 0; i < myDiv.Count; i++)
            {
                rank.Add(myDiv[i].InnerText);
            }

            myDiv = doc.DocumentNode.SelectNodes("//div[@class='name']");

            for (int i = 0; i < myDiv.Count; i++)
            {
                name.Add(myDiv[i].InnerText);
            }

            myDiv = doc.DocumentNode.SelectNodes("//div[@class='extra']");

            for (int i = 0; i < myDiv.Count; i++)
            {
                extra.Add(myDiv[i].InnerText);

                result.Add($"{rank[i]}\t\t{extra[i].Remove(0, 5)}\t{name[i]}");
            }

            File.WriteAllLines(writeFilePath, result); 
            return string.Join(System.Environment.NewLine, result);
        }        
    }
}
