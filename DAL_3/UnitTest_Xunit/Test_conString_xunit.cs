using DAL_3.ConnectionString;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest_Xunit
{
    public class Test_conString_xunit
    {
        ConnectStringAccess conString;
        IConfiguration configuration;
        public Test_conString_xunit()
        {
            conString = new ConnectStringAccess();
        }
        [Fact]
        public void ShouldGetConnectionString_ProductionRetrunTrue()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"TopLevelKey", "TopLevelValue"},
                {"ConnectionStrings:Production", "Data Source=server_name_production; Initial Catalog = base_name; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"},

            };
            this.configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

            var result = ConnectStringAccess.GetConnectStringAccessFrom_appsettings_json(configuration, "Production");
            string target = configuration.GetConnectionString("Production");
            Xunit.Assert.Equal(target, result);
        }
        [Fact]
        public void ShouldNotGetConnectionString_ProductionRetrunFalse()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"TopLevelKey", "TopLevelValue"},
                {"ConnectionStrings:Developer", "Data Source=server_name_developer; Initial Catalog = base_name; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"},

            };
            this.configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

            var result = ConnectStringAccess.GetConnectStringAccessFrom_appsettings_json(configuration, "Production");
            string target = configuration.GetConnectionString("Production");
            Xunit.Assert.NotEqual(target, result);
        }
    }
}
