//using Antlr.Runtime.Misc;
using MD.PersianDateTime;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
//using System.Web.Mvc;
//using System.Web.Routing;

namespace Utilities.Extentions
{
    public static class ExtentionMethods
    {

        /// <summary>
        /// آیا فایل آپلود شده اکسل است؟
        /// </summary>
        /// <param name="file">فایل</param>
        /// <returns></returns>
        public static bool IsExcel(this IFormFile file)
        {
            if (file == null) return false;
            var extArr = new List<string>() { ".xlsx", ".xls" };
            string ThExt = Path.GetExtension(file.FileName).ToLower();
            return extArr.Contains(ThExt);
        }


        /// <summary>
        /// گرفتن پسوند فایل
        /// </summary>
        /// <param name="file">فایل</param>
        /// <returns></returns>
        public static string GetExtention(this IFormFile file)
        {
            return Path.GetExtension(file.FileName);
        }


        public static string GetUrlFriendly(this string word)
        {
            if (word == null) return null;
            return word.Replace("  ", " ")
                        .Replace(" ", "-")
                        .Replace("_", "-")
                        .Replace("%", "-")
                        .Replace(":", "-")
                        .Replace("?", "")
                        .Replace(";", "-")
                        .Replace("*", "-")
                        .Replace("=", "-")
                        .Replace("^", "-")
                        .Replace("#", "-")
                        .Replace("/", "-")
                        .Replace(".", "-")
                        .Replace("\"", "-")
                        .Replace("\'", "-")
                        .Replace("---", "-")
                        .Replace("--", "-");
        }


        /// <summary>
        /// گرفتن تاریخ در قالب ابجکت تاریخ شمسی
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static PersianDateTime ToPersianDateTime(this DateTime Date)
        {
            var pd = new PersianDateTime(Date) { EnglishNumber = true };
            pd.EnglishNumber = true;
            return pd;
        }


        /// <summary>
        /// گرفتن تاریخ در قالب ابجکت تاریخ شمسی
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static PersianDateTime? ToPersianDateTime(this DateTime? Date)
        {
            if (Date == null)
                return null;
            var pd = new PersianDateTime(Date);
            pd.EnglishNumber = true;
            return pd;
        }


        /// <summary>
        /// آیا یک کلاس مشخص، پروپرتی با نام مشخص دارد؟
        /// typeof(MyClass).HasProperty("propname");
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool HasProperty(this Type obj, string propertyName)
        {
            return obj.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
        }




        /// <summary>
        /// گرفتن یک نام فارسی از Description یک enum
        /// get userfriendly name from Description attr of enum 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        
        /// <summary>
        /// نحوه استفاده 
        /// ExtentionMethods.ToEnumViewModel<EnumName>()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumViewModel> ToEnumViewModel<T> ()
        {
            var model = Enum.GetValues(typeof(T)).Cast<int>()
                .Select(id => new EnumViewModel
                {
                    Id = id,
                    Key = Enum.GetName(typeof(T), id),
                    Title = ((Enum)Enum.Parse(typeof(T), Enum.GetName(typeof(T), id), true)).GetEnumDescription()
                }).ToList();
            return model;
        }



        
    }



    /// <summary>
    /// مدل برای تبدیل enum به کلاس
    /// </summary>
    public class EnumViewModel
    {
        public int? Id { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
    }






    public static class JavascriptScripts
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// اضافه کردن پراپرتی به آبجک داینامیک سی شارپ
        /// </summary>
        /// <param name="expando">آبجکت</param>
        /// <param name="propertyName">نام پراپرتی</param>
        /// <param name="propertyValue">مقدار مورد نظر</param>
        public static void AddProperty(this ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
    }

}