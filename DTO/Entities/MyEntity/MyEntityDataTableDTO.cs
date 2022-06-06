using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Utilities.Extentions;

namespace DTO.MyEntity
{
    /// <summary>
    /// لیست جهت نمایش
    /// </summary>
    public class MyEntityDataTableDTO
    {

        [Display(Name = "شناسه")]
        public int Id { get; set; }


        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public string CreateDateFa { get { return CreateDate.ToPersianDateTime().ToString(); } }


        /// <summary>
        /// فیلدهای لازم برای استخراج مدل از موجودیت مربوطه
        /// </summary>
        public static Expression<Func<Domain.Entities.MyEntity, MyEntityDataTableDTO>> Selector
        {
            get
            {
                return model => new MyEntityDataTableDTO()
                {
                    Id = model.Id,
                    Title = model.Title,
                    CreateDate = model.CreateDate
                };
            }
        }
    }
}
