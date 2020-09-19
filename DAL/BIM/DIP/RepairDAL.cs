using Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepairDAL
    {
        public static readonly string conn = ConfigurationManager.ConnectionStrings["PY_SQLCONNECT"].ConnectionString;
        /// <summary>
        /// 操作记录
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        public bool WriteLog(TranRepair tr, string createby, int Model)
        {

            string sql;
            sql = string.Format("INSERT INTO TranRepairHistory 	" +
                "(ProductCode_his,AssemblyCode_his,DIPCode_his,SMTCode_his,SNPrefix_his,CreateBy,Remark,Model,CreateTime) " +
                "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}',{7} ,GETDATE())",
                tr.ProductCode, tr.AssemblyCode, tr.DIPCode,
                tr.SMTCode, tr.SNPrefix, createby, tr.Remark, Model);
            return DBhelper.ExcuteSql(sql, conn);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        public bool Create(TranRepair tr)
        {
            string sql;
            sql = string.Format("INSERT INTO TranRepair " +
                "	(ProductCode,AssemblyCode,DIPCode,SMTCode,SNPrefix,Remark,CreateBy,CreateTime)" +
                " VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())",
                tr.ProductCode, tr.AssemblyCode, tr.DIPCode,
                tr.SMTCode, tr.SNPrefix, tr.Remark, tr.CreateBy);
            return DBhelper.ExcuteSql(sql, conn);
        }


        /// <summary>
        /// 新增时验证数据是否存在
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        public bool IsCheckData(TranRepair tr) {
            string sql;
            sql = string.Format("SELECT  * FROM dbo.TranRepair  WHERE  DIPCode='{0}' AND SMTCode='{1}'",
                tr.DIPCode,tr.SMTCode);
            DataTable dt = new DataTable();
            dt = DBhelper.GetDataTableBySql(sql, conn);
            List<TranRepair> li = new List<TranRepair>();
            li = DBhelper.ToDataList<TranRepair>(dt);
            if (li.Count >= 1)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TranRepair GetDataById(int Id)
        {
            TranRepair tr = new TranRepair();
            string sql;
            try
            {
                sql = string.Format("SELECT  * FROM dbo.TranRepair  WHERE   ID={0}", Id);
                DataTable dt = new DataTable();
                dt = DBhelper.GetDataTableBySql(sql, conn);
                tr = DBhelper.ToEntity<TranRepair>(dt);
                return tr;
            }
            catch (Exception)
            {
                return null;
            }

        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        public bool Update(TranRepair tr)
        {
            string sql;
            sql = string.Format("UPDATE TranRepair  SET " +
            "ProductCode='{0}',AssemblyCode='{1}',DIPCode='{2}',SMTCode='{3}',SNPrefix='{4}'," +
            "Remark='{5}',ModifyBy='{6}',ModifyTime=GETDATE() WHERE ID={7}",
            tr.ProductCode, tr.AssemblyCode, tr.DIPCode, tr.SMTCode,
            tr.SNPrefix, tr.Remark, tr.ModifyBy, tr.ID);
            return DBhelper.ExcuteSql(sql, conn);
        }


        public bool DeleteById(int Id)
        {
            string sql;
            sql = string.Format("DELETE FROM  TranRepair WHERE ID={0}", Id);
            if (!DBhelper.ExcuteSql(sql, conn))
            {
                return false;
            }
            return true;

        }
    }
}
