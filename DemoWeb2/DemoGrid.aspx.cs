using DemoWeb2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWeb2
{
    public partial class DemoGrid : System.Web.UI.Page
    {

        AllDemoWeb2BLL objBLL = new AllDemoWeb2BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        public void BindData()
        {
            try
            {
                Grid.DataSource = objBLL.EmployeeDB.All();
                Grid.DataBind();
            }
            catch(Exception ex)
            {
                lblerror.Text = "Error in BindData : " + ex.Message; 
            }
                
        }
    }
}