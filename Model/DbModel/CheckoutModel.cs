using Model.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DbModel
{
    public class CheckoutModel
    {
        ShopdbContext context = null;
        public CheckoutModel()
        {
            context = new ShopdbContext();
        }

        public List<View_ProductDetails> getItemInfo(List<int> listID)
        {
            List<View_ProductDetails> listItems = new List<View_ProductDetails>();
            foreach (var id in listID)
            {
                object[] SqlParams = 
                {
                    new SqlParameter("@id",id)
                };

                var item = context.Database.SqlQuery<View_ProductDetails>("Sp_GetProductDetails @id", SqlParams).SingleOrDefault();
                listItems.Add(item);
            }
            
            return listItems;
        }
    }
}
