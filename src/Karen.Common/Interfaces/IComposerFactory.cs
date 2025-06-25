namespace Karen.Common.Interfaces;
public interface IComposerFactory {
    IComposer<T> CreateComposer<T>();
}
