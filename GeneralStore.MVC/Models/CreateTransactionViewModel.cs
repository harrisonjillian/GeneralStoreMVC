using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Models
{
    //View Model is a convention of how you name things. Only purpose is to be used in the controlloer to show what information is passed to view
    public class CreateTransactionViewModel
    {

        public IEnumerable<SelectListItem> Products { get; set; }
        public int ProductId { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }
        public int CustomerId { get; set; }
    }
}
