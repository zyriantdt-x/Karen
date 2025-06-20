using Karen.Server.Messaging;

namespace Karen.Server;

public static class DependencyInjection {
    public static void AddTcpService( this WebApplicationBuilder builder ) {
        _ = builder.WebHost.ConfigureKestrel( options =>
            options.ListenAnyIP( 12321, listen_options => listen_options.UseConnectionHandler<TcpService>() )
        );

        _ = builder.Services
             .AddSingleton<ITcpClientService, TcpClientService>()
             .AddSingleton<HandlerRepository>()
             .AddSingleton<ParserRepository>();
    }
}
