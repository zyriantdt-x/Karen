using Karen.Revisions.V14;

WebApplicationBuilder builder = WebApplication.CreateBuilder( args );

builder.Configuration
    .SetBasePath( Directory.GetCurrentDirectory() )
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

builder.AddTcpService();

builder.Services.AddV14();

// logs
builder.Services.AddLogging( logging => {
    logging.ClearProviders();
    logging.AddSimpleConsole( options => {
        options.SingleLine = true;
        options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
    } );
} );

await builder.Build().RunAsync();