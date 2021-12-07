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
    public class CategoryList : INotifyPropertyChanged
    {
        private List<CategoryModel> allCategories;
        private List<Category> categories;
        private EventDB db = new EventDB();

        public CategoryList()
        {
            categories = db.Category.ToList();
            allCategories = db.Category.ToList().Select(i => new CategoryModel(i)).ToList();
        }

        public List<CategoryModel> AllCategories
        {
            get { return allCategories; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
