namespace Karen.Server.Messaging;

public class ComposerFactory : IComposerFactory { // this is such a horrendously ugly class and it keeps me up at night
    private readonly IServiceProvider sp; // ugh

    public ComposerFactory( IServiceProvider sp ) {
        this.sp = sp;
    }

    public IComposer<T> CreateComposer<T>() {
        return this.sp.GetRequiredService<IComposer<T>>();
    }
}
