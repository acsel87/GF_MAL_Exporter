using System.Configuration;

namespace ExportLibrary.DataAccess
{
    public static class GlobalConfig
    {
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
