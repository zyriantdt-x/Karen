using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Alerts;
using Karen.Common.Messages.Outgoing.Handshake;
using Karen.Common.Messages.Outgoing.Player;
using Karen.Revisions.V14.Composers.Alerts;
using Karen.Revisions.V14.Composers.Handshake;
using Karen.Revisions.V14.Composers.Player;
using Karen.Revisions.V14.Parsers.Handshake;
using Microsoft.Extensions.DependencyInjection;

namespace Karen.Revisions.V14;
public static class DependencyInjection {
    public static void AddV14( this IServiceCollection services ) {
        _ = services.AddTransient<IParser, TryLoginParser>()

                    .AddTransient<IComposer<HelloMessage>, HelloComposer>()
                    .AddTransient<IComposer<AvailableSetsMessage>, AvailableSetsComposer>()
                    .AddTransient<IComposer<AlertMessage>, AlertComposer>()
                    .AddTransient<IComposer<CryptoParametersMessage>, CryptoParametersComposer>()
                    .AddTransient<IComposer<LoginMessage>, LoginComposer>()
                    .AddTransient<IComposer<SessionParametersMessage>, SessionParametersComposer>()
                    .AddTransient<IComposer<CreditsBalanceMessage>, CreditBalanceComposer>()
                    .AddTransient<IComposer<UserObjectMessage>, UserObjectComposer>();
    }
}
