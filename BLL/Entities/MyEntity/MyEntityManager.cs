using BLL.Interface;
using Domain.Entities;
using DTO.DataTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using DTO.MyEntity;
using DTO.Base;
using Utilities.Extentions;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class MyEntityManager : Manager<MyEntity>, IMyEntityManager
    {
        public MyEntityManager(DbContext _Context) : base(_Context)
        {
        }


        /// <summary>
        /// آپلود فایل اکسل
        /// </summary>
        /// <param name="file">فایل اکسل</param>
        /// <returns></returns>
        public BaseResult ImportExcel(IFormFile file)
        {

            try
            {
                #region بررسی فایل اکسل
                if (file == null)
                    return new BaseResult(false, "فایل مورد نظر را آپلود کنید.");

                if (!file.IsExcel())
                    return new BaseResult(false, "تنها بارگذاری فایل اکسل مجاز است.");
                #endregion


                #region تبدیل داده درون اکسل به لیستی از انتیتی و افزودن به کانتکست
                var ReportGenerator = new DynamicReportGenerator<MyEntityExcelDTO>();
                var res = ReportGenerator.ImportExceltoDatatable(file);
                if (!res.Status) return res;
                var dt = res.Model as DataTable;
                var model = dt.Select("NOT(Title IS NULL OR Title='')").Select(dr => new MyEntity
                {
                    Title = dr.IsNull("Title") ? null : Convert.ToString(dr["Title"])
                }).ToList();
                #endregion

                var IsSuccess = UOW.MyEntities.BulkInsert(model);

                if (IsSuccess)
                {
                    var count = model.Count();
                    return new BaseResult 
                    { 
                        Status = true, 
                        Message = "تعداد " + count + " رکورد با موفقیت ذخیره شد.", 
                        Model = count 
                    };
                }
                else
                    return new BaseResult { Status = false, Message = "درج اطلاعات با خطا همراه بوده است!" };
            }
            catch (Exception e)
            {
                return new BaseResult { Status = false, Message = "درج اطلاعات با خطا همراه بوده است! </br> Error: " + e.Message };
            }
        }


    }
}
