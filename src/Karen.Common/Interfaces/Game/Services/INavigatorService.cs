using Karen.Common.Dto;

namespace Karen.Common.Interfaces.Game.Services;
public interface INavigatorService {
    Task<NavigatorCategory?> GetCategory( int id );
    Task<IEnumerable<NavigatorCategory>> GetCategoriesByParentId( int parent_id );
    Task<IEnumerable<NavigatorNode>> GetNavigatorNodesByCategoryId( int category_id );
}
