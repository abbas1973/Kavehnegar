using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DAL
{

    /// <summary>
    /// POWERED BY Abbas MohammadNezhad
    /// <para>
    /// email: abbas.mn1973@gmail.com
    /// </para>
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context)
        {
            Context = context;
        }


        #region private properties 
        protected readonly DbContext Context;

        #region Entities
        private MyEntityRepository _MyEntities;
        #endregion


        #endregion






        #region Repository Getters 

        #region Entities
        public IMyEntityRepository MyEntities
        {
            get
            {
                if (_MyEntities == null)
                    _MyEntities = new MyEntityRepository(Context);
                return _MyEntities;
            }
        }

        #endregion


        #endregion




        #region Commit
        /// <summary>
        /// ذخیره تغییرات انجام شده
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            //try
            //{
            Context.SaveChanges();
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }



        /// <summary>
        /// ذخیره تغییرات انجام شده
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CommitAsync()
        {
            //try
            //{
            await Context.SaveChangesAsync();
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
        #endregion





        #region ExecuteNonQuery

        /// <summary>
        /// اجرای یک کوئری بدون مقدار بازگشتی
        /// </summary>
        /// <param name="Query">متن کوئری</param>
        /// <param name="Parameters">پارامتر های کوئری</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(string Query, params object[] Parameters)
        {
            try
            {
                int NumberOfRowEffected = Context.Database.ExecuteSqlRaw(Query, Parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        /// <summary>
        /// اجرای یک کوئری بدون مقدار بازگشتی
        /// </summary>
        /// <param name="Query">متن کوئری</param>
        /// <param name="Parameters">پارامتر های کوئری</param>
        /// <returns></returns>
        public async Task<bool> ExecuteNonQueryAsync(string Query, params object[] Parameters)
        {
            try
            {
                int NumberOfRowEffected = await Context.Database.ExecuteSqlRawAsync(Query, Parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion





        /// <summary>
        /// پاک کردن آبجکت unit of work و Context از رم
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }


    }
}
