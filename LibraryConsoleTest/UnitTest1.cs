using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LibraryConsoleApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateGuest()
        {
            /*ConsoleUI LibUI = new ConsoleUI();
            LibUI.RunUI();*/
            ClassLib classLib = new ClassLib();
            int test = classLib.Login();
            Assert.AreEqual(2, test);
        }

        [TestMethod]
        public void TestCreatePatron()
        {
            ClassLib classLib = new ClassLib();
            string[]? test = classLib.testRegister("newPatron","PatronPassword","P");
            Assert.AreEqual("Patron", test[2]);
            classLib.Logout();
        }
        
        [TestMethod]
        public void TestCreateLibrarian()
        {
            ClassLib classLib = new ClassLib();
            string[]? test = classLib.testRegister("newLibrarian","LibrarianPassword","L");
            Assert.AreEqual("Librarian", test[2]);
            classLib.Logout();
        }

        [TestMethod]
        public void TestCreateAdmin()
        {
            ClassLib classLib = new ClassLib();
            string[]? test = classLib.testRegister("newAdmin","AdminPassword","a");
            Assert.AreEqual("Admin", test[2]);
            classLib.Logout();
        }

        [TestMethod]
        public void TestLogin()
        {
            ClassLib classLib = new ClassLib();
            int test = classLib.Login("Admin123","password123");
            Assert.AreEqual(1, test);
            classLib.Logout();
        }

        [TestMethod]
        public void TestLogout()
        {
            ClassLib classLib = new ClassLib();
          /*  int logged = classLib.Login("Admin123","password123");
            Assert.AreEqual(logged, 1);*/
            string[]? test = classLib.Logout();
            Assert.IsNull(test);
        }

        [TestMethod]
        public void TestPrintProfile()
        {
            ClassLib classLib = new ClassLib();
            string[] test = classLib.PrintProfile("Admin123");
            string[] expected = new string[] { "Admin123", "password123", "Admin" };
            Assert.AreEqual(expected[0], test[0]);
            Assert.AreEqual(expected[1], test[1]);
            Assert.AreEqual(expected[2], test[2]);
        }
        [TestMethod]
        public void TestPrintUsers()
        {
            ClassLib classLib = new ClassLib();
            string[] expected = new string[] { "Admin123","LibKate" };
            Assert.AreEqual(expected[0], classLib.PrintUsers()[0]);
            Assert.AreEqual(expected[1], classLib.PrintUsers()[1]);
        }
        [TestMethod]
        public void TestPrintRoles()
        {
            ClassLib classLib = new ClassLib();
            Dictionary<string,int> expected = new Dictionary<string, int>() 
            {
                { "Admin",1 }, 
                {"Librarian",1 } 
            };
            Assert.AreEqual(expected["Admin"], classLib.PrintRoles()["Admin"]);
            Assert.AreEqual(expected["Librarian"], classLib.PrintRoles()["Librarian"]);
        }

        [TestMethod]
        public void TestFailedLogin() {
            ClassLib classLib = new ClassLib();
            int test = classLib.Login("Admin12", "password123");
            Assert.AreEqual(test, -1);
        }
    }
}