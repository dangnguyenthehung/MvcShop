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
    public class ProductDetailsModel
    {
        public ShopdbContext context = new ShopdbContext();
        public View_ProductDetails getDetails(int? id)
        {
            if (id == null)
            {
                id = 1;
            }
            object[] SqlParams =
            {
                new SqlParameter("@id",id)
            };
            var list = context.Database.SqlQuery<View_ProductDetails>("Sp_GetProductDetails @id", SqlParams).SingleOrDefault();
            return list;
        }
        public List<ShopProductInfo> getDetails_All()
        {
            
            var list = context.Database.SqlQuery<ShopProductInfo>("Sp_GetShopProductInfo").ToList();
            return list;
        }
    }
}
