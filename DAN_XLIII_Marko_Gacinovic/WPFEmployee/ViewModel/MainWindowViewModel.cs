using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFEmployee.Commands;
using WPFEmployee.Models;
using WPFEmployee.View;

namespace WPFEmployee.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;

        static int id;

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value;
                OnPropertyChanged("Username");
            }
            
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;            
        }

        private ICommand logIn;
        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return logIn;
            }
        }

        private bool CanSaveExecute()
        {
            return true;
        }

        private void SaveExecute()
        {
            string usernameView = IsEmployee(username, password);

            if (usernameView == "WPFadmin")
            {
                Admin admin = new Admin();
                admin.ShowDialog();
            }
            else if (usernameView == "employee")
            {
                Employee employee = new Employee();
                employee.ShowDialog();
            }
            else if (usernameView == "modifyHR")
            {
                ModifyHR modifyHR = new ModifyHR();
                modifyHR.ShowDialog();
            }
            else if (usernameView== "modifyFinance")
            {
                ModifyFinance modifyFinance = new ModifyFinance();
                modifyFinance.ShowDialog();
            }
            else if (usernameView == "modifyRD")
            {
                ModifyRD modifyRD = new ModifyRD();
                modifyRD.ShowDialog();
            }
            else if (usernameView == "readonlyHR")
            {
                ReadonlyHR readonlyHR = new ReadonlyHR();
                readonlyHR.ShowDialog();
            }
            else if (usernameView== "readonlyFinance")
            {
                ReadonlyFinance readonlyFinance = new ReadonlyFinance();
                readonlyFinance.ShowDialog();
            }
            else if (usernameView == "readonlyRD")
            {
                ReadonlyRD readonlyRD = new ReadonlyRD();
                readonlyRD.ShowDialog();
            }
            else
            {
                MessageBox.Show("Employee does not exist.");
            }
        }

        // command for closing the window
        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return logout;
            }
        }

        /// <summary>
        /// method for closing the window
        /// </summary>
        private void CloseExecute()
        {
            try
            {
                main.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        public string IsEmployee(string userName, string password)
        {
            try
            {
                using (EmployeeEntities context = new EmployeeEntities())
                {
                    tblEmployee employee = (from x in context.tblEmployees where x.UserName == userName && x.Pass == password select x).First();
                    string username = employee.UserName;
                    id = employee.EmployeeID;
                    return username;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
