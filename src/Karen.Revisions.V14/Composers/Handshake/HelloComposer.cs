
namespace Karen.Revisions.V14.Composers.Handshake;
public class HelloComposer : ComposerBase {
    public override short Header => 0;

    protected override Task ComposeAsync() {
        return Task.CompletedTask;
    }
}
