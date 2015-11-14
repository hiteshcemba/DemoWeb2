using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient; 
using System.Data;
namespace DemoWeb2.Classes
{
    class DAL
    {
        public string ConnectionString { get; set; }
        public SqlConnection  DBConnection { get; set; }
        public SqlCommand  DBCommand { get; set; }
        public SqlTransaction  DBTransaction { get; set; }
        public string UserName { get; set; }
        public string Server { get; set; }
        public string Password { get; set; }

        public  DAL(string _tmpconnectionstring)
        {
            ConnectionString = _tmpconnectionstring;
        }
        public void OpenConnection()
        {
            DBConnection = new SqlConnection(ConnectionString);
            DBConnection.Open();

        }
        public void CloseConnection()
        {
            if (DBConnection.State == System.Data.ConnectionState.Open)
                DBConnection.Close();
        }
        public void CreateTrans()
        {
            DBTransaction = DBConnection.BeginTransaction();
        }
        public void RollBackTrans()
        {
            DBTransaction.Rollback();
        }
        public void BeginTrans()
        {
            DBCommand.Transaction = DBTransaction;
           
        }
        public void CommitTrans()
        {
            DBTransaction.Commit();
        }
        public void CreateCommand()
        {
            DBCommand = DBConnection.CreateCommand();
        }

        public int ExecuteCommandNoQuery(string strSQL)
        {
            int NumRows = -1;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, connection))
                {
                    connection.Open();
                    NumRows = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                connection.Close();
            }
            return NumRows;
        }
        public int ExecuteCommandNoQuery(string strSQL, SqlParameter[] _params, string ErrNumParamName, string ErrMessgParamName)
        {
            int NumRows = -1;
            //int ErrNum = 0;
            string ErrMsg="";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlConnection.ClearAllPools();
                using (SqlCommand cmd = new SqlCommand(strSQL, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (SqlParameter par in _params)
                    {
                        cmd.Parameters.Add(par);
                    }
                    connection.Open();
                    NumRows = cmd.ExecuteNonQuery();
                    if (int.TryParse(cmd.Parameters[ErrNumParamName].Value.ToString(), out NumRows))
                    {   if (NumRows != 0)
                        {
                            ErrMsg = cmd.Parameters[ErrMessgParamName].Value.ToString();
                              if(ErrMsg!="SUCCESS")
                                {  
                                  connection.Close();
                                  SqlConnection.ClearAllPools();
                                  throw new Exception(ErrMsg);
                                }

                        }

                        cmd.Dispose();
                    }
                 connection.Close();
                 SqlConnection.ClearAllPools();
                }
            }
            return NumRows;
        }

        public DataSet GetDataSet(string strSQL, string TableName)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(strSQL, connection);
                da.Fill(ds, TableName);
                connection.Close();
            }
            return ds;
        }



    }
}
