using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWeb2.Classes
{
    public class AllDemoWeb2BLL
    {
        public AllDemoWeb2BLL()
        {
            CategoryDB = new CategoryDB(AllConstants.CONNECTIONSTRING);
         
        }
        public void Dispose()
        {

        }


        public CategoryDB CategoryDB { get; set; }
        //public Logins Logins { get; set; }
        //public SubCategories SubCategories { get; set; }

       

    }
}