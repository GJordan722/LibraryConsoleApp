using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LibraryConsoleApp
{
    public class LibraryDB
    {
        const string connection = "Server=DESKTOP-CIQ2956\\SQLEXPRESS; Database = LibraryDB; Trusted_Connection=true";
      
        //Username,<Password,Role>
        private Dictionary<string, string[]> _Profiles = new Dictionary<string, string[]>()
        {
            {"Admin123", new string[] {"password123","Admin"}},
            {"LibKate", new string[] { "katelibrarian", "Librarian" }}
        };
        //                      {username,password,role,account_id}
        private string[]? _Active = null;
        

        public LibraryDB()
        {

            
        }

        public Dictionary<string, string[]> Profiles
        {
            get { return _Profiles; }
        }

        public string[]? Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public string[]? Profile(string Username)
        {
            if (!_Profiles.ContainsKey(Username))
            {
                Console.WriteLine("Username is invalid");
                return null;
            }
            return _Profiles[Username];
        }



        public DataTable CheckLogin(string UserName, string Password)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand($"EXEC [dbo].[checkUserValid] {UserName},{Password}",con))
                {

                    DataTable results = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(results);
                    da.Dispose();
                    return results;
                }
                con.Close();
            }
        }

        public int updateUser(int account_id, string username,int role_id)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                int newRole_id = -1;
                con.Open();
                using (SqlCommand cmd = new SqlCommand($"EXEC [dbo].[updateUser] {account_id},{username},{role_id}", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        newRole_id = dr.GetInt32(0);
                    }
                    dr.Close();
                    return newRole_id;
                }
                con.Close();
            }
        }

        public bool deleteUser(int account_id, string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                int result = 0;
                con.Open();
                using (SqlCommand cmd = new SqlCommand($"EXEC [dbo].[deleteUser] {account_id},{username},{password}", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr.GetInt32(0);
                    }
                    dr.Close();
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                con.Close();
            }
        }

        public int updateMedia(int media_id, string media_type, int account_id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand($"EXEC [dbo].[updateMedia] {media_id},{media_type},{account_id}", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr.GetInt32(0);
                    }
                    dr.Close();
                }
                con.Close();
            }
            return result;
        }

        public DataTable viewMedia()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Media", con))
                {
                    DataTable results = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(results);
                    da.Dispose();
                    return results;
                }
                con.Close();
            }
        }

        public bool userCreate(int account_id, string username, string password, int role_id)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                int result = 0;
                con.Open();
                using (SqlCommand cmd = new SqlCommand($"EXEC [dbo].[userCreate] {account_id},{username},{password},{role_id}", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr.GetInt32(0);
                    }
                    dr.Close();
                    if(result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                con.Close();
            }
        }

        public DataTable viewUsers()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand($"EXEC [dbo].[viewUsers]", con))
                {
                    DataTable results = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(results);
                    da.Dispose();
                    return results;
                }
                con.Close();
            }
        }

        public DataTable viewRoles()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand($"EXEC [dbo].[viewRoles]", con))
                {
                    DataTable results = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(results);
                    da.Dispose();
                    return results;
                }
                con.Close();
            }
        } 

        static void Main(string[] arg)
        {

        }
    }
}
