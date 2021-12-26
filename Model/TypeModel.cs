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
    public class TypeModel : INotifyPropertyChanged
    {
        EventDB db = new EventDB();
        private DAL.entities.Type typ = new DAL.entities.Type();

        public TypeModel() { checkDB(db); }

        public TypeModel(DAL.entities.Type t)
        {
            checkDB(db);
            typ = t;
        }

        public int Id_type
        {
            get { return typ.id_type; }
            set
            {
                typ.id_type = value;
                OnPropertyChanged("Id_type");
            }
        }

        public string Name_type
        {
            get { return typ.name_type; }
            set
            {
                typ.name_type = value;
                OnPropertyChanged("Name_type");
            }
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
