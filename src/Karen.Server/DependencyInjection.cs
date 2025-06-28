using Karen.Server.Messaging;
using Karen.Server.Tcp.Handlers.Handshake;
using Karen.Server.Tcp.Handlers.Player;

namespace Karen.Server;

public static class DependencyInjection {
    public static void AddTcpService( this WebApplicationBuilder builder ) {
        _ = builder.WebHost.ConfigureKestrel( options =>
            options.ListenAnyIP( 12321, listen_options => listen_options.UseConnectionHandler<TcpService>() )
        );

        _ = builder.Services
             .AddSingleton<ITcpClientService, TcpClientService>()
             .AddSingleton<HandlerRepository>()
             .AddSingleton<ParserRepository>()
             .AddTransient<IComposerFactory, ComposerFactory>()
             .AddTransient<IMessageDispatcher, MessageDispatcher>()

             // handlers
             .AddTransient<IHandler, InitCryptoHandler>()
             .AddTransient<IHandler, GenerateKeyHandler>()
             .AddTransient<IHandler, TryLoginHandler>()
             .AddTransient<IHandler, GetInfoHandler>();
    }
}
