using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// موجودیت مورد نظر جهت ذخیره سازی دیتا
    /// </summary>
    public class MyEntity : EntityBase
    {
        /// <summary>
        /// دیتای خوانده شده از اکسل
        /// </summary>
        [Display(Name = "عنوان")]
        public string Title { get; set; }



        #region Constructor
        public MyEntity() : base()
        {
        } 
        #endregion

    }
}
