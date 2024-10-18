using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace Util
{
    public static class DBConnection
    {
        private static IConfigurationRoot _configuration;
        static string s = null;
        static DBConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("C:\\Users\\ROG\\source\\repos\\Courier\\Util\\AppSettings.json",
               optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }
        public static string ReturnCn(string key)
        {

            s = _configuration.GetConnectionString("dbCn");

            return s;
        }


    }
}