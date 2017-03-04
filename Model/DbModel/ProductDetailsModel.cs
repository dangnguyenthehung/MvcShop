using Model.Framework;
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
        public View_ProductDetails getDetails(int id)
        {
            object[] SqlParams =
            {
                new SqlParameter("@id",id)
            };
            var list = context.Database.SqlQuery<View_ProductDetails>("Sp_GetProductDetails", SqlParams).SingleOrDefault();
            return list;
        }
        public List<View_ProductDetails> getDetails_All()
        {
            int id = 0;
            object[] sqlParams =
            {
                new SqlParameter("@id", id)
            };
            var list = context.Database.SqlQuery<View_ProductDetails>("Sp_GetProductDetails @id", sqlParams).ToList();
            return list;
        }
    }
}
