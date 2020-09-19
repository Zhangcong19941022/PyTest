using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public   class ProdOrderList
    {
        /// <summary>
        /// 状态 success成功
        /// </summary>
        public  string status { get; set; }

       /// <summary>
       /// 总条数
       /// </summary>
        public  int totals { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public   object data { get; set; }
    }
}
