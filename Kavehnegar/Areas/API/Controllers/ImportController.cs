using BLL.Interface;
using DTO.Base;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Kavehnegar.Areas.API.Controllers
{
    /// <summary>
    /// ایمپورت دیتا با فایل اکسل
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Description("آپلود فایل اکسل")]
    public class ImportController : ControllerBase
    {
        private readonly IMyEntityManager myEntityManager;
        public ImportController(IMyEntityManager _myEntityManager)
        {
            myEntityManager = _myEntityManager;
        }


        /// <summary>
        /// آپلود فایل اکسل
        /// </summary>
        /// <param name="file">
        /// فایل اکسل با پسوند xlsx یا xls
        /// </param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BaseResult), 200)]
        public ActionResult<BaseResult> Excel(IFormFile file)
        {
            var res = myEntityManager.ImportExcel(file);
            return Ok(res);
        }
    }
}
