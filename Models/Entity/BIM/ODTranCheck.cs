using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    /// <summary>
    /// 转工单校验对照表
    /// </summary>
    public class ODTranCheck
    {

        public int ID { get; set; }
        public string OrderBegin { get; set; }
        public string CodeRuleBegin { get; set; }
        public string OrderAfter { get; set; }
        public string CodeRuleAfter { get; set; }
        public DateTime? CreateTime { get; set; }
        public long CreateByID { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public long ModifyByID { get; set; }
        public string ModifyBy { get; set; }
        public string Remark { get; set; }

        public string  returnMessage{ get; set; }
    }
}
