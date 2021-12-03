using DAL_3.ConnectionString;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DAL
{

    class Test_conString_nunit
    {
        ConnectStringAccess conString;
        IConfiguration configuration;
        [SetUp]
        public void Setup()
        {
            conString = new ConnectStringAccess();
        }
        [Test]
        public void ShouldGetConnectionStringFromFile()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"TopLevelKey", "TopLevelValue"},
                {"ConnectionStrings:Production", "Data Source=server_name_production; Initial Catalog = base_name; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"},

            };
            this.configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

            var result = ConnectStringAccess.GetConnectStringAccessFrom_appsettings_json(configuration, "Production");
            Assert.IsTrue(result.Contains("server_name_production"));
        }
    }
}
