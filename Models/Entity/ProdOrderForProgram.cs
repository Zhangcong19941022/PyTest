using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    public class ProdOrderForProgram
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 工单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 程序包名称
        /// </summary>
        public string BaraName { get; set; }
        /// <summary>
        /// 程序包上传地址
        /// </summary>
        public string BaraPath { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 上传人
        /// </summary>
        public string CreateBy { get; set; }
    }
}
