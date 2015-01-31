using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class NavViewModel
    {
        public IEnumerable<String> Categories { get; set; }
        public String SelectedCategory { get; set; }
    }
}