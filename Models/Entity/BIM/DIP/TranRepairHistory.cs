using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    /// <summary>
    /// DIP转工单对照历史记录表
    /// </summary>
    public class TranRepairHistory
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string ProductCode_his { get; set; }
        /// <summary>
        /// 组装编码
        /// </summary>
        public string AssemblyCode_his { get; set; }
        /// <summary>
        /// 插件编码
        /// </summary>
        public string DIPCode_his { get; set; }
        /// <summary>
        /// 贴片编码
        /// </summary>
        public string SMTCode_his { get; set; }
        /// <summary>
        /// SN前缀
        /// </summary>
        public string SNPrefix_his { get; set; }
        /// <summary>
        /// SN后缀
        /// </summary>
        public string SNSuffix_his { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 模式
        /// </summary>
        public int Model { get; set; }

    }
}
