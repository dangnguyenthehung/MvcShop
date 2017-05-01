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
    public class LayoutModel
    {
        public ShopdbContext context = new ShopdbContext();

        public List<BrandNumberOfProduct> getBrandNumberOfProduct()
        {
            List<BrandNumberOfProduct> list = new List<BrandNumberOfProduct>();
            list = context.Database.SqlQuery<BrandNumberOfProduct>("Sp_CountBrandProduct").ToList();
            return list;
        }
        public List<LayoutProductType> getProductType()
        {
            List<LayoutProductType> list = new List<LayoutProductType>();
            list = context.Database.SqlQuery<LayoutProductType>("Sp_GetProductType").ToList();
            return list;
        }

        // get number of product
        public int Get_Count_Product_All()
        {
            var number = context.Database.SqlQuery<int>("Sp_Get_Count_Product_All").SingleOrDefault();
            // mock data
            //return 220;
            return number;

        }

        public int Get_Count_Product_Brand(int Brand_Id)
        {
            object[] SqlParams =
            {
                new SqlParameter("@Brand_Id",Brand_Id)
            };
            var number = context.Database.SqlQuery<int>("Sp_Get_Count_Product_Brand @Brand_Id", SqlParams).SingleOrDefault();
            // mock data
            //return 220;
            return number;
        }

        public int Get_Count_Product_Type(int Type_Id)
        {
            object[] SqlParams =
            {
                new SqlParameter("@Type_Id",Type_Id)
            };
            var number = context.Database.SqlQuery<int>("Sp_Get_Count_Product_Type @Type_Id", SqlParams).SingleOrDefault();
            // mock data
            //return 220;
            return number;
        }
        //public int Login(string UserName, string Password)
        //{
        //    object[] SqlParams =
        //    {
        //        new SqlParameter("@UserName",UserName),
        //        new SqlParameter("@Password",Password)
        //    };

        //    var result = context.Database.SqlQuery<int>("Sp_Login @UserName,@Password", SqlParams).SingleOrDefault();

        //    return result;
        //}
    }
}
