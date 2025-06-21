using Karen.Revisions.V14.Handlers.Handshake;
using Microsoft.Extensions.DependencyInjection;

namespace Karen.Revisions.V14;
public static class DependencyInjection {
    public static void AddV14( this IServiceCollection services ) {
        _ = services.AddTransient<InitCryptoHandler>();
    }
}
