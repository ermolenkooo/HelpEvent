using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL.entities;

namespace HelpEvent.Model
{
    public class UserModel : INotifyPropertyChanged
    {
        EventDB db = new EventDB();
        private User user = new User();

        public UserModel() { }

        public UserModel(User u)
        {
            user = u;
        }

        public string Login
        {
            get { return user.login; }
            set
            {
                user.login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return user.password; }
            set
            {
                user.password = value;
                OnPropertyChanged("Password");
            }
        }

        public int Id_user
        {
            get { return user.id_user; }
            set
            {
                user.id_user = value;
                OnPropertyChanged("Id_user");
            }
        }

        //public string FI
        //{
        //    get { return user.FI; }
        //    set
        //    {
        //        user.FI = value;
        //        OnPropertyChanged("FI");
        //    }
        //}

        public void newUser(UserModel us)
        {
            user.login = us.Login;
            user.password = us.Password;
            db.User.Add(user);
            db.SaveChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
