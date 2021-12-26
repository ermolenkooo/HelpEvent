using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HelpEvent.Model;

namespace HelpEvent.ViewModel
{
    public class RemViewModel : INotifyPropertyChanged
    {
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
