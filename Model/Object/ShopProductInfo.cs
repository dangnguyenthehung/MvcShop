using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Object
{
    public class ShopProductInfo : View_ShopProductInfo
    {
        public string formattedPrice() {
            string str = String.Format("{0:n0}", NewPrice);
            str = str.Replace(",", ".");
            return str;
        }
    }
}
