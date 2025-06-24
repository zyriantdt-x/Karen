using Karen.Common.Protocol;

namespace Karen.Revisions.V14.Composers.Alerts;
public class AlertComposer : ComposerBase {
    public override short Header => 139;

    public required string Message { get; set; }

    protected override void Compose() {
        this.Write( this.Message );
    }
}
