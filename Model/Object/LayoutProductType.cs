using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Object
{
    public class LayoutProductType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int TypeOrder { get; set; }
        public int ParentTypeId { get; set; }
    }
}
