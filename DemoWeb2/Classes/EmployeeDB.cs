using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoWeb2.Classes
{
    public class EmployeeDB
    {
        public string ConnectionString { get; set; }
        public EmployeeDB(string strconnectionstring)
        {
            ConnectionString = strconnectionstring;
        }

        public List<DemoWeb2.Model.Employee> All()
        {
            try
            {
                List<DemoWeb2.Model.Employee> objresult = new List<DemoWeb2.Model.Employee>();
                DAL DB = new DAL(ConnectionString);
                string sqlstring = "SELECT * FROM Employee";
                DataSet DS = DB.GetDataSet(sqlstring, "TABLE1");
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        foreach (DataRow DR in DS.Tables[0].Rows)
                        {
                            DemoWeb2.Model.Employee objCAT = new DemoWeb2.Model.Employee();
                            objCAT.EmpId = int.Parse(DR["EmpId"].ToString());
                            objCAT.F_Name = DR["F_Name"].ToString();
                            objCAT.L_Name = DR["L_Name"].ToString();
                            objCAT.City = DR["City"].ToString();
                            objCAT.EmailId = DR["EmailId"].ToString();
                            if (DR["EmpJoining"] != DBNull.Value)
                            objCAT.EmpJoining = Convert.ToDateTime((DR["EmpJoining"]));
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

    }
}