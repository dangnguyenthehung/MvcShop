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
        public List<CartItem> GetItemInfo(List<CartItem> listItems)
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

        public void Create_Order_Infomation(CheckoutInfo model)
        {
            // create customer base on delivery info
            var customer_Id = Create_Customer(model.BillingInfo);

            // add to order table
            var order_Id = Create_Order(customer_Id, model);
        
            // add to order details table
            foreach(var item in model.CartItems)
            {
                var order_Detail = Create_Order_Detail(order_Id, item);
            }
        }

        private int Create_Customer(BillingInfo customer_Info)
        {
            try
            {
                object[] SqlParams =
                    {
                    new SqlParameter("@Name",customer_Info.Customer_Name),
                    new SqlParameter("@City_Id",customer_Info.City_ID),
                    new SqlParameter("@District_Id",customer_Info.District_ID),
                    new SqlParameter("@Customer_Address",customer_Info.Delivery_Address),
                    new SqlParameter("@Tel",customer_Info.Customer_Phone),
                    new SqlParameter("@Email",customer_Info.Customer_Email)
                };

                var res = context.Database.SqlQuery<int>("Sp_Create_Customer @Name, @City_Id, @District_Id, @Customer_Address, @Tel, @Email", SqlParams).FirstOrDefault();

                return res;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return 0;
            }
        }

        private int Create_Order(int Customer_Id, CheckoutInfo model)
        {
            try
            {
                double? total_Money = 0;

                foreach(var item in model.CartItems)
                {

                    if (item.Price == null)
                    {
                        item.Price = 0;
                    };

                    var item_total_price = item.Price * item.Quantity;
                    total_Money += item_total_price;

                }

                object[] SqlParams =
                    {
                    new SqlParameter("@Customer_Id",Customer_Id),
                    new SqlParameter("@Delivery_City_Id",model.BillingInfo.City_ID),
                    new SqlParameter("@Delivery_District_Id",model.BillingInfo.District_ID),
                    new SqlParameter("@Delivery_Address",model.BillingInfo.Delivery_Address),
                    new SqlParameter("@Total_Money",total_Money),
                    new SqlParameter("@Order_Status", 1),
                    new SqlParameter("@Notes",model.BillingInfo.Notes)
                };

                var res = context.Database.SqlQuery<int>("Sp_Create_Order @Customer_Id, @Delivery_City_Id, @Delivery_District_Id, @Delivery_Address, @Total_Money, @Order_Status, @Notes", SqlParams).FirstOrDefault();

                return res;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return 0;
            }
        }

        private int Create_Order_Detail(int Order_Id, CartItem item)
        {
            try
            {
                double? total_Price = 0;

                if (item.Price == null)
                {
                    item.Price = 0;
                };

                total_Price += item.Price * item.Quantity;

                object[] SqlParams =
                    {
                    new SqlParameter("@Order_Id",Order_Id),
                    new SqlParameter("@Product_Id",item.ItemId),
                    new SqlParameter("@Quantity",item.Quantity),
                    new SqlParameter("@Price",item.Price),
                    new SqlParameter("@Total_Price",total_Price)
                };

                var res = context.Database.SqlQuery<int>("Sp_Create_Order_Detail @Order_Id, @Product_Id, @Quantity, @Price, @ToTal_Price", SqlParams).FirstOrDefault();

                return res;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
