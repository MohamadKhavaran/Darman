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

        private SqlConnection _connection;
        public PersonRepository()
        {
            _connection = new SqlConnection(ConnectionString);
        }

        public bool insert(string Name, string SSID, string FatherName)
        {
            try
            {
                string Query = "insert into People values (@Name ,@SSID,@FatherName)";
                SqlCommand sqlCommand = new SqlCommand(Query, _connection);
                sqlCommand.Parameters.AddWithValue("Name", Name);
                sqlCommand.Parameters.AddWithValue("SSID", SSID);
                sqlCommand.Parameters.AddWithValue("FatherName", FatherName);
                _connection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                string Query = "Delete People Where Id = @Id";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = _connection;
                sqlCommand.CommandText = Query;
                _connection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

            finally

            {
                _connection.Close();
            }
        }

        public DataTable SearchAll()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string Quary = "Select Name as 'نام و نام خانوادگی '  , SSID as 'کد ملی', FatherName as 'نام  پدر ' From People";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Quary, _connection);
                _connection.Open();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                return dataTable;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool update(int Id, string Name, string SSID, string FatherName)
        {
            try
            {
                string Quary = "Update People Set Name=@Name,FatherName=@FatherName,SSID=@SSID Where Id=" + Id;
                SqlCommand sqlCommand = new SqlCommand(Quary, _connection);
                _connection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
