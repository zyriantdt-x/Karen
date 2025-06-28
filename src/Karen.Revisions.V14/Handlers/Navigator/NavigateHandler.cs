using Karen.Common.Dto;
using Karen.Common.Interfaces;
using Karen.Common.Interfaces.Game.Services;
using Karen.Revisions.V14.Composers.Navigator;
using Karen.Revisions.V14.Messages.Navigator;

namespace Karen.Revisions.V14.Handlers.Navigator;
public class NavigateHandler : IHandler<NavigateMessage> {
    public short Header => 150;

    private readonly INavigatorService navigator;

    public NavigateHandler( INavigatorService navigator ) {
        this.navigator = navigator;
    }

    public async Task HandleAsync( IKarenClient client, NavigateMessage body ) {
        NavigatorCategory? category = await this.navigator.GetCategory( body.CategoryId );

        if( category is null )
            return;

        /*await client.SendAsync( new NavNodeInfoComposer() {
            ParentCategory = category,
            Subcategories = category.Subcategories,
            Nodes = category.Nodes,
            HideFull = body.HideFull
        } );*/
    }
}
