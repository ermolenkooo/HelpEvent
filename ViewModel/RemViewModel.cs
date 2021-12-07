using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DAL.entities;
using System.Data.SqlClient;
using System.Data.Entity;
using HelpEvent.View;
using HelpEvent.Model;
namespace HelpEvent.ViewModel
{
    public class RemViewModel : INotifyPropertyChanged
    {
        public Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }

        public List<RemOutput> rems = new List<RemOutput>();
        public List<RemOutput> Rems
        {
            get { return rems; }
            set
            {
                rems = value;
                OnPropertyChanged("Rems");
            }
        }

        public RemViewModel(List<RemOutput> r)
        {
            _viewId = Guid.NewGuid();

            Rems = r;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
