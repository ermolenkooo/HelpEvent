using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DAL.entities;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data.Entity;
using HelpEvent.View;
using HelpEvent.Model;

namespace HelpEvent.ViewModel
{
    public class RegViewModel : INotifyPropertyChanged
    {
        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }

        UserModel user;
        public UserModel User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        UserList allUsers = new UserList();

        List<UserModel> users;
        public List<UserModel> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        string login;

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        string fi;

        public string FI
        {
            get { return fi; }
            set
            {
                fi = value;
                OnPropertyChanged("FI");
            }
        }

        public RegViewModel()
        {
            _viewId = Guid.NewGuid();

            Users = new List<UserModel> { };
            foreach (UserModel u in allUsers.AllUsers)
            {
                Users.Add(new UserModel() { Id_user = u.Id_user, Login = u.Login, Password = u.Password });
            }
        }

        private RelayCommand regCommand;
        public RelayCommand RegCommand
        {
            get
            {
                return regCommand ??
                  (regCommand = new RelayCommand(obj =>
                  {
                      PasswordBox passwordBox = obj as PasswordBox;
                      string clearTextPassword = passwordBox.Password;

                      var u = Users
                      .Where(i => i.Login == Login).FirstOrDefault();
                      if (u != null)
                      {
                          ОшибкаРег er = new ОшибкаРег();
                          er.Show();
                      }
                      else
                      {
                          user = new UserModel();
                          user.Login = login;
                          user.Password = clearTextPassword;
                          user.newUser(user);

                          //user.FI = fi;
                          
                          MainWindow win = new MainWindow(user);
                          win.Show();
                      }
                  }));
            }
        }

        private RelayCommand logInCommand;
        public RelayCommand LogInCommand
        {
            get
            {
                return logInCommand ??
                  (logInCommand = new RelayCommand(obj =>
                  {
                      Авторизация a = new Авторизация();
                      WindowManager.CloseWindow(ViewID);
                      a.Show();
                  }));
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
