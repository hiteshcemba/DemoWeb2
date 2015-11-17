using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoWeb2.Classes;

namespace DemoWeb2
{
    public partial class CategoryNew : System.Web.UI.Page
    {

        AllDemoWeb2BLL objBLL = new AllDemoWeb2BLL();

        
        protected void Page_Load(object sender, EventArgs e)
        {
             try
            {
                lblerror.Text = "";
                lblerror.ForeColor = System.Drawing.Color.Red;
                if (!IsPostBack)
                {


                }
            }
             catch (Exception ex)
             {
                 lblerror.Text = "Error in Page_Load : " + ex.Message;
             }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {

                DemoWeb2.Model.Category objcat = new Model.Category();
                objcat._Category = txtCategory.Text;
                objcat.Email = txtEmail.Text;
                if (objBLL.CategoryDB.Add(objcat))
                {
                    lblerror.ForeColor = System.Drawing.Color.Green;
                    lblerror.Text = " Category saved successfully!"; 

                }
                else
                {
                    lblerror.Text = "Error occured while saving category , Please try again later !"; 

                }


            }
            catch (Exception ex)
            {
                lblerror.Text = "Error in btnsubmit_Click : " + ex.Message; 
            }

        }
    }
}