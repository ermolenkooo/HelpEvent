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
    public class UserList : INotifyPropertyChanged
    {
        private List<UserModel> allUsers;
        private List<User> users;
        private EventDB db = new EventDB();

        public UserList()
        {
            users = db.User.ToList();
            allUsers = db.User.ToList().Select(i => new UserModel(i)).ToList();
        }

        public List<UserModel> AllUsers
        {
            get { return allUsers; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
