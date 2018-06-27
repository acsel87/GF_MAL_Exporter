using ExportLibrary.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExportLibrary.DataAccess
{
    public class ExportTXT : IListSource
    {
        public List<string> resultGF = new List<string>();
        public List<string> resultMAL = new List<string>();

        public ExportTXT(List<GFModel> models, string fileSavePath)
        {
            CreateGF(models);
            File.WriteAllLines(fileSavePath, resultGF);
        }

        public ExportTXT(List<MALModel> models, string fileSavePath)
        {
            CreateMAL(models);
            File.WriteAllLines(fileSavePath, resultMAL);
        }

        public void CreateGF(List<GFModel> models)
        {      
            List<string> result = new List<string>();

            foreach (GFModel m in models)
            {
                result.Add($"{m.Year}     {m.Name}");
            }

            resultGF = result;
        }

        public void CreateMAL(List<MALModel> models)
        {
            int maxWatchingLength = 8;
            int maxCompletedLength = 9;
            int maxOnHoldLength = 7;
            int maxDroppedLength = 7;
            int maxPlanToWatchLength = 13;

            const string watchingStatus = "Watching";
            const string completedStatus = "Completed";
            const string onHoldStatus = "On Hold";
            const string droppedStatus = "Dropped";
            const string planToWatchStatus = "Plan to Watch";
            const string spacing = @"     ";

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

                        if (m.Name.Length > maxWatchingLength)
                        {
                            maxWatchingLength = m.Name.Length;
                        }

                        break;

                    case completedStatus:
                        completed.Add(m.Name);

                        if (m.Name.Length > maxCompletedLength)
                        {
                            maxCompletedLength = m.Name.Length;
                        }

                        break;

                    case onHoldStatus:
                        onHold.Add(m.Name);

                        if (m.Name.Length > maxOnHoldLength)
                        {
                            maxOnHoldLength = m.Name.Length;
                        }

                        break;

                    case droppedStatus:
                        dropped.Add(m.Name);

                        if (m.Name.Length > maxDroppedLength)
                        {
                            maxDroppedLength = m.Name.Length;
                        }

                        break;

                    case planToWatchStatus:
                        planToWatch.Add(m.Name);

                        if (m.Name.Length > maxPlanToWatchLength)
                        {
                            maxPlanToWatchLength = m.Name.Length;
                        }

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
   
            result.Add($"{watchingStatus.PadRight(maxWatchingLength)}{spacing}{completedStatus.PadRight(maxCompletedLength)}{spacing}{onHoldStatus.PadRight(maxOnHoldLength)}{spacing}{droppedStatus.PadRight(maxDroppedLength)}{spacing}{planToWatchStatus.PadRight(maxPlanToWatchLength)}");
            result.Add($"{totals[0].ToString().PadRight(maxWatchingLength)}{spacing}{totals[1].ToString().PadRight(maxCompletedLength)}{spacing}{totals[2].ToString().PadRight(maxOnHoldLength)}{spacing}{totals[3].ToString().PadRight(maxDroppedLength)}{spacing}{totals[4].ToString().PadRight(maxPlanToWatchLength)}");
            result.Add("");

            for (int i = 0; i < totals.Max(); i++)
            {
                string watchingIndex = i < totals[0] ? watching[i].PadRight(maxWatchingLength) : string.Empty.PadRight(maxWatchingLength);
                string completedIndex = i < totals[1] ? completed[i].PadRight(maxCompletedLength) : string.Empty.PadRight(maxCompletedLength);
                string onHoldIndex = i < totals[2] ? onHold[i].PadRight(maxOnHoldLength) : string.Empty.PadRight(maxOnHoldLength);
                string droppedIndex = i < totals[3] ? dropped[i].PadRight(maxDroppedLength) : string.Empty.PadRight(maxDroppedLength);
                string planToWatchIndex = i < totals[4] ? planToWatch[i].PadRight(maxPlanToWatchLength) : string.Empty.PadRight(maxPlanToWatchLength);

                result.Add($"{watchingIndex}{spacing}{completedIndex}{spacing}{onHoldIndex}{spacing}{droppedIndex}{spacing}{planToWatchIndex}");
            }

            resultMAL = result;
        }       
    }
}
