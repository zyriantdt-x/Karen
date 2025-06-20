WebApplicationBuilder builder = WebApplication.CreateBuilder( args );

builder.WebHost.ConfigureKestrel( options => 
    options.ListenAnyIP( 12321, listen_options => listen_options.UseConnectionHandler<TcpService>() )
);

builder.Configuration
    .SetBasePath( Directory.GetCurrentDirectory() )
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();