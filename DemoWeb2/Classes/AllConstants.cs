using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWeb2.Classes
{
    public class AllConstants
    {
        public static string CONNECTIONSTRING = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnectionString"].ToString();
    }
}