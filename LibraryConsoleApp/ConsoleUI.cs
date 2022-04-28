using System;

namespace LibraryConsoleApp
{
    public class ConsoleUI
    {
        public void RunUI()
        {
            bool running = true;
            ClassLib lib = new ClassLib();  
            string UserName;
            string Password;
            while (running)
            {
                Console.WriteLine("g - guest,  r- register, l - login, o - logout, pp - print profile, pr - print roles, pu - print users, ex - exit");
                string UserInput = Console.ReadLine().ToLower();
                switch (UserInput)
                {
                    case "g":
                        lib.CheckLoggedin();
                        lib.Login();
                        break;
                    case "r":
                        lib.Register();
                        break;
                    case "l":
                        if (lib.CheckLoggedin())
                        {
                            Console.WriteLine("Please enter your username followed by an enter then your password.");
                            UserName = Console.ReadLine();
                            Password = lib.GetHiddenConsoleInput();
                            lib.Login(UserName, Password);
                        }
                        break;
                    case "o":
                        lib.Logout();
                        break;
                    case "pu":
                        lib.PrintUsers();
                        break;
                    case "pr":
                        lib.PrintRoles();
                        break;
                    case "pp":
                        Console.WriteLine("Enter the profile you would like to print.");
                        lib.PrintProfile(Console.ReadLine());
                        break;
                    case "ex":
                        running = false;
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}