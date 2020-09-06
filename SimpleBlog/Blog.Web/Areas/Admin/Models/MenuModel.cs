using Blog.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Models
{
    public class MenuModel
    {
        public IList<MenuItem> MenuItems { get; set; }
    }

    //this menu Item makes for demo when data and framework added this class will be deleted
    //public class MenuItem
    //{
    //    public string Title { get; set; }
    //    public string Childs { get; set; }

    //}
}
