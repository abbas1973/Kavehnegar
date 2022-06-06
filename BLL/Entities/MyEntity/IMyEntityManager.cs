using Domain.Entities;
using DTO.Base;
using DTO.DataTable;
using DTO.MyEntity;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IMyEntityManager : IManager<MyEntity>
    {

        /// <summary>
        /// آپلود فایل اکسل
        /// </summary>
        /// <param name="file">فایل اکسل</param>
        /// <returns></returns>
        BaseResult ImportExcel(IFormFile file);


    }
}
