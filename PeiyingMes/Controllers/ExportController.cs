using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PeiyingMes.Controllers
{
    [RoutePrefix("api/Export")]
    public class ExportController : ApiController
    {
        /// <summary>
        /// 导入
        /// </summary>
        [HttpPost]
        [Route("ExportUpLoad")]
        public  void ExportUpLoad()
        {
            BLL.ExportBLL.ExportUpLoad();
        }
    }
}
