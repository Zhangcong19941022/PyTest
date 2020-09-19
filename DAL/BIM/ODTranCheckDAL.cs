using Microsoft.SqlServer.Server;
using Models.Entity;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class ODTranCheckDAL
    {
        public static readonly string conn = ConfigurationManager.ConnectionStrings["PY_SQLCONNECT"].ConnectionString;


        /// <summary>
        /// 新增工单和编码规则
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public  bool Create(ODTranCheck entity)
        {
            string sql;
            sql = string.Format("INSERT INTO dbo.OD_TranCheck (OrderBegin, CodeRuleBegin,  CreateTime, Remark,CreateBy )" +
                "VALUES(N'{0}', N'{1}', GETDATE(),  N'{2}', N'{3}' )", entity.OrderBegin, entity.CodeRuleBegin, entity.Remark,entity.CreateBy);
            if (!DBhelper.ExcuteSql(sql, conn))
            {
                return false;
            }
            return true;
        }



        /// <summary>
        /// 查询工单号是否重复，防止重复插入
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public  bool GetDataExists(string orderNo)
        {
            string sql;
            try
            {
                sql = string.Format("SELECT  COUNT(*) AS count FROM dbo.OD_TranCheck  WHERE OrderBegin ='{0}'", orderNo);
                DataTable dt = new DataTable();
                dt = DBhelper.GetDataTableBySql(sql, conn);

                object num = "";
                foreach (DataRow row in dt.Rows)
                {
                    num = row[0];
                }

                if (int.Parse(num.ToString()) != 0)
                {
                    return false;
                }
                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }

       
        }



        /// <summary>
        /// 查询工单号记录是否唯一
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool GetDataExistsById(int Id)
        {
            string sql;
            try
            {
                sql = string.Format("SELECT  COUNT(*) AS count FROM dbo.OD_TranCheck  WHERE ID ='{0}'", Id);
                DataTable dt = new DataTable();
                dt = DBhelper.GetDataTableBySql(sql, conn);

                object num = "";
                foreach (DataRow row in dt.Rows)
                {
                    num = row[0];
                }

                if (int.Parse(num.ToString()) != 1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(ODTranCheck entity)
        {
            string sql;
            sql = string.Format("UPDATE dbo.OD_TranCheck SET " +
                "OrderAfter = N'{0}', CodeRuleAfter = N'{1}',ModifyBy = N'{2}'," +
                " ModifyTime = GETDATE(), Remark = N'{3}' WHERE OrderBegin = N'{4}'",
                entity.OrderAfter, entity.CodeRuleAfter, entity.ModifyBy, entity.Remark, entity.OrderBegin);

            if (!DBhelper.ExcuteSql(sql, conn)) {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 获取数据ByID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ODTranCheck> GetDataById(int Id)
        {
            string sql;
            sql = string.Format("SELECT  *  FROM dbo.OD_TranCheck  WHERE ID={0}", Id);
            DataTable dt = new DataTable();
            dt = DBhelper.GetDataTableBySql(sql, conn);
            List<ODTranCheck> li = new List<ODTranCheck>();
           li=  DBhelper.ToDataList<ODTranCheck>(dt);
            return li;
        }


        /// <summary>
        /// 删除数据ById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteById(int Id)
        {
            string sql;
            sql = string.Format("DELETE  FROM dbo.OD_TranCheck  WHERE ID={0}", Id);
            return DBhelper.ExcuteSql(sql, conn);
        }

    }
}
