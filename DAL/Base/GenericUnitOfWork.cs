using DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    /// <summary>
    /// POWERED BY Abbas MohammadNezhad
    /// <para>
    /// email: abbas.mn1973@gmail.com
    /// </para>
    /// </summary>
    public class UnitOfWork<TEntity> : UnitOfWork, IUnitOfWork<TEntity> where TEntity : class
    {
        public UnitOfWork(DbContext context) : base(context)
        {
        }

        private Repository<TEntity> _entities;

        public IRepository<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = new Repository<TEntity>(Context);
                return _entities;
            }
        }

    }


}
