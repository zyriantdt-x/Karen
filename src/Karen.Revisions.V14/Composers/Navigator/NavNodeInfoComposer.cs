using Karen.Common.Dto;
using Karen.Common.Enums;

namespace Karen.Revisions.V14.Composers.Navigator;
public class NavNodeInfoComposer : ComposerBase {
    public override short Header => 220;

    public required NavigatorCategory ParentCategory { get; set; }
    public required IEnumerable<NavigatorCategory> Subcategories { get; set; }
    public required ICollection<NavigatorNode> Nodes { get; set; }
    public required bool HideFull { get; set; }

    protected override void Compose() {
        this.Write( this.HideFull );
        this.Write( this.ParentCategory.Id );
        this.Write( this.ParentCategory.IsPublicSpace ? 0 : 2 );
        this.Write( this.ParentCategory.Name );
        this.Write( 50 ); // current
        this.Write( 100 ); // max
        this.Write( this.ParentCategory.ParentId );

        if( !this.ParentCategory.IsPublicSpace ) {
            this.Write( this.Nodes.Count );
        }

        foreach( NavigatorNode node in this.Nodes ) {
            if( node.IsPublicRoom ) { // public node
                int idx = 0;
                string desc = node.Description;

                if( desc.Contains( "/" ) ) {
                    string[] data = desc.Split( '/' );
                    desc = data[ 0 ];
                    idx = Convert.ToInt32( data[ 1 ] );
                }

                this.Write( node.Id + 1000 ); // public node port
                this.Write( 1 );
                this.Write( node.Name );
                this.Write( node.VisitorsNow );
                this.Write( node.VisitorsMax );
                this.Write( node.CategoryId );
                this.Write( desc );
                this.Write( node.Id );
                this.Write( idx );
                this.Write( node.Ccts ?? "" );
                this.Write( 0 );
                this.Write( 1 );
            } else {
                this.Write( node.Id );
                this.Write( node.Name );

                // todo: name show check
                this.Write( node.OwnerName );

                this.Write( node.AccessType switch {
                    AccessType.CLOSED => "closed",
                    AccessType.PASSWORD => "password",
                    _ => "open"
                } );
                this.Write( node.VisitorsNow );
                this.Write( node.VisitorsMax );
                this.Write( node.Description );
            }
        }

        foreach( NavigatorCategory subcategory in this.Subcategories ) {
            this.Write( subcategory.Id );
            this.Write( 0 );
            this.Write( subcategory.Name );
            this.Write( 100 ); // current visitors
            this.Write( 100 ); // max visitors
            this.Write( subcategory.ParentId );
        }
    }
}
