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
                //versoin 1
                #region Stored Procedure
                string Query = "InsertPerson";
                SqlCommand sqlCommand = new SqlCommand(Query, _connection);
                sqlCommand.Parameters.AddWithValue("@Name", Name);
                sqlCommand.Parameters.AddWithValue("@SSID", SSID);
                sqlCommand.Parameters.AddWithValue("@FatherName", FatherName);
                _connection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                return true;
                #endregion
                //version 2
                #region Normal Connection
                //string Query = "insert into People values (@Name ,@SSID,@FatherName)";
                //SqlCommand sqlCommand = new SqlCommand(Query, _connection);
                //sqlCommand.Parameters.AddWithValue("Name", Name);
                //sqlCommand.Parameters.AddWithValue("SSID", SSID);
                //sqlCommand.Parameters.AddWithValue("FatherName", FatherName);
                //_connection.Open();
                //sqlCommand.ExecuteNonQuery();
                //return true;
                #endregion
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
                sqlCommand.Parameters.AddWithValue("Id", Id);
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
                // No Management On DataSources : Just Copy From SqlServer To DataGridView
                #region Version 1.0 
                //string Quary = "Select Name as 'نام و نام خانوادگی '  , SSID as 'کد ملی', FatherName as 'نام  پدر ' From People";
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(Quary, _connection);
                //_connection.Open();
                //dataAdapter.Fill(dataTable);
                //return dataTable;
                #endregion
                //Select All Data From SqlServer To DataGridView + Management & Create Manually Columns
                #region Version 2.0
                string Quary = "Select * From People";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Quary, _connection);
                _connection.Open();
                dataAdapter.Fill(dataTable);
                return dataTable;
                #endregion

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
                string Quary = "UpdatePerson";
                SqlCommand sqlCommand = new SqlCommand(Quary, _connection);
                sqlCommand.Parameters.AddWithValue("@Id", Id);
                sqlCommand.Parameters.AddWithValue("@Name", Name);
                sqlCommand.Parameters.AddWithValue("@SSID", SSID); 
                sqlCommand.Parameters.AddWithValue("@FatherName",FatherName);
                _connection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable SearchByParam(string Name)
        {
            DataTable dataTable = new DataTable();
            try
            {

                string Query = "Select  * From People Where Name Like @Name ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Query,_connection);
                _connection.Open();
                // dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Name", $"%{Name}%");
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

        public DataTable GetById(int Id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string Query = $"select * From People where Id = {Id}";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, _connection);
                _connection.Open();
                sqlDataAdapter.Fill(dataTable);
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
    }
}
