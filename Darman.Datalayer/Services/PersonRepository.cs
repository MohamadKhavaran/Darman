using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darman.Datalayer.Repository;
using System.Data.SqlClient;
namespace Darman.Datalayer.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string ConnectionString = "Server=.;Initial Catalog=DarmanDB;Integrated Security=true";

        public bool insert(string Name, string SSID, string FatherName)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string Query = "insert into People values (@Name ,@SSID,@FatherName)";
            SqlCommand sqlCommand = new SqlCommand(Query, con);
            sqlCommand.Parameters.AddWithValue("Name", Name);
            sqlCommand.Parameters.AddWithValue("SSID", SSID);
            sqlCommand.Parameters.AddWithValue("FatherName", FatherName);
            con.Open();
            sqlCommand.ExecuteNonQuery();
            con.Close();     
            return true;
        }

        public bool delete(int Id)
        {
            return true;
        }

        public DataTable SearchAll()
        {
            DataTable dt = new DataTable();
            return dt;

        }

        public bool update(int Id, string Name, string SSID, string FatherName)
        {
            return true;
        }
    }
}
