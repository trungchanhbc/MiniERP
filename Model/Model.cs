using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Model
{
    public class User
    {
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
