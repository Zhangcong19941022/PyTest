using DAL;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class RepairBLL
    {
        Lazy<RepairDAL> re = new Lazy<RepairDAL>();

        public string Create(TranRepair tr)
        {
            try
            {
                if (string.IsNullOrEmpty(tr.ProductCode))
                {
                    return "产品编码不能为空";
                }
                if (string.IsNullOrEmpty(tr.AssemblyCode))
                {
                    return "组装编码不能为空";
                }
                if (string.IsNullOrEmpty(tr.DIPCode))
                {
                    return "插件编码不能为空";
                }
                if (string.IsNullOrEmpty(tr.SMTCode))
                {
                    return "贴片编码不能为空";
                }
                if (string.IsNullOrEmpty(tr.SNPrefix))
                {
                    return "SN编码规则样例不能为空";
                }

                //删减前后空格
                tr.ProductCode = tr.ProductCode.Trim();
                tr.AssemblyCode = tr.AssemblyCode.Trim();
                tr.DIPCode = tr.DIPCode.Trim();
                tr.SMTCode = tr.SMTCode.Trim();
                tr.SNPrefix = tr.SNPrefix.Trim();
                tr.Remark = tr.Remark;

                ////删减前后单双引号
                //tr.ProductCode.IndexOf("\'");
                //tr.ProductCode.IndexOf("\"");

                /*  这是前端验证字符串中是否包含单双引号
                function validation(str)
                {
                    if (str.indexOf("/"") >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                */

                if (!re.Value.IsCheckData(tr))
                {
                    return "数据已存在，不可添加";
                }

                if (!re.Value.Create(tr))
                {
                    return "新增失败";
                }
                if (!re.Value.WriteLog(tr, tr.CreateBy, 0))
                {
                    return "日志写入失败，请重新添加" + tr.SMTCode + "的相关 数据";
                }
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public TranRepair GetDataById(int Id)
        {
            TranRepair tr = new TranRepair();
            try
            {
                tr.returnMessage = false;
                if (Id < 0)
                {
                    tr.returnMessage = false;
                    return tr;
                }
                tr = re.Value.GetDataById(Id);
                if (tr != null)
                {
                    tr.returnMessage = true;
                }
                return tr;
            }
            catch (Exception)
            {
                tr.returnMessage = false;
                throw;
            }
        }



        public string Update(TranRepair tr)
        {
            try
            {
                if (string.IsNullOrEmpty(tr.ProductCode))
                {
                    return "产品编码不能为空";
                }
                if (string.IsNullOrEmpty(tr.AssemblyCode))
                {
                    return "组装编码不能为空";
                }
                if (string.IsNullOrEmpty(tr.DIPCode))
                {
                    return "插件编码不能为空";
                }
                if (string.IsNullOrEmpty(tr.SMTCode))
                {
                    return "贴片编码不能为空";
                }
                if (string.IsNullOrEmpty(tr.SNPrefix))
                {
                    return "SN编码规则样例不能为空";
                }

                //删减前后空格
                tr.ProductCode = tr.ProductCode.Trim();
                tr.AssemblyCode = tr.AssemblyCode.Trim();
                tr.DIPCode = tr.DIPCode.Trim();
                tr.SMTCode = tr.SMTCode.Trim();
                tr.SNPrefix = tr.SNPrefix.Trim();
                tr.Remark = tr.Remark;

                //查询要修改的数据是否存在
                TranRepair tra = new TranRepair();
                tra = re.Value.GetDataById(tr.ID);
                if (tra == null)
                {
                    return "选择不的数据不在数据库中！";
                }
                if (tra.DIPCode == tr.DIPCode && tra.SMTCode == tr.SMTCode && tra.SNPrefix == tr.SNPrefix)
                {
                    return "当前选择的数据与要修改的数据一致，无法修改！";
                }
                //修改
                if (!re.Value.Update(tr))
                {
                    return "修改失败！";
                }
                //添加修改历史记录
                if (!re.Value.WriteLog(tr, tr.ModifyBy, 1))
                {
                    return "日志写入失败，请重新添加" + tr.SMTCode + "的相关 数据";
                }
                return "success";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }



        public string DeleteById(int Id)
        {
            try
            {
                if (Id < 0)
                {
                    return "请选择要删除的数据！";
                }
                TranRepair tr = new TranRepair();
                tr = re.Value.GetDataById(Id);
                if (tr == null)
                {
                    return "要删除的数据不存在！";
                }

                if (!re.Value.DeleteById(Id))
                {
                    return "删除失败！";
                }

                //获取操作人姓名
                string customer = "";
                //添加删除历史记录
                if (!re.Value.WriteLog(tr, customer, 2))
                {
                    return "日志写入失败，请重新添加" + tr.SMTCode + "的相关 数据";
                }
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
