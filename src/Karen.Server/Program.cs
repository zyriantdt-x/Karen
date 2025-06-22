using Karen.Revisions.V14;

WebApplicationBuilder builder = WebApplication.CreateBuilder( args );

builder.Configuration
    .SetBasePath( Directory.GetCurrentDirectory() )
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

builder.AddTcpService();

builder.Services.AddV14();

// logs - this is ugly asf
builder.Services.AddLogging( logging => 
            _ = logging.ClearProviders()
                .AddSimpleConsole( options => {
                    options.SingleLine = true;
                    options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
                } ) );

await builder.Build().RunAsync();