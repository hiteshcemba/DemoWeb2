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
        public bool Add(DemoWeb2.Model.Employee objEmp)
        {
            try
            {

                DAL DB = new DAL(ConnectionString);

                objEmp.EmpId = GetNextEmpID();
                string sqlstring = "INSERT INTO EMPLOYEE(F_Name,L_Name,City,EmailId,Id) VALUES ('" + CommonFunctions.SqlSafe(objEmp.F_Name) + "','" +  CommonFunctions.SqlSafe(objEmp.L_Name) + "','" +  CommonFunctions.SqlSafe(objEmp.City) + "','" +  CommonFunctions.SqlSafe(objEmp.EmailId) + "'," + objEmp.Id.ToString() + ")";
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

        public int GetNextEmpID()
        {
            try
            {
                int result = -1;
                DAL DB = new DAL(ConnectionString);
                string sqlstring = "SELECT MAX(EmpId) FROM Employee";
                DataSet DS = DB.GetDataSet(sqlstring, "TABLE1");
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            if (DS.Tables[0].Rows[0][0] != DBNull.Value)
                            {
                                result = int.Parse(DS.Tables[0].Rows[0][0].ToString()) + 1;

                            }

                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}