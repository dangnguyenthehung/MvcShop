using Model.DbModel;
using Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Helper
{
    public class Get_SelectList
    {
        public List<SelectList_Item> Get_ThanhPho ()
        {
            var dbModel = new SelectListModel();

            List<SelectList_Item> list = dbModel.Get_ThanhPho();

            return list;
        }

        public List<SelectList_Item> Get_Quan (int ID_ThanhPho = 1)
        {            
            var dbModel = new SelectListModel();

            List<SelectList_Item> list = dbModel.Get_Quan(ID_ThanhPho);

            return list;

        }
    }
}