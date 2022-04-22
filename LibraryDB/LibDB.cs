using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    public class LibraryDB
    {
        //Username,<Password,Role>
        private Dictionary<string, string[]> _Profiles = new Dictionary<string, string[]>()
        {
            {"Admin123", new string[] {"password123","Admin"}},
            {"LibKate", new string[] { "katelibrarian", "Librarian" }}
        };
        private string[]? _Active = new string[] {"","",""};
        

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

        public bool CheckLogin(string UserName)
        {
            if (_Profiles.ContainsKey(UserName))
            {
                return true;
            }
            else
            {
                /*Console.WriteLine("UserName and Password is invalid.");*/
                return false;
            }
        }
        static void Main(string[] arg)
        {

        }
    }
}
