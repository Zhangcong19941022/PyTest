using BLL;
using DAL;
using Models;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace PeiyingMes.Controllers
{
    /// <summary>
    /// 工单对应烧录程序API
    /// </summary>
    [RoutePrefix("api/ProdForOrder")]
    public class ProdForOrderController : ApiController
    {
        //上传服务器地址
        public static readonly string savePath = ConfigurationManager.ConnectionStrings["UploadPath"].ConnectionString;

        public static readonly string conn = ConfigurationManager.ConnectionStrings["PY_SQLCONNECT"].ConnectionString;



        /// <summary>
        /// 工单程序包历史列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetOrderHistory")]
        public object GetOrderHistory()
        {
            string connstring = conn;
            List<ProdOrderForProgramHistory> his = new List<ProdOrderForProgramHistory>();
            ProdOrderList propOrder = new ProdOrderList();
            try
            {
                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                //定义传统request对象
                HttpRequestBase request = context.Request;
                //获取form-data传入的分页参数
                NameValueCollection Collection = request.Form;
                //int cPage = int.Parse(Collection["cPage"]);
                //int pSize = int.Parse(Collection["pSize"]);
                string orderNo = Collection["OrderNo"];
                if (!string.IsNullOrEmpty(orderNo))
                {
                    orderNo = orderNo.Trim();
                }
                //his = BLL.ProdOrderBLL.GetOrderHistory(orderNo,  connstring);
                propOrder = BLL.ProdOrderBLL.GetOrderHistory(orderNo, 0, 0, connstring);
            }
            catch (Exception)
            {

                throw;
            }
            return Json<ProdOrderList>(propOrder);
        }



       /// <summary>
       /// 工单程序包列表
       /// </summary>
       /// <returns></returns>
        [Route("GetVOrderNoLine")]
        [HttpPost]
        public object GetVOrderNoLine()
        {
            string connstring = "";
            ProdOrderList propOrder = new ProdOrderList();
            //获取程序的基目录。
            string basepath = System.AppDomain.CurrentDomain.BaseDirectory;
            try
            {

                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                //定义传统request对象
                HttpRequestBase request = context.Request;
                //获取form-data传入的分页参数
                NameValueCollection Collection = request.Form;
                int cPage = int.Parse(Collection["cPage"]);
                int pSize = int.Parse(Collection["pSize"]);
                string orderNo = Collection["OrderNo"];
                if (!string.IsNullOrEmpty(orderNo))
                {
                    orderNo = orderNo.Trim();
                }
                propOrder = BLL.ProdOrderBLL.GetVOrderNoLine(orderNo, cPage, pSize, connstring);
            }
            catch (Exception)
            {
                throw;
            }
            return Json<ProdOrderList>(propOrder);
        }

        #region  本系统页面
        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("CheckFile")]
        public bool CheckFile()
        {
            //文件对象
            HttpFileCollection files = HttpContext.Current.Request.Files;
            //传入参数对象
            NameValueCollection Collection = HttpContext.Current.Request.Form;
            string orderNo = Collection["orderNo"];
            // string CreateBy = Collection["CreateBy"];
          
            foreach (string key in files.AllKeys)
            {
                HttpPostedFile file = files[key];//file.ContentLength文件长度

                orderNo = orderNo.Trim();

                #region 数据转换
                //上传地址
                string savePathNew;
                if (string.IsNullOrEmpty(orderNo))
                {
                    savePathNew = savePath + "/" + file.FileName;
                }
                else {
                    savePathNew= savePath + orderNo+ "/" + file.FileName;
                }
             
                //验证地址
                if (IsExistsFile(savePathNew))
                {
                    return true;
                }
                #endregion         
            }
            return false;
        }


        [Route("UpLoadFile")]
        [HttpPost]
        public IHttpActionResult UpLoadFile()
        {
            /*
            HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
            HttpRequestBase request = context.Request;//定义传统request对象
            NameValueCollection Collection = request.Form;
            */
            string connstring = conn;
            try
            {
                //文件对象
                HttpFileCollection files = HttpContext.Current.Request.Files;
                //传入参数对象
                NameValueCollection Collection = HttpContext.Current.Request.Form;
                string orderNo = Collection["orderNo"];
                // string CreateBy = Collection["CreateBy"];

                //验证工单号
                if (string.IsNullOrEmpty(orderNo))
                {
                    return Ok("请选择工单！");
                }
                //验证文件包
                if (files.AllKeys.Length == 0)
                {
                    return Ok("请选择文件！");
                }
                if (files.AllKeys.Length > 1)
                {
                    return Ok("文件数据超出限制，请重新选择！");
                }
                foreach (string key in files.AllKeys)
                {
                    HttpPostedFile file = files[key];//file.ContentLength文件长度

                    #region 数据转换
                    if (string.IsNullOrEmpty(file.FileName))
                    {
                        return Ok("文件名称不能为空！");
                    }

                    //上传地址文件夹,不存在则创建
                    string savePathNew = savePath + orderNo;
                    if (Directory.Exists(savePathNew) == false)
                    {
                        Directory.CreateDirectory(savePathNew);
                    }

                    //上传地址
                    savePathNew = savePathNew + "/" + file.FileName;

                    ////验证文件是否存在
                    //if (IsExistsFile(savePathNew))
                    //{
                    //    return Ok("文件已存在！");
                    //}

                    //保存到数据库
                    ProdOrderForProgram pro = new ProdOrderForProgram();
                    pro.OrderNo = orderNo;
                    pro.BaraName = file.FileName;
                    pro.BaraPath = savePathNew;
                    pro.CreateTime = DateTime.Now;
                    // pro.CreateBy = CreateBy;

                    //历史记录
                    ProdOrderForProgramHistory proHis = new ProdOrderForProgramHistory();
                    proHis.HisOrderNo = orderNo;
                    proHis.HisBaraName = file.FileName;
                    proHis.HisBaraPath = savePathNew;
                    proHis.CreateTime = DateTime.Now;
                    //pro.CreateBy = CreateBy;
                    #endregion

                    //保存文件到指定路径
                    file.SaveAs(savePathNew);
                    //查询
                    List<ProdOrderForProgram> list = new List<ProdOrderForProgram>();
                    list = BLL.ProdOrderBLL.GetOrder(pro.OrderNo, connstring);
                    //修改订单程序包对应关系，存在覆盖，不存在新增
                    if (list.Count == 1)
                    {
                        //修改
                        if (!BLL.ProdOrderBLL.UpdateProgaramData(pro, connstring))
                        {
                            return Ok("上传失败！");
                        }
                    }
                    if (list.Count == 0)
                    {
                        //保存对应关系到数据库
                        if (!BLL.ProdOrderBLL.CreateProgaramData(pro, connstring))
                        {
                            return Ok("上传失败！");
                        }
                    }

                    //添加历史
                    if (!BLL.ProdOrderBLL.CreateProgaramDataHistory(proHis, connstring))
                    {
                        return Ok("上传记录未录入，请重新上传！");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Ok("success");
        }

        #endregion


        #region 用于MES系统内置
        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("CheckFileMES")]
        public bool CheckFileMES()
        {
            //文件对象
            HttpFileCollection files = HttpContext.Current.Request.Files;
            //传入参数对象
            NameValueCollection Collection = HttpContext.Current.Request.Form;
            string orderNo = Collection["orderNo"];
            // string CreateBy = Collection["CreateBy"];

            foreach (string key in files.AllKeys)
            {
                HttpPostedFile file = files[key];//file.ContentLength文件长度

                orderNo = orderNo.Trim();

                #region 数据转换
                //上传地址
                string savePathNew;
                if (string.IsNullOrEmpty(orderNo))
                {
                    savePathNew = savePath + "/" + file.FileName;
                }
                else
                {
                    savePathNew = savePath + orderNo + "/" + file.FileName;
                }

                //验证地址
                if (IsExistsFile(savePathNew))
                {
                    return true;
                }
                #endregion         
            }
            return false;
        }

        [HttpPost]
        [Route("UpLoadFileMES")]
        public IHttpActionResult UpLoadFileMES()
        {
            string connstring = conn;
            try
            {
                //文件对象
                HttpFileCollection files = HttpContext.Current.Request.Files;
                //传入参数对象
                NameValueCollection Collection = HttpContext.Current.Request.Form;
                string orderNo = Collection["orderNo"];
                // string CreateBy = Collection["CreateBy"];

                //验证工单号
                if (string.IsNullOrEmpty(orderNo))
                {
                    return Ok("请选择工单！");
                }
                //验证文件包
                if (files.AllKeys.Length == 0)
                {
                    return Ok("请选择文件！");
                }
                if (files.AllKeys.Length > 1)
                {
                    return Ok("文件数据超出限制，请重新选择！");
                }
                foreach (string key in files.AllKeys)
                {
                    HttpPostedFile file = files[key];//file.ContentLength文件长度

                    #region 数据转换
                    if (string.IsNullOrEmpty(file.FileName))
                    {
                        return Ok("文件名称不能为空！");
                    }

                    //上传地址文件夹,不存在则创建
                    string savePathNew = savePath + orderNo;
                    if (Directory.Exists(savePathNew) == false)
                    {
                        Directory.CreateDirectory(savePathNew);
                    }

                    //上传地址
                    savePathNew = savePathNew + "/" + file.FileName;

                    ////验证文件是否存在
                    //if (IsExistsFile(savePathNew))
                    //{
                    //    return Ok("文件已存在！");
                    //}

                    //保存到数据库
                    ProdOrderForProgram pro = new ProdOrderForProgram();
                    pro.OrderNo = orderNo;
                    pro.BaraName = file.FileName;
                    pro.BaraPath = savePathNew;
                    pro.CreateTime = DateTime.Now;
                    // pro.CreateBy = CreateBy;

                    //历史记录
                    ProdOrderForProgramHistory proHis = new ProdOrderForProgramHistory();
                    proHis.HisOrderNo = orderNo;
                    proHis.HisBaraName = file.FileName;
                    proHis.HisBaraPath = savePathNew;
                    proHis.CreateTime = DateTime.Now;
                    //pro.CreateBy = CreateBy;
                    #endregion

                    //保存文件到指定路径
                    file.SaveAs(savePathNew);
                    //查询
                    List<ProdOrderForProgram> list = new List<ProdOrderForProgram>();
                    list = BLL.ProdOrderBLL.GetOrder(pro.OrderNo, connstring);
                    //修改订单程序包对应关系，存在覆盖，不存在新增
                    if (list.Count == 1)
                    {
                        //修改
                        if (!BLL.ProdOrderBLL.UpdateProgaramData(pro, connstring))
                        {
                            return Ok("上传失败！");
                        }
                    }
                    if (list.Count == 0)
                    {
                        //保存对应关系到数据库
                        if (!BLL.ProdOrderBLL.CreateProgaramData(pro, connstring))
                        {
                            return Ok("上传失败！");
                        }
                    }

                    //添加历史
                    if (!BLL.ProdOrderBLL.CreateProgaramDataHistory(proHis, connstring))
                    {
                        return Ok("上传记录未录入，请重新上传！");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Ok("success");
        }

        #endregion


        [HttpPost]
        [Route("Upload")]
        public string Upload()
        {
            string Path = @"D:\工作文件\上传文件存储";
            bool status = false;
            //连接  
            string serverFolder = @"\\192.168.72.100\Evan";
            //string PWD = "qwe123!@#";//kingdee1!
            string PWD = "ABCabc123";//kingdee1!
            status = connectState(serverFolder, "administrator", PWD);
            if (status)
            {
                //共享文件夹的目录  
                DirectoryInfo theFolder = new DirectoryInfo(serverFolder);
                string filename = theFolder.ToString();
                //执行方法   

                TransportRemoteToServer(serverFolder + @"\", Path, "test.pdf");    //实现将远程服务器文件写入到本地  

            }
            else
            {
                return "连接服务器失败！";
            }
            return "success";
        }

        /// <summary>  
        /// 从本地上传文件至服务器
        /// </summary>  
        /// <param name="src">远程服务器路径（共享文件夹路径）</param>  
        /// <param name="dst">本地文件夹路径</param>  
        /// <param name="fileName">上传至服务器上的文件名，包含扩展名</param>  
        public static void TransportRemoteToServer(string src, string dst, string fileName)
        {
            if (!Directory.Exists(dst))
            {
                Directory.CreateDirectory(dst);
            }
            src = src + fileName;
            FileStream inFileStream = new FileStream(src, FileMode.OpenOrCreate);    //从远程服务器下载到本地的文件 

            FileStream outFileStream = new FileStream(dst, FileMode.Open);    //远程服务器文件  此处假定远程服务器共享文件夹下确实包含本文件，否则程序报错  

            byte[] buf = new byte[outFileStream.Length];

            int byteCount;

            while ((byteCount = outFileStream.Read(buf, 0, buf.Length)) > 0)
            {

                inFileStream.Write(buf, 0, byteCount);

            }

            inFileStream.Flush();

            inFileStream.Close();

            outFileStream.Flush();

            outFileStream.Close();

        }

        /// <summary>
        /// 连接远程共享文件夹  
        /// </summary>
        /// <param name="path">远程共享文件夹的路径</param>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public static bool connectState(string path, string userName, string passWord)
        {
            bool Flag = false;
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.StandardInput.WriteLine("net use * /del /y");
                string dosLine = "net use " + path + " " + passWord + " /user:" + userName;
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return Flag;
        }

        /// <summary>
        /// 检测文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsExistsFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("IsLogin")]
        public string IsLogin(string userName, string passWord)
        {
            // Upload();
            if (string.IsNullOrEmpty(userName))
            {
                return "用户名不能为空！";
            }
            if (string.IsNullOrEmpty(passWord))
            {
                return "密码不能为空！";
            }
            //预留校验格式


            if (userName != "admin")
            {
                return "账户错误";
            }
            if (passWord != "admin")
            {
                return "密码错误";
            }
            return "success";
        }



        /// <summary>
        /// 不良采集验证SN和程序名
        /// </summary>
        /// <param name="scanSN"></param>
        /// <param name="txtContrast"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("IsOrderData")]
        public string IsOrderData(string scanSN, string txtContrast)
        {
            if (string.IsNullOrEmpty(scanSN))
            {
                return "error";
            }
            if (string.IsNullOrEmpty(txtContrast)) {
                return "error";
            }
            scanSN = scanSN.Trim();
            txtContrast = txtContrast.Trim();
            vwProdSNForPro ps = new vwProdSNForPro();
            ps = BLL.ProdOrderBLL.GetOrderFromSN(scanSN);
            if (txtContrast!=ps.BaraName)
            {
                return "error";
            }
            return "success";
        }



    }
}
