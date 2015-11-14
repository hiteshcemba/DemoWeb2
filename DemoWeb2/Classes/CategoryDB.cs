using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DemoWeb2.Model; 

namespace DemoWeb2.Classes
{
    public class CategoryDB
    {
         public string ConnectionString { get; set; }
         public CategoryDB(string strconnectionstring)
        {
            ConnectionString = strconnectionstring;
        }

         public List<DemoWeb2.Model.Category> All()
         {
             try
             {
                 List<DemoWeb2.Model.Category> objresult = new List<DemoWeb2.Model.Category>();
                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "SELECT * FROM Table2";
                 DataSet DS = DB.GetDataSet(sqlstring, "TABLE1");
                 if (DS != null)
                 {
                     if (DS.Tables.Count > 0)
                     {
                         foreach (DataRow DR in DS.Tables[0].Rows)
                         {
                             DemoWeb2.Model.Category objCAT = new DemoWeb2.Model.Category();
                             objCAT.ID = int.Parse(DR["ID"].ToString());
                             objCAT._Category = DR["CATEGORY"].ToString();
                             objCAT.Email = DR["EMAIL"].ToString();
                             objresult.Add(objCAT);
                         }
                     }
                 }
                 return objresult;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
         public bool Add(DemoWeb2.Model.Category objCat)
         {
             try
             {

                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "INSERT INTO TABLE2(CATEGORY,EMAIL) VALUES ('" + objCat._Category + "','" + objCat.Email  + "')";
                 int ROWCOUNT = DB.ExecuteCommandNoQuery(sqlstring);
                 if (ROWCOUNT > 0)
                     return true;
                 else
                     return false;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
         //public Category Find(int id)
         //{
         //    try
         //    {
         //        Category objResult = null;

         //        DAL DB = new DAL(ConnectionString);
         //        string sqlstring = "SELECT * FROM CATEGORY WHERE CATEGORYID = " + id.ToString();
         //        DataSet DS = DB.GetDataSet(sqlstring, "TABLE1");
         //        if (DS != null)
         //        {
         //            if (DS.Tables.Count > 0)
         //            {
         //                if (DS.Tables[0].Rows.Count > 0)
         //                {
         //                    DataRow DR = DS.Tables[0].Rows[0];
         //                    objResult = new Category();
         //                    objResult.CategoryID = int.Parse(DR["CATEGORYID"].ToString());
         //                    objResult.CategoryName = DR["CATEGORYNAME"].ToString();
         //                }
         //            }
         //        }
         //        return objResult;
         //    }
         //    catch (Exception ex)
         //    {
         //        throw ex;
         //    }
         //}
         //public bool Edit(Category objCat)
         //{
         //    try
         //    {
         //        DAL DB = new DAL(ConnectionString);
         //        string sqlstring = "UPDATE CATEGORY SET CATEGORYNAME = '" + objCat.CategoryName + "' WHERE CATEGORYID = " + objCat.CategoryID.ToString();
         //        int ROWCOUNT = DB.ExecuteCommandNoQuery(sqlstring);
         //        if (ROWCOUNT > 0)
         //            return true;
         //        else
         //            return false;
         //    }
         //    catch (Exception ex)
         //    {
         //        throw ex;
         //    }

         //}
         //public bool Delete(Category objCat)
         //{
         //    try
         //    {
         //        DAL DB = new DAL(ConnectionString);
         //        string sqlstring = "DELETE FROM CATEGORY WHERE CATEGORYID = " + objCat.CategoryID.ToString();
         //        int ROWCOUNT = DB.ExecuteCommandNoQuery(sqlstring);
         //        if (ROWCOUNT > 0)
         //            return true;
         //        else
         //            return false;
         //    }
         //    catch (Exception ex)
         //    {
         //        throw ex;
         //    }
         //}




    }
   
}