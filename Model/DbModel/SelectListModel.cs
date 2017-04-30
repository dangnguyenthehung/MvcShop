using Model.Framework;
using Model.Object;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DbModel
{
    public class SelectListModel
    {
        ShopdbContext context = null;

        public SelectListModel()
        {
            context = new ShopdbContext();
        }

        public List<SelectList_Item> Get_ThanhPho()
        {
            var res = context.Database.SqlQuery<List_Item>("Sp_Get_AllCity").ToList();

            return Convert(res);
        }

        public List<SelectList_Item> Get_Quan(int ID_ThanhPho = 1)
        {

            object[] sqlParams =
            {
                new SqlParameter("@City_Id",ID_ThanhPho)
            };

            var res = context.Database.SqlQuery<List_Item>("Sp_Get_District_By_City_Id @City_Id", sqlParams).ToList();

            return Convert(res);
        }

        private List<SelectList_Item> Convert(List<List_Item> list)
        {
            var newList = new List<SelectList_Item>();
            foreach (var item in list)
            {
                newList.Add(new SelectList_Item {
                    Id = item.Id.ToString(),
                    Name = item.Name
                });
            }

            return newList;
        }

        private class List_Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
