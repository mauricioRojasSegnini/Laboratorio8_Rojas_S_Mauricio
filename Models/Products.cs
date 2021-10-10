using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio8.Models
{
    public class Products
    {
        public int Id { get; set; }
        public int Quantity {get;set;}
        public string Name { get; set; }
        public int Price { get; set; }
    }
}