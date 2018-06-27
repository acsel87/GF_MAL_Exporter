using ExportLibrary.Models;
using System.Collections.Generic;

namespace ExportLibrary.DataAccess
{
    public interface IListSource
    {
        void CreateGF(List<GFModel> models);
        void CreateMAL(List<MALModel> models);        
    }
}
