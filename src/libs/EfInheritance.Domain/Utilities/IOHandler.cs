namespace EfInheritance.Domain.Utilities;

public abstract class IOHandler<TResource> : IDisposable
    where TResource : class , IDisposable
{
    protected abstract string SecreteFileName { get; }
    protected abstract Task<TResource> ReadSecreteAsync();

    protected abstract string GetConnectionString(TResource secrete);

    public virtual async Task<string> GetConnectionStringFacadeAsync()
    {
        return GetConnectionString(await ReadSecreteAsync());
    }

    protected abstract void DisposeIoResources();

    public void Dispose()
    {
        DisposeIoResources();
    }
}