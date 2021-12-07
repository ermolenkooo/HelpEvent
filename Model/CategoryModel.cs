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
    public class CategoryModel : INotifyPropertyChanged
    {
        private Category cat = new Category();

        public CategoryModel() { }

        public CategoryModel(Category c)
        {
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
