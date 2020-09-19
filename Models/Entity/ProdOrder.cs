using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //工单表
   public class ProdOrder
    {
       public int ProdOrderID { get; set; }
        public string OrderNO { get; set; }
        public int OrderType { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public int ItemId { get; set; }
        public int BOMId { get; set; }
        public int PrivacyBOMFlag { get; set; }
        public int PrivacyItemParamFlag { get; set; }
        public int PrivacyOpeParamFlag { get; set; }
        public int RouterId { get; set; }
        public int CustomerID { get; set; }
        public string CustomerOrder { get; set; }
        public int CustomerOrderQty { get; set; }
        public int Qty_to_Line { get; set; }
        public int Qty_to_Build { get; set; }
        public int Qty_Released { get; set; }
        public int Qty_Done { get; set; }
        public int Qty_Scrapped { get; set; }
        public DateTime Release_date { get; set; }
        public DateTime Planned_Start_Time { get; set; }
        public DateTime Planned_Completed_Date { get; set; }
        public DateTime Scheduled_Start_Date { get; set; }
        public DateTime Scheduled_Completed_Time { get; set; }
        public DateTime Actual_Start_Date { get; set; }
        public DateTime Actual_Completed_Date { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyTime { get; set; }
        public string Site { get; set; }
        public int Qty_GenerateBoxNO { get; set; }
        public int GeneratedPanelQty { get; set; }
        public int Qty_ReplaceSN { get; set; }
        public int IsMESadd { get; set; }
        public int SourceTranType { get; set; }
        public int SourceInterId { get; set; }
        public string SourceBillNo { get; set; }
        public int ERPMOID { get; set; }
        public int ERPStatus { get; set; }
        public int ERPMOType { get; set; }
        public int MaskId { get; set; }
        public int Qty_Input { get; set; }



    }
}
