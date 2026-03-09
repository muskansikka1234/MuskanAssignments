using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFDemo.Models
{
    class Category
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public List<Product> Products { set; get; }
    }
}
