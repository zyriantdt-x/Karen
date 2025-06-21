using Karen.Common.Interfaces;
using Karen.Revisions.V14.Handlers.Handshake;
using Karen.Revisions.V14.Parsers.Handshake;
using Microsoft.Extensions.DependencyInjection;

namespace Karen.Revisions.V14;
public static class DependencyInjection {
    public static void AddV14( this IServiceCollection services ) {
        _ = services.AddTransient<IHandler, InitCryptoHandler>()
                    .AddTransient<IHandler, GenerateKeyHandler>()
                    .AddTransient<IHandler, TryLoginHandler>()

                    // parsers
                    .AddTransient<IParser, TryLoginParser>();
    }
}
