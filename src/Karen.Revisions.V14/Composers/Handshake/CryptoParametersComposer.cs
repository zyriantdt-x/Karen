
namespace Karen.Revisions.V14.Composers.Handshake;
public class CryptoParametersComposer : ComposerBase {
    public override short Header => 277;

    protected override async Task ComposeAsync() {
        await this.Write( 0 );
    }
}
