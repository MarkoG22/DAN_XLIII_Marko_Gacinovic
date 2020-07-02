using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEmployee.View;

namespace WPFEmployee.ViewModel
{
    class AdminViewModel : ViewModelBase
    {
        Admin admin;

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

    }
}
