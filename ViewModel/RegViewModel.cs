using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using HelpEvent.View;
using HelpEvent.Model;

namespace HelpEvent.ViewModel
{
    public class RegViewModel : INotifyPropertyChanged
    {
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

        Window parentWindow = new Window();

        public RegViewModel(Window w)
        {
            parentWindow = w;
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

                      var u = allUsers.AllUsers
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
                          
                          MainWindow win = new MainWindow(user);
                          win.WindowState = parentWindow.WindowState;
                          win.Show();
                          parentWindow.Close();
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
                      a.WindowState = parentWindow.WindowState;
                      a.Show();
                      parentWindow.Close();
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
