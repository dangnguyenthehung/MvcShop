using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Models
{
    public class ProductDetailsModel : LayoutViewModel
    {
        public List<View_ProductDetails> listDetails { get; set; }
        public View_ProductDetails Details { get; set; }
        
        public ProductDetailsModel(int? id)
        {
            var context = new Model.DbModel.ProductDetailsModel();
            Details = context.getDetails(id);
        }

        //public ProductDetailsModel()
        //{
        //    var context = new Model.DbModel.ProductDetailsModel();
        //    listDetails = context.getDetails_All();
        //}
    }
}