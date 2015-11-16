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

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }
        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            BindData();
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
          
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            
        }

        protected void Grid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType != ListItemType.Header))
                {
                    e.Item.Cells[5].Text = "Test";
                }

            }
            catch (Exception ex)
            {
                lblerror.Text = "Error in Grid_ItemDataBound : " + ex.Message;
            }
        }

    }
}