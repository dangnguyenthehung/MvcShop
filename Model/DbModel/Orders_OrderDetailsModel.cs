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
    public class Orders_OrderDetailsModel
    {
        ShopdbContext context = null;

        public Orders_OrderDetailsModel()
        {
            context = new ShopdbContext();
        }

        public List<NewOrder> Get_New_Orders()
        {
            try
            {
                var res = context.Database.SqlQuery<NewOrder>("Sp_Get_New_Order").ToList();

                return res;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<NewOrder>();
            }
        }

        public List<NewOrder> Get_Completed_Orders()
        {
            try
            {
                var res = context.Database.SqlQuery<NewOrder>("Sp_Get_Completed_Order").ToList();

                return res;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<NewOrder>();
            }
        }

        public List<OrderItems> Get_Order_Details(int Order_Id)
        {
            try
            {
                object[] sqlParams = 
                {
                    new SqlParameter("@Order_Id", Order_Id)
                };
                var res = context.Database.SqlQuery<OrderItems>("Sp_Get_Order_Details @Order_Id", sqlParams).ToList();

                return res;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<OrderItems>();
            }
        }

        public NewOrder Get_Order_By_Id(int Order_Id)
        {
            try
            {
                object[] sqlParams =
                {
                    new SqlParameter("@Order_Id", Order_Id)
                };
                var res = context.Database.SqlQuery<NewOrder>("Sp_Get_Order_By_Id @Order_Id", sqlParams).SingleOrDefault();

                return res;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new NewOrder();
            }
        }

        public OrderItems Get_OrderItem_By_Id(int OrderItem_Id)
        {
            try
            {
                object[] sqlParams =
                {
                    new SqlParameter("@OrderItem_Id", OrderItem_Id)
                };
                var res = context.Database.SqlQuery<OrderItems>("Sp_Get_OrderItem_By_Id @OrderItem_Id", sqlParams).SingleOrDefault();

                return res;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new OrderItems();
            }
        }

        public int Update_OrderItem_By_Id(int OrderItem_Id, int Quantity)
        {
            try
            {
                object[] sqlParams =
                {
                    new SqlParameter("@OrderItem_Id", OrderItem_Id),
                    new SqlParameter("@Quantity", Quantity)
                };
                var res = context.Database.SqlQuery<int>("Sp_Update_OrderItem_By_Id @OrderItem_Id, @Quantity", sqlParams).SingleOrDefault();

                return res;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return 0;
            }
        }

        public void Verify_Order_By_Id(NewOrder info)
        {
            try
            {
                object[] sqlParams =
                {
                    new SqlParameter("@Order_Id", info.Order_Id),
                    new SqlParameter("@Delivery_Address", info.Delivery_Address)
                };
                var res = context.Database.SqlQuery<int>("Sp_Verify_Order_By_Id @Order_Id, @Delivery_Address", sqlParams).SingleOrDefault();

                //return res;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //return 0;
            }
        }

        public void Delete_Order_By_Id(int id)
        {
            try
            {
                object[] sqlParams =
                {
                    new SqlParameter("@Order_Id", id)
                };
                var res = context.Database.ExecuteSqlCommand("Sp_Delete_Order_By_Id @Order_Id", sqlParams);

                //return res;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //return 0;
            }
        }
    }
}
