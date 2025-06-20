using Karen.Revisions.V14;

WebApplicationBuilder builder = WebApplication.CreateBuilder( args );

builder.Configuration
    .SetBasePath( Directory.GetCurrentDirectory() )
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

builder.AddTcpService();

builder.Services.AddV14();

await builder.Build().RunAsync();