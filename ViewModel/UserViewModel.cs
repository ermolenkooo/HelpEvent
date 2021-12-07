using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HelpEvent.Model;

namespace HelpEvent.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        private UserModel users;
        public UserViewModel(UserModel u)
        {
            users = u;
        }

        public string Login
        {
            get { return users.Login; }
            set
            {
                users.Login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return users.Password; }
            set
            {
                users.Password = value;
                OnPropertyChanged("Password");
            }
        }

        public int Id_user
        {
            get { return users.Id_user; }
            set
            {
                users.Id_user = value;
                OnPropertyChanged("Id_user");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
