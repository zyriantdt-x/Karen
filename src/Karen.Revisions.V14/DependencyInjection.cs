using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Handshake;
using Karen.Revisions.V14.Composers.Handshake;
using Karen.Revisions.V14.Handlers.Handshake;
using Karen.Revisions.V14.Handlers.Player;
using Karen.Revisions.V14.Parsers.Handshake;
using Microsoft.Extensions.DependencyInjection;

namespace Karen.Revisions.V14;
public static class DependencyInjection {
    public static void AddV14( this IServiceCollection services ) {
        _ = services.AddTransient<IHandler, InitCryptoHandler>()
                    .AddTransient<IHandler, GenerateKeyHandler>()
                    .AddTransient<IHandler, TryLoginHandler>()
                    .AddTransient<IHandler, GetInfoHandler>()

                    // parsers
                    .AddTransient<IParser, TryLoginParser>()

                    // composers
                    .AddTransient<IComposer<HelloMessage>, HelloComposer>()
                    .AddTransient<IComposer<AvailableSetsMessage>, AvailableSetsComposer>();
    }
}
