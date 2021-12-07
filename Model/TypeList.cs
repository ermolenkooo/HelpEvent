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
    public class TypeList : INotifyPropertyChanged
    {
        private List<TypeModel> allTypes;
        private List<DAL.entities.Type> types;
        private EventDB db = new EventDB();

        public TypeList()
        {
            types = db.Type.ToList();
            allTypes = db.Type.ToList().Select(i => new TypeModel(i)).ToList();
        }

        public List<TypeModel> AllTypes
        {
            get { return allTypes; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
