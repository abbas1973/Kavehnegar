using System;

namespace DAL.Interface
{
    /// <summary>
    /// POWERED BY Abbas MohammadNezhad
    /// <para>
    /// email: abbas.mn1973@gmail.com
    /// </para>
    /// </summary>
    public interface IUnitOfWork<TEntity> : IUnitOfWork, IDisposable where TEntity : class
    {
        IRepository<TEntity> Entities { get; }

    }
}
