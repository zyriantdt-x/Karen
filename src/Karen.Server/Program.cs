using Karen.Revisions.V14;
using Karen.Server.Storage;

WebApplicationBuilder builder = WebApplication.CreateBuilder( args );

builder.Configuration
    .SetBasePath( Directory.GetCurrentDirectory() )
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

builder.AddTcpService();

builder.Services.AddV14();
builder.Services.AddDbContextFactory<KarenDbContext>( options => options.UseSqlite( $"Data Source=C:\\etc\\karen.db" ) );
builder.Services.AddSingleton<IKarenDbContextFactory, KarenDbContextFactory>();

// logs - this is ugly asf
builder.Services.AddLogging( logging => 
            _ = logging.ClearProviders()
                .AddSimpleConsole( options => {
                    options.SingleLine = true;
                    options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
                } ) );

await builder.Build().RunAsync();