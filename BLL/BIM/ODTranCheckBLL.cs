using DAL;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ODTranCheckBLL
    {
        Lazy<ODTranCheckDAL> od = new Lazy<ODTranCheckDAL>();
        public  bool Create(ODTranCheck entity)
        {
            return od.Value.Create(entity);
        }


        public  bool GetDataExists(string orderNo)
        {
            return od.Value.GetDataExists(orderNo);
        }


        public bool GetDataExistsById(int  Id)
        {
            return od.Value.GetDataExistsById(Id); 
           }

        public bool Update(ODTranCheck entity)
        {
            return od.Value.Update(entity);
        }


        public List<ODTranCheck> GetDataById(int Id)
        {
            return od.Value.GetDataById(Id);
        }

        public bool DeleteById(int Id)
        {
            return od.Value.DeleteById(Id);
        }
    }
}
