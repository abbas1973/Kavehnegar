using ClosedXML.Excel;
using DTO.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BLL
{
    /// <summary>
    /// گرفتن خروجی اکسل از مدل مربوطه
    /// و یا خواندن دیتا از فایل اکسل
    /// </summary>
    public class DynamicReportGenerator<T> where T : class
    {
        /// <summary>
        /// گرفتن خروجی دیتاتیبل از فایل اکسل و تبدیل به لیستی از آبجکتا 
        /// </summary>
        /// <param name="filePath">آدرس فایل اکسل</param>
        /// <returns></returns>
        public BaseResult ImportExceltoDatatable(IFormFile file)
        {
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);

                // Open the Excel file using ClosedXML.
                using (XLWorkbook workBook = new XLWorkbook(stream))
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(1);

                    //Create a new DataTable.
                    DataTable dt = new DataTable();

                    //Get all the properties
                    PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (PropertyInfo prop in Props)
                    {
                        //Defining type of data column gives proper data table 
                        var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                        //Setting column names as Property names
                        string coulmnName = prop.Name;
                        dt.Columns.Add(coulmnName);
                    }

                    if (workSheet.ColumnsUsed().Count() > dt.Columns.Count)
                        return new BaseResult(false, "فایل اکسل باید حاوی تنها " + dt.Columns.Count + " ستون داده باشد!");

                    //Loop through the Worksheet rows.
                    var rows = workSheet.RowsUsed();
                    foreach (IXLRow row in rows)
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;

                        foreach (IXLCell cell in row.Cells(row.FirstCellUsed().Address.ColumnNumber, row.LastCellUsed().Address.ColumnNumber))
                        {
                            string val = null;
                            if (cell.HasFormula)
                                val = cell.CachedValue?.ToString();
                            else
                                val = cell.Value?.ToString();

                            dt.Rows[dt.Rows.Count - 1][i] = string.IsNullOrEmpty(val) ? null : val;// cell.GetValue<type>();
                            i++;
                        }
                    }

                    return new BaseResult
                    {
                        Status = true,
                        Model = dt
                    };
                }
            }
        }





    }



    public class PropertyViewModel
    {
        /// <summary>
        /// عنوان انگلیسی پروپرتی
        /// </summary>
        public string TitleEn { get; set; }

        /// <summary>
        /// عنوان فارسی پروپرتی
        /// </summary>
        public string TitleFa { get; set; }
    }

}
