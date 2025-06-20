WebApplicationBuilder builder = WebApplication.CreateBuilder( args );

builder.Configuration
    .SetBasePath( Directory.GetCurrentDirectory() )
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

builder.AddTcpService();

