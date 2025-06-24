using Karen.Common.Dto;

namespace Karen.Common.Interfaces.Game.Services;
public interface INavigatorService {
    Task<NavigatorCategory?> GetCategory( int id );
}
