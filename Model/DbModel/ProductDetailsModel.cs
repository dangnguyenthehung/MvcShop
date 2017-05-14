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

        // get all product details list - Shop - Pages page
        public List<ShopProductInfo> getDetails_All(int sort_Type = 0)
        {
            var list = new List<ShopProductInfo>();
            try
            {
                if (sort_Type == 0)
                {
                    list = context.Database.SqlQuery<ShopProductInfo>("Sp_GetShopProductInfo").ToList();
                }
                else
                {
                    object[] SqlParams =
                    {
                        new SqlParameter("@Sort_Type", sort_Type)
                    };
                    list = context.Database
                        .SqlQuery<ShopProductInfo>("Sp_GetShopProductInfo_Sort @Sort_Type", SqlParams)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            
            return list;
        }
        public List<ShopProductInfo> getDetails_Recommend()
        {
            var list = new List<ShopProductInfo>();
            try
            {
                list = context.Database.SqlQuery<ShopProductInfo>("Sp_GetShopProductInfo_Recommend").ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return list;
        }

        // get product details list by brand id
        public List<ShopProductInfo> getDetails_Brand(int id, int sort_Type = 0)
        {
            var list = new List<ShopProductInfo>();
            try
            {
                if (sort_Type == 0)
                {
                    object[] SqlParams =
                    {
                        new SqlParameter("@id",id)
                    };

                    list = context.Database.SqlQuery<ShopProductInfo>("Sp_GetBrandProductInfo @id", SqlParams).ToList();
                }
                else
                {
                    object[] SqlParams =
                    {
                        new SqlParameter("@id",id),
                        new SqlParameter("@Sort_Type",sort_Type)
                    };
                    list = context.Database.SqlQuery<ShopProductInfo>("Sp_GetBrandProductInfo_Sort @id, @Sort_Type", SqlParams).ToList();
                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            
            return list;
        }

        // get product details list by type id
        public List<ShopProductInfo> getDetails_Type(int id, int sort_Type = 0)
        {
            var list = new List<ShopProductInfo>();
            try
            {
                if (sort_Type == 0)
                {
                    object[] SqlParams =
                    {
                        new SqlParameter("@id",id)
                    };

                    list = context.Database.SqlQuery<ShopProductInfo>("Sp_GetTypeProductInfo @id", SqlParams).ToList();
                }
                else
                {
                    object[] SqlParams =
                    {
                        new SqlParameter("@id",id),
                        new SqlParameter("@Sort_Type",sort_Type)
                    };
                    list = context.Database.SqlQuery<ShopProductInfo>("Sp_GetTypeProductInfo_Sort @id, @Sort_Type", SqlParams).ToList();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

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

        //increase product order
        public void Increase_order(int id)
        {
            object[] SqlParams =
            {
                new SqlParameter("@ID",id)
            };
            var name = context.Database.ExecuteSqlCommand("Sp_Inscrease_Product_Order @ID", SqlParams);
            //return name;
        }
        //update product status
        public void UpdateStatus(int id, int status)
        {
            object[] SqlParams =
            {
                new SqlParameter("@ID",id),
                new SqlParameter("@Status",status)
            };
            var res = context.Database.ExecuteSqlCommand("Sp_Change_Product_Status @ID, @Status", SqlParams);
            //return name;
        }
    }
}
