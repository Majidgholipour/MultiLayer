using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Caption { get; set; }
        public int ProductGroupId { get; set; }

    }
}
