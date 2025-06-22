namespace Karen.Revisions.V14.Composers.Player;
public class CreditBalanceComposer : ComposerBase {
    public override short Header => 6;

    public required int Credits { get; init; }

    protected override void Compose() {
        this.Write( this.Credits + ".0" );
    }
}