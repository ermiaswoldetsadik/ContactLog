using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ContactLog.econtactClasses
{
    class contactClass
    {
        public int ContactID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }

        public string Gender { get; set; }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public DataTable Select()
        {
            //database connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //sql query
                string sql = "SELECT = FROM tbl_contact";
                //creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //sql adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        //insert data
        public bool Insert (contactClass c)
        {
            //creat default
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //insert data
                string sql = "INSERT INTO tbl_contact(FirstName,LastName,ContactNo,Address,Gender) VALUES(@FirstName,@LastName,@ContactNo,@Address,@Gender)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                //open connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
                return isSuccess;
        }
        //method to update
        public bool Update(contactClass c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //sql to update
                string sql = "UPDATE tbl_contact SET FirstName=@FirstName,LastName=@LastName,ContactNo=@ContactNo,Address=@Address,Gender=@Gender WHERE ContactID=@ContactID";
                //creat sql command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);
                //open db conn
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        //method to delete
        public bool Delete(contactClass c)
        {
            bool isSuccess = false;
            return isSuccess;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //sql to delete
                string sql = "Delete FROM tbl_contact WHERE ContactID=ContactID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("ContactID", c.ContactID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }

}
