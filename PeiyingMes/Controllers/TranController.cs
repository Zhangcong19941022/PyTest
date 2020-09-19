using BLL;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PeiyingMes.Controllers
{
    [RoutePrefix("api/Tran")]
    public class TranController : ApiController
    {
        Lazy<ODTranCheckBLL> od = new Lazy<ODTranCheckBLL>();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public string Create(ODTranCheck entity)
        {
            if (string.IsNullOrEmpty(entity.OrderBegin))
            {
                return "工单号不能为空!";
            }
            if (string.IsNullOrEmpty(entity.CodeRuleBegin))
            {
                return "工单编码规则不能为空!";
            }
            if (!od.Value.GetDataExists(entity.OrderBegin))
            {
                return "工单数据已存在!";
            }

            if (!od.Value.Create(entity))
            {
                return "保存失败!";
            }
            return "success";
        }


        [HttpPost]
        [Route("Update")]
        public string Update(ODTranCheck entity)
        {
            if (string.IsNullOrEmpty(entity.OrderBegin))
            {
                return "工单号不能为空!";
            }
            if (string.IsNullOrEmpty(entity.CodeRuleBegin))
            {
                return "工单编码规则不能为空!";
            }
            if (!od.Value.GetDataExistsById(entity.ID))
            {
                return "工单数据不存在!";
            }
            if (!od.Value.Update(entity))
            {
                return "修改数据失败!";
            }

            return "success";
        }


        [HttpPost]
        [Route("DeleteById")]
        public string DeleteById(int Id)
        {
            if (Id < 0)
            {
                return "无法操作，请选择数据！";
            }
            List<ODTranCheck> li = new List<ODTranCheck>();
            li = od.Value.GetDataById(Id);
            if (li.Count < 1)
            {
                return "暂无数据！";
            }
            else if (li.Count > 1)
            {
                return "工单数据数量超过限制！";
            }
            else
            {
                od.Value.DeleteById(Id);
                return "success";
            }
        }


        [HttpPost]
        [Route("GetDataById")]
        public ODTranCheck GetDataById(int Id)
        {
            ODTranCheck OT = new ODTranCheck();
            if (Id < 0)
            {
                OT.returnMessage = "无法操作，请选择数据！";
                return OT;
            }

            List<ODTranCheck> li = new List<ODTranCheck>();
            li = od.Value.GetDataById(Id);
            if (li.Count < 1)
            {
                OT.returnMessage = "暂无数据";
                return OT;
            }
            else if (li.Count > 1)
            {
                OT.returnMessage = "工单数据数量超过限制！";
                return OT;
            }
            else
            {
                li[0].returnMessage = "success";
                return li[0];
             
            }
        }
    }
}
