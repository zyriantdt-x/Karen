using Karen.Game.Player;
using Microsoft.Extensions.DependencyInjection;

namespace Karen.Game;
public static class DependencyInjection {
    public static void AddGameServices( this IServiceCollection services ) {
        _ = services.AddSingleton<IPlayerDetailsService, PlayerDetailsService>()
                    .AddSingleton<IPlayerRepository, PlayerRepository>()
                    .AddSingleton<IPlayerAuthService, PlayerAuthService>();
    }
}
