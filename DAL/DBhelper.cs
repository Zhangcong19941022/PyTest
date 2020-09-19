using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 访问数据库类
    /// </summary>
    public static class DBhelper
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECT"].ConnectionString;
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTableBySql(string sql, string connstring)
        {
            //数据库连接字符等于空的时候，选择默认的数据库连接字符
            if (connstring == "")
            {
                connstring = connectionString;
            }
            DataTable dt = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(dt);
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        /// <summary>
        /// 增、删、改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool ExcuteSql(string sql,string connstring)
        {
            if (connstring == "")
            {
                connstring = connectionString;
            }
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand com = new SqlCommand(sql, conn);
            try
            {
                com.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// DataTable转换成List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToDataList<T>(this DataTable dt)
        {
            var list = new List<T>();
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            foreach (DataRow item in dt.Rows)
            {
                T s = Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                    if (info != null)
                    {
                        try
                        {
                            if (!Convert.IsDBNull(item[i]))
                            {
                                object v = null;
                                if (info.PropertyType.ToString().Contains("System.Nullable"))
                                {
                                    v = Convert.ChangeType(item[i], Nullable.GetUnderlyingType(info.PropertyType));
                                }
                                else
                                {
                                    v = Convert.ChangeType(item[i], info.PropertyType);
                                }
                                info.SetValue(s, v, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                        }
                    }
                }
                list.Add(s);
            }
            return list;
        }

        /// <summary>
        /// DataTable转成Dto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T ToDataDto<T>(this DataTable dt)
        {
            T s = Activator.CreateInstance<T>();
            if (dt == null || dt.Rows.Count == 0)
            {
                return s;
            }
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                if (info != null)
                {
                    try
                    {
                        if (!Convert.IsDBNull(dt.Rows[0][i]))
                        {
                            object v = null;
                            if (info.PropertyType.ToString().Contains("System.Nullable"))
                            {
                                v = Convert.ChangeType(dt.Rows[0][i], Nullable.GetUnderlyingType(info.PropertyType));
                            }
                            else
                            {
                                v = Convert.ChangeType(dt.Rows[0][i], info.PropertyType);
                            }
                            info.SetValue(s, v, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                    }
                }
            }
            return s;
        }

        /// <summary>
        /// DataTable转成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this DataTable dt)
        {
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            //实体
            T entity = Activator.CreateInstance<T>();

            if (dt.Rows.Count != 1)
            {
                return entity;
            }
            DataRow item = dt.Rows[0];
            //给实体赋值
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                if (info != null)
                {
                    try
                    {
                        if (!Convert.IsDBNull(item[i]))
                        {
                            object v = null;
                            if (info.PropertyType.ToString().Contains("System.Nullable"))
                            {
                                v = Convert.ChangeType(item[i], Nullable.GetUnderlyingType(info.PropertyType));
                            }
                            else
                            {
                                v = Convert.ChangeType(item[i], info.PropertyType);
                            }
                            info.SetValue(entity, v, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public static DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)//PageIndex表示第几页，PageSize表示每页的记录数
        {
            if (PageIndex == 0)
                return dt;//0页代表每页数据，直接返回

            DataTable newdt = dt.Copy();
            newdt.Clear();//copy dt的框架

            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
                return newdt;//源数据记录数小于等于要显示的记录，直接返回dt

            if (rowend > dt.Rows.Count)
                rowend = dt.Rows.Count;
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }
            return newdt;
        }


    }
}
