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
    public class CategoryModel : INotifyPropertyChanged
    {
        EventDB db = new EventDB();
        private Category cat = new Category();

        public CategoryModel() { checkDB(db); }

        public CategoryModel(Category c)
        {
            checkDB(db);
            cat = c;
        }

        public int Id_category
        {
            get { return cat.id_category; }
            set
            {
                cat.id_category = value;
                OnPropertyChanged("Id_category");
            }
        }

        public string Name_category
        {
            get { return cat.name_category; }
            set
            {
                cat.name_category = value;
                OnPropertyChanged("Name_category");
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
