using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    public class ClassLib
    {
        LibraryDB DB = new LibraryDB();

        public void SelectMedia(string mediaName = "", string mediaType = "")
        {
            DataTable dt = DB.viewMedia();

            if(mediaName != "" && mediaType != "")
            {
                foreach(DataRow dr in dt.Rows)
                {
                   if(dr["media_name"] == mediaName && dr["media_type"] == mediaType)
                    {
                        Console.WriteLine($"Media Name: {dr["media_name"]} Media Type: {dr["media_type"]} Media ID: {dr["media_id"]} Author: {dr["author"]} Publisher: {dr["Publisher"]}");
                    }
                }
            }
            else if(mediaType == "")
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["media_name"] == mediaName)
                    {
                        Console.WriteLine($"Media Name: {dr["media_name"]} Media Type: {dr["media_type"]} Media ID: {dr["media_id"]} Author: {dr["author"]} Publisher: {dr["Publisher"]}");
                     }
                }
            }
            else if(mediaName == "")
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["media_type"] == mediaType)
                    {
                        Console.WriteLine($"Media Name: {dr["media_name"]} Media Type: {dr["media_type"]} Media ID: {dr["media_id"]} Author: {dr["author"]} Publisher: {dr["Publisher"]}");
                     }
                }
            }
        }
        public void PrintMedia()
        {
            DataTable data = DB.viewMedia();
            Console.WriteLine();
            Dictionary<string, int> colWidths = new Dictionary<string, int>();

            foreach (DataColumn col in data.Columns)
            {
                Console.Write(col.ColumnName);
                var maxLabelSize = data.Rows.OfType<DataRow>()
                        .Select(m => (m.Field<object>(col.ColumnName)?.ToString() ?? "").Length)
                        .OrderByDescending(m => m).FirstOrDefault();

                colWidths.Add(col.ColumnName, maxLabelSize);
                for (int i = 0; i < maxLabelSize - col.ColumnName.Length + 10; i++) Console.Write(" ");
            }

            Console.WriteLine();

            foreach (DataRow dataRow in data.Rows)
            {
                for (int j = 0; j < dataRow.ItemArray.Length; j++)
                {
                        Console.Write(dataRow.ItemArray[j]);
                    for (int i = 0; i < colWidths[data.Columns[j].ColumnName] - dataRow.ItemArray[j].ToString().Length + 10; i++) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public void PrintUsers()
        {
            DataTable data = DB.viewUsers();
            Console.WriteLine();
            Dictionary<string, int> colWidths = new Dictionary<string, int>();

            foreach (DataColumn col in data.Columns)
            {
                Console.Write(col.ColumnName);
                var maxLabelSize = data.Rows.OfType<DataRow>()
                        .Select(m => (m.Field<object>(col.ColumnName)?.ToString() ?? "").Length)
                        .OrderByDescending(m => m).FirstOrDefault();

                colWidths.Add(col.ColumnName, maxLabelSize);
                for (int i = 0; i < maxLabelSize - col.ColumnName.Length + 10; i++) Console.Write(" ");
            }

            Console.WriteLine();

            foreach (DataRow dataRow in data.Rows)
            {
                for (int j = 0; j < dataRow.ItemArray.Length; j++)
                {
                    Console.Write(dataRow.ItemArray[j]);
                    for (int i = 0; i < colWidths[data.Columns[j].ColumnName] - dataRow.ItemArray[j].ToString().Length + 10; i++) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void PrintRoles()
        {
            DataTable data = DB.viewRoles();
            Console.WriteLine();
            Dictionary<string, int> colWidths = new Dictionary<string, int>();

            foreach (DataColumn col in data.Columns)
            {
                Console.Write(col.ColumnName);
                var maxLabelSize = data.Rows.OfType<DataRow>()
                        .Select(m => (m.Field<object>(col.ColumnName)?.ToString() ?? "").Length)
                        .OrderByDescending(m => m).FirstOrDefault();

                colWidths.Add(col.ColumnName, maxLabelSize);
                for (int i = 0; i < maxLabelSize - col.ColumnName.Length + 10; i++) Console.Write(" ");
            }

            Console.WriteLine();

            foreach (DataRow dataRow in data.Rows)
            {
                for (int j = 0; j < dataRow.ItemArray.Length; j++)
                {
                    Console.Write(dataRow.ItemArray[j]);
                    for (int i = 0; i < colWidths[data.Columns[j].ColumnName] - dataRow.ItemArray[j].ToString().Length + 10; i++) Console.Write(" ");
                }
                Console.WriteLine();
            }

        }

        public bool SearchProfile(string UserName)
        {
            DataTable dt = DB.viewUsers();
            bool found = false;
            string username = "";
            int id = -1;
            string role = "";
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dr.ItemArray.Length; i += 3)
                {
                    string UN = dr[i].ToString();
                    string ROLE = dr[i + 1].ToString();
                    int ID = int.Parse(dr[i + 2].ToString());
                    if (UN == UserName)
                    {
                        username = UN;
                        role = ROLE;
                        id = ID;
                        found = true;
                        break;
                    }
                }

            }
            return found;
        }

        public void CheckIO(int media_id, string type)
        {
            int accountID = int.Parse(DB.Active[3]);
            if(DB.updateMedia(media_id,type,accountID) == 1)
            {
                Console.WriteLine($"Checked out.");
            }
            else
            {
                Console.WriteLine($"Checked in.");
            }
        }
        public void ChangeRole(string username, string password, int roleid)
        {
            DataTable? dt = DB.CheckLogin(username, password);
            int id = -1;
            foreach(DataRow dr in dt.Rows)
            {
                id = int.Parse(dr[0].ToString());
            }
            if (dt != null)
            {
                Console.WriteLine("Role Changed");
                int role_id = DB.updateUser(id, username, roleid);
            }
            else
            {
                Console.WriteLine($"{username} not found");
            }
        }

        public void UserDelete(int id, string username,string password )
        {
            if (DB.deleteUser(id, username, password))
            {
                Console.WriteLine($"{username} has been deleted!");
            }
            else
            {
                Console.WriteLine($"{username} not found");
            }
        }

        public void PrintProfile(string UserName)
        {
            DataTable dt = DB.viewUsers();
            bool found = false;
            string username = "";
            int id = -1;
            string role = "";
            foreach(DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dr.ItemArray.Length; i += 3)
                {
                    string UN = dr[i].ToString();
                    string ROLE = dr[i + 1].ToString();
                    int ID = int.Parse(dr[i + 2].ToString());
                    if (UN == UserName)
                    {
                        username = UN;
                        role = ROLE;
                        id = ID;
                        found = true;
                        break;
                    }
                }
             
            }
            if (found)
            {
                Console.WriteLine($"{username}#{id} is a(n) {role}");
            }
            else
            {
                Console.WriteLine($"{UserName} was not found");
            }
        }

        public bool CheckLoggedin()
        {
            if (DB.Active == null)
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
            if (UserName == "" && Password == "")
            {
                Console.WriteLine("Logged in as guest");
                DB.Active = new string[] { "guest", "guest" };
                return 4;
            }
            DataTable dt = DB.CheckLogin(UserName, Password);
            string username = "";
            string password = "";
            string role = "";
            int role_id = 0;
            int ID = -1;
            if (dt != null)
            {
                foreach(DataRow row in dt.Rows)
                {
                    ID = int.Parse(row[0].ToString());
                    username = row[1].ToString();
                    password = row[2].ToString();
                    role_id = int.Parse(row[3].ToString());
                    role = "";
                    switch (role_id)
                    {
                        case 1:
                            role = "Admin";
                            break;
                        case 2:
                            role = "Librarian";
                            break;
                        case 3:
                            role = "Patron";
                            break;
                    }
                }
                if (username == UserName && password == Password)
                {
                    Console.WriteLine($"Welcome {username} #{ID} {role}\nPassword:{password}");
                    DB.Active = new string[] { username, password, role, ID.ToString() };
                    return role_id;
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

        public void TestCheck(string username, string password)
        {
           
        }
        public void Register()
        {
            Console.WriteLine("Welcome, please enter an username.");
            string user = Console.ReadLine();
            int role_id = -1;
            bool running = true;
            string[] account = new string[4];
            while (running)
            {
                if (!SearchProfile(user))
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
                        if (role != "P" && role != "L" && role != "A")
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
                            role_id = 3;
                            break;
                        case "L":
                            role = "Librarian";
                            role_id = 2;
                            break;
                        case "A":
                            role = "Admin";
                            role_id = 1;
                            break;
                    }
                    Random rand = new Random();
                    int id = rand.Next();
                    account = new string[] { user, password, role, id.ToString()};
                    if(!DB.userCreate(id, user, password, role_id))
                    {
                        Console.WriteLine("ACCOUNT CREATION ABORTED");
                    }
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
