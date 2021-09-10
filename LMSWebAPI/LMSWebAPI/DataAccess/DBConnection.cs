using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSWebAPI.DataAccess
{
    public class DBConnection
    {
        public DBConnection()
        {

        }

        public static SqlConnection DBConn()
        {
            SqlConnection con = new SqlConnection("Server=DESKTOP-51BJOA3; Database=LMS; Trusted_Connection=True; MultipleActiveResultSets=True;");
            return con;
        }
    }
}
