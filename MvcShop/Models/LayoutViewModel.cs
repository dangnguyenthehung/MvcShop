using Model.DbModel;
using Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Models
{
    public abstract class LayoutViewModel : MainLayoutModel
    {
        public List<BrandNumberOfProduct> Brand_Number_of_Product { get; set; }
        public List<MainProductType> Main_ProductType { get; set; }
        public List<LayoutProductType> Sub_ProductType { get; set; }
        
        
        public LayoutViewModel()
        {
            LayoutModel layoutModel = new LayoutModel();
            // Brand_Number_of_Product
            List<BrandNumberOfProduct> list_brand_number_of_product = layoutModel.getBrandNumberOfProduct();
            Brand_Number_of_Product = list_brand_number_of_product;
            

            // Product Type
            List<MainProductType> list_Main = new List<MainProductType>();
            List<LayoutProductType> list_Sub = new List<LayoutProductType>();

            List<LayoutProductType> list_product_type = layoutModel.getProductType();
            List<int> parentList = getParentList(list_product_type);

            foreach (var item in list_product_type)
            {
                if (item.ParentTypeId == 0)
                {
                    MainProductType parentItem = new MainProductType();
                    parentItem.Id = item.Id;
                    parentItem.TypeName = item.TypeName;
                    parentItem.TypeOrder = item.TypeOrder;
                    parentItem.ParentTypeId = item.ParentTypeId;
                    // check if a parent type
                    if (parentList.Exists(x => x == item.Id))
                    {
                        parentItem.haveSubType = true;
                    }
                    else
                    {
                        parentItem.haveSubType = false;
                    } // end check
                    list_Main.Add(parentItem);

                }
                else
                {
                    list_Sub.Add(item);
                }
            }
            Main_ProductType = list_Main;
            Sub_ProductType = list_Sub;

            
        }
        private List<int> getParentList(List<LayoutProductType> list)
        {
            List<int> parentList = new List<int>();
            
            foreach(var item in list)
            {
                if (item.ParentTypeId!=0)
                {
                    if (!parentList.Exists(x => x == item.ParentTypeId))
                    {
                        parentList.Add(item.ParentTypeId);
                    }
                    
                }
            }
            return parentList;

        }
    }
}