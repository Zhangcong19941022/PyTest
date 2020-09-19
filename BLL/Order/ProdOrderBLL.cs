using DAL;
using Models;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProdOrderBLL
    {
      
        /// <summary>
        /// 获取工单信息
        /// </summary>
        /// <returns></returns>
        public static ProdOrderList GetVOrderNoLine(string orderNo,int cPage,int pSize,string connstring)
        {
            return DAL.ProdOrderDAL.GetVOrderNoLine(orderNo,cPage, pSize, connstring);
        }

        public static bool CreateProgaramData(ProdOrderForProgram pro,string connstring) {
            return DAL.ProdOrderDAL.CreateProgaramData(pro, connstring);
        }

        public static bool UpdateProgaramData(ProdOrderForProgram pro,string connstring)
        {
            return DAL.ProdOrderDAL.UpdateProgaramData(pro, connstring);
        }
        
        public static bool CreateProgaramDataHistory(ProdOrderForProgramHistory proHis,string connstring)
        {
            return DAL.ProdOrderDAL.CreateProgaramDataHistory(proHis, connstring);
        }


        public static List<ProdOrderForProgram> GetOrder(string orderNo,string connstring) {
            return DAL.ProdOrderDAL.GetOrder(orderNo, connstring);
        }

        /// <summary>
        /// 不良采集验证SN和程序名
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static vwProdSNForPro GetOrderFromSN(string SN) {
            return DAL.ProdOrderDAL.GetOrderFromSN(SN); 
        }

        public static ProdOrderList GetOrderHistory(string orderNo, int cPage , int pSize, string connstring)
        {
            return DAL.ProdOrderDAL.GetOrderHistory(orderNo, cPage, pSize,connstring);
        }
    }
}
