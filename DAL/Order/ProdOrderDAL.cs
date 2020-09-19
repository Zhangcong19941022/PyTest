using Models;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
  public  class ProdOrderDAL
    {
    
    
        /// <summary>
        /// 获取工单信息
        /// </summary>
        /// <returns></returns>
        public static ProdOrderList GetVOrderNoLine(string orderNo,int cPage,int pSize,string connstring) {
            ProdOrderList propOrder = new ProdOrderList();
            StringBuilder sb = new StringBuilder();
            try
            {
                string sql = "select  * from vwBaraForOrder";
                sb.Append(sql);
                if (!string.IsNullOrEmpty(orderNo))
                {
                    string squery = string.Format("  where OrderNo like '%{0}%'", orderNo);
                    sb.Append(squery);

                }

                DataTable dt = new DataTable();
                dt = DBhelper.GetDataTableBySql(sb.ToString(), connstring);
                //总条数
                int totals = dt.DefaultView.Count;
                //分页
                var dtPage = DBhelper.GetPagedTable(dt, cPage, pSize);

                List<vwBaraForOrder> order = DBhelper.ToDataList<vwBaraForOrder>(dtPage);

                propOrder.data = order;
                propOrder.status = "success";
                propOrder.totals = totals;
            }
            catch (Exception)
            {

                throw;
            }
           
            return propOrder;  
        }


       /// <summary>
       /// 将工单对应的程序包信息保存到数据库
       /// </summary>
       /// <param name="pro"></param>
       /// <returns></returns>
        public static bool CreateProgaramData(ProdOrderForProgram pro,string connstring)
        {
            string sql;
            sql = string.Format("INSERT	INTO Prod_OrderForProgram (OrderNo,BaraName,BaraPath,CreateTime,CreateBy) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')",
                pro.OrderNo, pro.BaraName, pro.BaraPath, pro.CreateTime, pro.CreateBy);
            bool result = DBhelper.ExcuteSql(sql, connstring);
            return result;
        }

        /// <summary>
        /// 修改工单和程序包的对应关系
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public static bool UpdateProgaramData(ProdOrderForProgram pro,string connstring)
        {
            string sql;
            sql = string.Format("Update Prod_OrderForProgram set BaraName='{0}',BaraPath='{1}',CreateTime='{2}',CreateBy='{3}'  WHERE OrderNo='{4}' ",
                 pro.BaraName, pro.BaraPath, pro.CreateTime, pro.CreateBy, pro.OrderNo);
            bool result = DBhelper.ExcuteSql(sql, connstring);
            return result;
        }


        /// <summary>
        /// 工单程序包历史
        /// </summary>
        /// <param name="proHis"></param>
        /// <returns></returns>
        public static bool CreateProgaramDataHistory(ProdOrderForProgramHistory proHis,string connstring)
        {
            string sql;
            sql = string.Format("INSERT	INTO Prod_OrderForProgramHistory (HisOrderNo,HisBaraName,HisBaraPath,CreateTime,CreateBy) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')",
                proHis.HisOrderNo, proHis.HisBaraName, proHis.HisBaraPath, proHis.CreateTime, proHis.CreateBy);
            bool result = DBhelper.ExcuteSql(sql, connstring);
            return result;
        }

        /// <summary>
        /// 获取工单程序列表
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public static List<ProdOrderForProgram> GetOrder(string orderNo,string connstring) {
            string sql = string.Format("select * from  Prod_OrderForProgram  where OrderNo='{0}'", orderNo);
            DataTable dt = new DataTable();
            dt= DBhelper.GetDataTableBySql(sql, connstring);
            List<ProdOrderForProgram> list = new List<ProdOrderForProgram>();
            list= DBhelper.ToDataList<ProdOrderForProgram>(dt);
            return list;
        }

        ///// <summary>
        ///// 用户登录验证
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <param name="passWord"></param>
        ///// <param name="connstring"></param>
        ///// <returns></returns>
        //public static bool IsLogin(string userName, string passWord, string connstring)
        //{
        //    string sql = "";
        //    DataTable dt = new DataTable();
        //    dt = DBhelper.GetDataTableBySql(sql, connstring);
        //    var list = DBhelper.ToDataList<>(dt);
        //    if (list.Count != 1) {
        //        return false;
        //    }
        //    return true;
        //}



        /// <summary>
        /// 不良采集验证SN和程序名
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static vwProdSNForPro GetOrderFromSN(string  SN)
        {
            string connstring = "";
            string sql = string.Format("SELECT a.UID AS ID, a.SN,b.OrderNO,c.BaraName,c.BaraPath FROM dbo.Prod_Unit  AS  a " +
                " INNER  JOIN  dbo.Prod_Order AS b  ON  a.ProdOrderID=b.ProdOrderID  " +
                "INNER JOIN PYMISTest.dbo.Prod_OrderForProgram AS c ON b.OrderNO = c.OrderNo  WHERE a.SN='{0}'  ORDER BY b.OrderNO",SN); ;
            DataTable dt = new DataTable();
            vwProdSNForPro ps = new vwProdSNForPro();
            dt = DBhelper.GetDataTableBySql(sql, connstring);
          ps= DBhelper.ToEntity<vwProdSNForPro>(dt);
            return ps;
        }


        /// <summary>
        /// 工单对应程序历史记录
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="connstring"></param>
        //public static List<ProdOrderForProgramHistory> GetOrderHistory(string orderNo, string connstring)
        //{
        //    List<ProdOrderForProgramHistory> his = new List<ProdOrderForProgramHistory>();
        //    StringBuilder sb = new StringBuilder();
        //    try
        //    {
        //        string sql = "SELECT * FROM dbo.Prod_OrderForProgramHistory";
        //        sb.Append(sql);
        //        if (!string.IsNullOrEmpty(orderNo))
        //        {
        //            string squery = string.Format("  where OrderNo like '%{0}%'", orderNo);
        //            sb.Append(squery);

        //        }

        //        DataTable dt = new DataTable();
        //        dt = DBhelper.GetDataTableBySql(sb.ToString(), connstring);
        //        his = DBhelper.ToDataList<ProdOrderForProgramHistory>(dt);

        //        //总条数
        //        // int totals = dt.DefaultView.Count;
        //        //分页
        //        //  var dtPage = DBhelper.GetPagedTable(dt);

        //        //  List<vwBaraForOrder> order = DBhelper.ToDataList<vwBaraForOrder>(dtPage);

        //        //his.data = order;
        //        //his.status = "success";
        //        // propOrder.totals = totals;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return his;

        //}

        public static ProdOrderList GetOrderHistory(string orderNo, int cPage , int pSize, string connstring)
        {
            ProdOrderList propOrder = new ProdOrderList();
            List<ProdOrderForProgramHistory> his = new List<ProdOrderForProgramHistory>();
            StringBuilder sb = new StringBuilder();
            try
            {
                string sql = "SELECT * FROM dbo.Prod_OrderForProgramHistory";
                sb.Append(sql);
                if (!string.IsNullOrEmpty(orderNo))
                {
                    string squery = string.Format("  where HisOrderNo like '%{0}%'", orderNo);
                    sb.Append(squery);

                }

                DataTable dt = new DataTable();
                dt = DBhelper.GetDataTableBySql(sb.ToString(), connstring);
                his = DBhelper.ToDataList<ProdOrderForProgramHistory>(dt);

                //总条数
                 int totals = dt.DefaultView.Count;
                //分页
                //  var dtPage = DBhelper.GetPagedTable(dt);

                //  List<vwBaraForOrder> order = DBhelper.ToDataList<vwBaraForOrder>(dtPage);

                propOrder.data = his;
                propOrder.status = "success";
                 propOrder.totals = totals;
            }
            catch (Exception)
            {

                throw;
            }

            return propOrder;

        }

    }
}
