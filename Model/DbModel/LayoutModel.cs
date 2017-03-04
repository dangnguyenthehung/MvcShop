using Model.Framework;
using Model.Object;
using System;
using System.Collections.Generic;
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
    }
}
