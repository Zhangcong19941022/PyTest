using BLL;
using Models.Entity;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PeiyingMes.Controllers
{
    /// <summary>
    /// DIP转工单
    /// </summary>
    [RoutePrefix("api/Repair")]
    public class RepairController : ApiController
    {

        Lazy<RepairBLL> re = new Lazy<RepairBLL>();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public string Create(TranRepair tr)
        {
            return re.Value.Create(tr);
        }


        /// <summary>
        ///  根据Id查询数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetDataById")]
        public TranRepair GetDataById(int Id)
        {
            return re.Value.GetDataById(Id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public string Update(TranRepair tr)
        {
            return re.Value.Update(tr);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteById")]
        public string DeleteById(int  Id) 
        {
            return re.Value.DeleteById(Id);
        }
    }
}
