using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ProductsApp
{
    /// <summary>
    /// 
    /// </summary>
    public class LambdaFuntion : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseLambdaServer();
        }
    }
}
