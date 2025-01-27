using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.Build().Run();

// var builder = new HostBuilder()
//     .ConfigureFunctionsWorkerDefaults()
//     .ConfigureServices(services =>
//     {
//         // Add services
//     });

// builder.ConfigureFunctionsWebApplication();

// await builder.Build().RunAsync();
