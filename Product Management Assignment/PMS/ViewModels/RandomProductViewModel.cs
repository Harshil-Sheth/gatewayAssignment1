using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMS.Models;

namespace PMS.ViewModels
{
    public class RandomProductViewModel
    {
        public Product Product { get; set; }
        public List<Customer> Customers { get; set; }
    }
}