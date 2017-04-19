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
    public class Cart_CheckoutModel
    {
        ShopdbContext context = null;
        public Cart_CheckoutModel()
        {
            context = new ShopdbContext();
        }
         // trả về thông tin chi tiết mặt hàng khách hàng đặt
        public List<CartItem> getItemInfo(List<CartItem> listItems)
        {
            //var listItems = new List<CartItem>();

            foreach (var obj in listItems)
            {
                object[] SqlParams = 
                {
                    new SqlParameter("@id",obj.ItemId)
                };

                var item = context.Database.SqlQuery<View_ProductDetails>("Sp_GetProductDetails @id", SqlParams).SingleOrDefault();

                obj.ProductName = item.ProductName;
                obj.ProductImages = item.ProductImages;
                obj.ProductCode = item.ProductCode;
                obj.Price = item.NewPrice;
            }
            
            return listItems;
        }
    }
}
