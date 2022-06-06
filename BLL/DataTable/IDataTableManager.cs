using Domain.Entities;
using DTO.Base;
using DTO.DataTable;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IDataTableManager
    {
        /// <summary>
        /// گرفتن مدل لازم برای سرچ در دیتاتیبل
        /// </summary>
        DataTableSearchDTO GetSearchModel();

    }
}
