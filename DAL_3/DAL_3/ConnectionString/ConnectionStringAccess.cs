using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_3.ConnectionString
{

    public  class ConnectStringAccess 
    {
        //czy mozna trzymac wiecej conection stringow w appsettings_json?    
        public static string GetConnectStringAccessFrom_appsettings_json(IConfiguration config, string ConstringName)
        {
            return  config.GetConnectionString(ConstringName);
        }

        public static string GetConnectStringAccessFrom_file(string tableNameSqlite)
        {
            string tablename = "";
            string pathDbFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!STableNameDictionary.getdTableName.Any(x => x.Key == tableNameSqlite))
            {
                tablename = STableNameDictionary.getdTableName.Where(x => x.Key == "Client").FirstOrDefault().Value;
            }
            else
            {
                tablename = STableNameDictionary.getdTableName.Where(x => x.Key == tableNameSqlite).FirstOrDefault().Value;
            }
            return  new SqliteConnection(@"DataSource=" + pathDbFile + tablename).ConnectionString;
        }
    }
}
