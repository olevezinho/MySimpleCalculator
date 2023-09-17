using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MyCalculatorWebApp;
using NUnit.Framework;

namespace MySimpleCalculatorWebAPI.IntegrationTests
{
    public class SetupTestServer : IDisposable
    {
        private readonly TestServer Server;

        public HttpClient Client { get; private set; }

        public SetupTestServer()
        {
            Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            Client?.Dispose();
            Server?.Dispose();
        }
    }
}
