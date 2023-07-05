namespace spacebattleservice;
public class PoolGuard<T> : IDisposable where T : new()
{
    private readonly Pool<T> pool;
    private readonly T objct;
    public PoolGuard(Pool<T> pool)
    {
        objct = pool.Take();
        this.pool = pool;
    }

    public void Dispose()
    {
        pool.Release(objct);
    }
    public T Object => objct;
}