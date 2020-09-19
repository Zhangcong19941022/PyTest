using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using NPOI.SS.UserModel;
using Org.BouncyCastle.Asn1.Cmp;

namespace DAL
{
    public class ExportDAL
    {
        public static void ExportUpload()
        {
            string uploadpath = @" E:/工作/测试.xls";

            try
            {
                //IWorkbook workbook = WorkbookFactory.Create(uploadpath);
                //ISheet sheet = workbook.GetSheetAt(0);//获取第一个工作薄
                //IRow row = (IRow)sheet.GetRow(1);//获取第一行
                //int count = sheet.LastRowNum;
                //var cell = row.GetCell(1);

                //CellType ct = cell.CellType;

                //cell = row.GetCell(3);
                //ct = cell.CellType;


                //cell = row.GetCell(4);
                //if (cell != null) {
                //    ct = cell.CellType;
                //}
                IWorkbook workbook = WorkbookFactory.Create(uploadpath);
                ISheet sheet = workbook.GetSheetAt(0);//获取第一个工作薄
                                                      //  ISheet sheet = workbook.GetSheetName("");//获取第一个工作薄Name
                int count = sheet.LastRowNum;
                //遍历sheet中的行
                for (int i = 0; i < count + 1; i++)
                {
                    IRow rowc = (IRow)sheet.GetRow(i);//获取第一行
                    int rcount = rowc.LastCellNum;
                    //遍历Row的没一列数据
                    for (int k = 0; k < rcount + 1; k++)
                    {
                        ICell ce = rowc.GetCell(k);
                        if (ce != null)
                        {
                            //获取数据类型
                            CellType ctc = ce.CellType;
                            // NIPO转换类型
                            //NUMERIC 数值型 0
                            //STRING 字符串型 1
                            //FORMULA 公式型 2
                            //BLANK 空值 3
                            //BOOLEAN 布尔型 4
                            //ERROR 错误 5
                            //日期既是FORMULA 也是STRING
                            //数字既是NUMERIC也可以是FORMULA


                            //将cell的value和tyep加入对应的实体
                            //List<T> li = new List<T>();

                        }
                    }
                }

                //设置第一行第一列值,更多方法请参考源官方Demo
                //  row.CreateCell(0).SetCellValue("test");//设置第一行第一列值

                //导出excel
                //     FileStream fs = new FileStream(exportExcelPath, FileMode.Create, FileAccess.ReadWrite);
                //workbook.Write(fs);
                //fs.Close();
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                throw;
            }
        }
    }
}
