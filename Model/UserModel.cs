using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL.entities;
using System.Windows;

namespace HelpEvent.Model
{
    public class UserModel : INotifyPropertyChanged
    {
        EventDB db = new EventDB();
        private User user = new User();

        public UserModel() { checkDB(db); }

        public UserModel(User u)
        {
            checkDB(db);
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

        public void newUser(UserModel us)
        {
            user.login = us.Login;
            user.password = us.Password;
            db.User.Add(user);
            db.SaveChanges();
        }

        private void DBException()
        {
            MessageBox.Show("Ошибка подключения к базе, приложение будет закрыто", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            Environment.Exit(0);
        }

        private void checkDB(EventDB db)
        {
            try
            {
                if (!db.Database.Exists())
                {
                    DBException();
                }
            }
            catch (System.InvalidOperationException)
            {
                DBException();
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
