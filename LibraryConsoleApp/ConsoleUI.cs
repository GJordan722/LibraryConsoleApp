using System;

namespace LibraryConsoleApp
{
    public class ConsoleUI
    {
        public int UILVL = 0; //Determined by which role is logged in and how much access they have.
        public void RunUI()
        {
            bool running = true;
            ClassLib lib = new ClassLib();  
            string UserName;
            string Password;
            while (running)
            {
                switch (UILVL) {
                    case 0:
                        Console.WriteLine("g - guest,  r- register, l - login, pp - print profile, ex - exit");
                        string UserInput = Console.ReadLine().ToLower();
                        switch (UserInput)
                        {
                            case "g":
                                lib.CheckLoggedin();
                                UILVL = lib.Login();
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
                                    UILVL = lib.Login(UserName, Password);
                                }
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
                        break;
                   case 1:

                        Console.WriteLine("d - delete user, u - update user, c - check-in/out, v - view media, o - logout, pp - print profile, pr - print roles, pu - print users, ex - exit");
                        UserInput = Console.ReadLine().ToLower();
                        string username = "";
                        string password = "";
                        switch (UserInput)
                        {
                            case "d":
                                Console.WriteLine("Enter the username, password, and account id(each followed by enter) for the account to be deleted.");
                                 username = Console.ReadLine();
                                 password = Console.ReadLine();
                                int ID = int.Parse(Console.ReadLine());
                                lib.UserDelete(ID,username,password);
                                break;
                            case "u":
                                Console.WriteLine("Enter username and password(each followed by enter) for the account to be updated.");
                                 username = Console.ReadLine();
                                 password = Console.ReadLine();
                                Console.WriteLine("Enter new role id.");
                                int role_id = int.Parse(Console.ReadLine());
                                lib.ChangeRole(username, password, role_id);
                                break;
                            case "c":
                                Console.WriteLine("Enter the media ID you would like to check in/out.");
                                int mediaID = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter type of media.");
                                string mediaType = Console.ReadLine();
                                lib.CheckIO(mediaID, mediaType);
                                break;
                            case "v":
                                lib.PrintMedia();
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
                        break;

                    case 2:

                        Console.WriteLine("c - check-in/out, v - view media, o - logout, pp - print profile, pr - print roles, pu - print users, ex - exit");
                        UserInput = Console.ReadLine().ToLower();
                        switch (UserInput)
                        {
                            case "c":
                                Console.WriteLine("Enter the media ID you would like to check in/out.");
                                int mediaID = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter type of media.");
                                string mediaType = Console.ReadLine();
                                lib.CheckIO(mediaID, mediaType);
                                break;
                            case "v":
                                lib.PrintMedia();
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
                        break;

                    case 3:

                        Console.WriteLine("v - view media, c - check-in/out, o - logout, pp - print profile, pu - print users, ex - exit");
                        UserInput = Console.ReadLine().ToLower();
                        switch (UserInput)
                        {
                            case "v":
                                lib.PrintMedia();
                                break;
                            case "c":
                                Console.WriteLine("Enter the media ID you would like to check in/out.");
                                int mediaID = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter type of media.");
                                string mediaType = Console.ReadLine();
                                lib.CheckIO(mediaID, mediaType);
                                break;
                            case "o":
                                lib.Logout();
                                break;
                            case "pu":
                                lib.PrintUsers();
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
                        break;

                    case 4:

                        Console.WriteLine("v - view media, r- register, l - login, pp - print profile, pu - print users, ex - exit");
                        UserInput = Console.ReadLine().ToLower();
                        switch (UserInput)
                        {
                            case "v":
                                lib.PrintMedia();
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
                                    UILVL = lib.Login(UserName, Password);
                                }
                                break;
                            case "pu":
                                lib.PrintUsers();
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
                        break;
                }
            }
        }
    }
}