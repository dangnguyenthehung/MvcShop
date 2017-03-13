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

        // get product details by product id
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

        // get all product details list
        public List<ShopProductInfo> getDetails_All()
        {
            
            var list = context.Database.SqlQuery<ShopProductInfo>("Sp_GetShopProductInfo").ToList();
            return list;
        }

        // get product details list by brand id
        public List<ShopProductInfo> getDetails_Brand(int id)
        {
            object[] SqlParams = 
            {
                new SqlParameter("@id",id)
            };
            var list = context.Database.SqlQuery<ShopProductInfo>("Sp_GetBrandProductInfo @id", SqlParams).ToList();
            return list;
        }

        // get product details list by type id
        public List<ShopProductInfo> getDetails_Type(int id)
        {
            object[] SqlParams =
            {
                new SqlParameter("@id",id)
            };
            var list = context.Database.SqlQuery<ShopProductInfo>("Sp_GetTypeProductInfo @id", SqlParams).ToList();
            return list;
        }

        //get Type name
        public string get_type_name(int id)
        {
            object[] SqlParams =
            {
                new SqlParameter("@id",id)
            };
            var name = context.Database.SqlQuery<string>("Sp_GetTypeName @id", SqlParams).SingleOrDefault();
            return name;
        }
    }
}
