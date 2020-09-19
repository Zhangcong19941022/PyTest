using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 视图vwBaraForOrder
    /// </summary>
    public class vwBaraForOrder
    {
        /// <summary>
        /// 工单ID
        /// </summary>
        public int ProdOrderID { get; set; }
        /// <summary>
        /// 工单号
        /// </summary>
        public string OrderNO { get; set; }
        /// <summary>
        /// 工单类型（1:normal 2:RMA 3:Rework 4:委托加工 5:受托加工 6:重复生产）
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 工单状态（Releasable=1,Hold=2,Done=3,Closed=4）
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// 物料BOMID
        /// </summary>
        public int BOMID { get; set; }
        /// <summary>
        /// 路由ID
        /// </summary>
        public int RouterId { get; set; }
        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// 客户订单
        /// </summary>
        public string CustomerOrder { get; set; }
        /// <summary>
        /// 客户订单数量
        /// </summary>
        public int CustomerOrderQty { get; set; }
        /// <summary>
        /// 工单数量
        /// </summary>
        public int Qty_to_Build { get; set; }
        /// <summary>
        /// 工单已释放数量
        /// </summary>
        public int Qty_Released { get; set; }
        /// <summary>
        /// 工单已完成数量
        /// </summary>
        public int Qty_Done { get; set; }
        /// <summary>
        /// 工单报废数量
        /// </summary>
        public int Qty_Scrapped { get; set; }
        /// <summary>
        /// 工单释放日期
        /// </summary>
        public DateTime? Release_date { get; set; }
        /// <summary>
        /// 工单计划开始时间
        /// </summary>
        public DateTime? Planned_Start_Time { get; set; }
        /// <summary>
        /// 工单计划完成时间
        /// </summary>
        public DateTime? Planned_Completed_Date { get; set; }
        /// <summary>
        /// 工单排产开始时间
        /// </summary>
        public DateTime? Scheduled_Start_Date { get; set; }
        /// <summary>
        /// 工单计划开始日期（年：月：日）
        /// </summary>
        public string PlanStart { get; set; }
        /// <summary>
        /// 工单计划完成日期（年：月：日）
        /// </summary>
        public string PlanFinish { get; set; }
        /// <summary>
        /// 工单排产结束时间
        /// </summary>
        public DateTime? Scheduled_Completed_Time { get; set; }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? Actual_Start_Date { get; set; }
        /// <summary>
        /// 实际完成时间
        /// </summary>
        public DateTime? Actual_Completed_Date { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifyBy { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 产品版本
        /// </summary>
        public string ItemRev { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        public string R_Name { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 工单已排程到线上的数量
        /// </summary>
        public int Qty_to_Line { get; set; }
        /// <summary>
        /// 工厂代码
        /// </summary>
        public string Site { get; set; }
        /// <summary>
        /// 已生成的包装箱数量
        /// </summary>
        public int Qty_GenerateBoxNO { get; set; }
        /// <summary>
        /// 生成的拼板数
        /// </summary>
        public int GeneratedPanelQty { get; set; }
        /// <summary>
        /// 置换条码数量
        /// </summary>
        public int Qty_ReplaceSN { get; set; }
        /// <summary>
        /// 是否MES新增的工单 1是
        /// </summary>
        public int IsMESadd { get; set; }
        /// <summary>
        /// 工单来源方式
        /// </summary>
        public string IsMESaddDesc { get; set; }
        /// <summary>
        /// 中文描述
        /// </summary>
        public string OrderTypeName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string StatusDesc { get; set; }
        /// <summary>
        /// 产品规格
        /// </summary>
        public string ItemSpec { get; set; }
        /// <summary>
        /// 程序包名称
        /// </summary>
        public string BaraName { get; set; }
        /// <summary>
        /// 程序包地址
        /// </summary>
        public string BaraPath { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? BaraTime { get; set; }
    }
}
