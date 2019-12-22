using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentShop.Models
{

   /**
    * Used to define product 
    * 
    * @author Davain Pablo Edwards
    * @license MIT
    * @version 1.0
    */
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
