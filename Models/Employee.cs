using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Employee.Models
{
    public class EmployeeDataProvider
    {
        public static List<TBL_EMPLOYEE> LoadData()
        {
            string strcon = ConfigurationManager.ConnectionStrings["live_dbName"].ConnectionString;
            List<TBL_EMPLOYEE> model = new List<TBL_EMPLOYEE>();

            SqlConnection conn = new SqlConnection(strcon);
           
            SqlCommand cmd = new SqlCommand("SP_EMPLOYEE_SELECT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    model.Add(new TBL_EMPLOYEE
                    {
                        EMPLOYEEID = Convert.ToInt32(sdr["EMPLOYEEID"]),
                        EMPLOYEENAME = sdr["EMPLOYEENAME"].ToString(),
                        PLACE = sdr["PLACE"].ToString()
                    });
                }
            }

            return model;
        }
    }
    //public class TBL_EMPLOYEE
    //{
    //    public long EMPLOYEEID { get; set; }
    //    public string EMPLOYEENAME { get; set; }
    //    public string PLACE { get; set; }
    //    public DateTime CREATEDDATE { get; set; }
    //    public DateTime UPDATEDDATE { get; set; }

    //}
}