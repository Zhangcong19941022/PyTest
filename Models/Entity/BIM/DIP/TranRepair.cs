using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    /// <summary>
    /// DIP转工单对照表
    /// </summary>
    public class TranRepair
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int  ID { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string  ProductCode  { get; set; }
        /// <summary>
        /// 组装编码
        /// </summary>
        public string  AssemblyCode  { get; set; }
        /// <summary>
        /// 插件编码
        /// </summary>
        public string  DIPCode { get; set; }
        /// <summary>
        /// 贴片编码
        /// </summary>
        public string  SMTCode { get; set; }
        /// <summary>
        /// SN前缀
        /// </summary>
        public string  SNPrefix { get; set; }
        /// <summary>
        /// SN后缀
        /// </summary>
        public string  SNSuffix { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime?   CreateTime  { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string  CreateBy { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime?   ModifyTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string  ModifyBy { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string  Remark { get; set; }
        /// <summary>
        /// 返回前端信息
        /// </summary>
        public bool returnMessage { get; set; }
    }
}
