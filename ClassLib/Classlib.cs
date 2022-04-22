using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    public class ClassLib
    {
        LibraryDB DB = new LibraryDB();
        public string[] PrintUsers()
        {
            string[] users = new string[DB.Profiles.Count];
            int count = 0;
            foreach (string key in DB.Profiles.Keys)
            {
                Console.WriteLine(key);
                users[count] = key;
                count++;
            }
            return users;
        }

        public Dictionary<string,int> PrintRoles()
        {
            Dictionary<string, int> roles = new Dictionary<string, int>();
            foreach (string key in DB.Profiles.Keys)
            {
                if (roles.ContainsKey(key))
                {
                    roles[key]++;
                }
                else
                {
                    roles.Add(DB.Profiles[key][1], 1);
                }
            }
            foreach (string key in roles.Keys)
            {
                Console.WriteLine($"{key}: {roles[key]}");
            }
            return roles;
        }

        public string[] PrintProfile(string UserName)
        {
            string[]? Details = DB.Profile(UserName);
            if (Details != null)
            {
                if (DB.Active[0] == UserName)
                {
                    Console.WriteLine($"{UserName}: {Details[1]}\n{Details[0]}");
                }
                else
                {
                    Console.WriteLine($"{UserName}: {Details[1]}");
                }
                return new string[] { UserName, Details[0], Details[1] };
            }
            else
            {
                return new string[] {""};
            }
        }

        public bool CheckLoggedin()
        {
            if (DB.Active[0] == "")
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Already logged in as {DB.Active[0]}");
                return false;
            }
        }
        public string GetHiddenConsoleInput()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && input.Length > 0) input.Remove(input.Length - 1, 1);
                else if (key.Key != ConsoleKey.Backspace) input.Append(key.KeyChar);
            }
            return input.ToString();
        }

        public int Login(string UserName = "", string Password = "")
        {
            if (CheckLoggedin())
            {
                if (DB.Profiles.ContainsKey(UserName) && DB.Profiles[UserName][0] == Password)
                {
                    Console.WriteLine($"Welcome {UserName}");
                    DB.Active = new string[] { UserName, DB.Profiles[UserName][0], DB.Profiles[UserName][1] };
                    return 1;
                }
                else if (UserName == "" && Password == "")
                {
                    Console.WriteLine("Logged in as guest");
                    DB.Active = new string[] { "guest", "guest" };
                    return 2;
                }
                else
                {
                    Console.WriteLine("Username or password invalid.");
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }

        public string[]? Logout()
        {
            if (DB.Active == null)
            {
                Console.WriteLine("No one currently logged in.");
            }
            else
            {
                Console.WriteLine($"Goodbye {DB.Active[0]}");
                DB.Active = null;
            }
            return DB.Active;
        }
        public void Register()
        {
            Console.WriteLine("Welcome, please enter an username.");
            string user = Console.ReadLine();
            bool running = true;
            string[] account = new string[3];
            while (running)
            {
                if (!DB.CheckLogin(user))
                {
                    Console.WriteLine("Enter a password.");
                    string password = GetHiddenConsoleInput();
                    Console.WriteLine("Enter password again to verify");
                    string passwordCheck = GetHiddenConsoleInput();
                    while (password != passwordCheck)
                    {
                        Console.WriteLine("Passwords do not match please try again. [S]how Password");
                        password = GetHiddenConsoleInput();
                        if (password == "s" || password == "S")
                        {
                            password = Console.ReadLine();
                            Console.WriteLine("Verify password");
                            passwordCheck = Console.ReadLine();
                        }
                        else
                        {
                            password = GetHiddenConsoleInput();
                            Console.WriteLine("Verify password");
                            passwordCheck = GetHiddenConsoleInput();
                        }
                    }
                    Console.WriteLine($"Welcome, {user} are you a [P]atron,new [L]ibrarian, or new [A]dmin");
                    string role = Console.ReadLine().ToUpper();
                    bool rolecheck = true;
                    while (rolecheck)
                    {
                        if (role != "G" && role != "P" && role != "L" && role != "A")
                        {
                            Console.WriteLine("Incorrect input please enter [P] for patron,[L] for librarian, or [A] for admin");
                            role = Console.ReadLine().ToUpper();
                        }
                        else
                        {
                            rolecheck = false;
                            break;
                        }
                    }
                    switch (role)
                    {
                        case "P":
                            role = "Patron";
                            break;
                        case "L":
                            role = "Librarian";
                            break;
                        case "A":
                            role = "Admin";
                            break;
                    }
                    account = new string[] { user, password, role };
                    DB.Profiles.Add(user, new string[] { password, role });
                    DB.Active = account;
                    running = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Username already taken please enter a different one.");
                    user = Console.ReadLine();
                }
            }
        }

        public string[] testRegister(string user, string password, string role)
        {
            if (DB.Profiles.ContainsKey(user))
            {
                return new string[] { "", "", "" };
            }
            if(role.ToUpper() =="P" || role.ToUpper() == "L" || role.ToUpper() =="A")
            {
                switch (role.ToUpper())
                {
                    case "P":
                        role = "Patron";
                        break;
                    case "L":
                        role = "Librarian";
                        break;
                    case "A":
                        role = "Admin";
                        break;
                }
                return new string[] { user, password, role };
            }
            else
            {
                return new string[] { user, password, "" };
            }
        }
    }
}
