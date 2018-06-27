using ExportLibrary.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExportLibrary.DataAccess
{
    public class ExportCSV : IListSource
    {
        private List<string> resultGF = new List<string>();
        private List<string> resultMAL = new List<string>();

        public ExportCSV(List<GFModel> models, string fileSavePath)
        {
            CreateGF(models);
            File.WriteAllLines(fileSavePath, resultGF);
        }

        public ExportCSV(List<MALModel> models, string fileSavePath)
        {
            CreateMAL(models);
            File.WriteAllLines(fileSavePath, resultMAL);
        }

        public void CreateGF(List<GFModel> models)
        {
            List<string> result = new List<string>();

            foreach (GFModel m in models)
            {
                result.Add($"{m.Name},{m.Year}");
            }

            resultGF = result;
        }

        public void CreateMAL(List<MALModel> models)
        {
            const string watchingStatus = "Watching";
            const string completedStatus = "Completed";
            const string onHoldStatus = "On Hold";
            const string droppedStatus = "Dropped";
            const string planToWatchStatus = "Plan to Watch";

            List<string> watching = new List<string>();
            List<string> completed = new List<string>();
            List<string> onHold = new List<string>();
            List<string> dropped = new List<string>();
            List<string> planToWatch = new List<string>();

            List<string> result = new List<string>();

            foreach (MALModel m in models)
            {
                switch (m.Status)
                {
                    case watchingStatus:
                        watching.Add(m.Name);
                        break;

                    case completedStatus:
                        completed.Add(m.Name);
                        break;

                    case onHoldStatus:
                        onHold.Add(m.Name);
                        break;

                    case droppedStatus:
                        dropped.Add(m.Name);
                        break;

                    case planToWatchStatus:
                        planToWatch.Add(m.Name);
                        break;

                    default:
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

            result.Add($"{watchingStatus},{completedStatus},{onHoldStatus},{droppedStatus},{planToWatchStatus}");
            result.Add($"{totals[0]},{totals[1]},{totals[2]},{totals[3]},{totals[4]}");            

            for (int i = 0; i < totals.Max(); i++)
            {
                string watchingIndex = i < totals[0] ? watching[i] + ',' : ",";
                string completedIndex = i < totals[1] ? completed[i] + ',' : ",";
                string onHoldIndex = i < totals[2] ? onHold[i] + ',' : ",";
                string droppedIndex = i < totals[3] ? dropped[i] + ',' : ",";
                string planToWatchIndex = i < totals[4] ? planToWatch[i] : ",";

                result.Add($"{watchingIndex}{completedIndex}{onHoldIndex}{droppedIndex}{planToWatchIndex}");
            }

            resultMAL = result;
        }
        
    }
}
