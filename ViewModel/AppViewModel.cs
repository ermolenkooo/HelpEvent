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
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public Guid _viewId;
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

        EventList allEvents = new EventList();

        List<EventModel> events;
        public List<EventModel> Events {
            get { return events; }
            set
            {
                events = value;
                OnPropertyChanged("Events");
            }
        }

        List<EventModel> events1;
        public List<EventModel> Events1
        {
            get { return events1; }
            set
            {
                events1 = value;
                OnPropertyChanged("Events1");
            }
        }

        List<EventModel> events2;
        public List<EventModel> Events2
        {
            get { return events2; }
            set
            {
                events2 = value;
                OnPropertyChanged("Events2");
            }
        }

        CategoryList allCategories = new CategoryList();
        public ObservableCollection<CategoryModel> Categories { get; set; }

        VenueList allVenues = new VenueList();
        public ObservableCollection<VenueModel> Venues { get; set; }

        TypeList allTypes = new TypeList();
        public ObservableCollection<TypeModel> Types { get; set; }

        CityList allCities = new CityList();
        public ObservableCollection<CityModel> Cities { get; set; }

        CityModel selectedCity; 
        CategoryModel selectedCategory; 
        EventModel selectedEvent;
        TypeModel selectedType;

        public CityModel SelectedCity 
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        public TypeModel SelectedType 
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }

        public CategoryModel SelectedCategory 
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public HelpEvent.Model.EventModel SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value;
                OnPropertyChanged("SelectedEvent");
            }
        }

        public ApplicationViewModel(UserModel user)
        {
            _viewId = Guid.NewGuid();

            this.User = user;

            Events = new List<EventModel> { };
            foreach(EventModel ev in allEvents.AllEvents)
            {
                Events.Add(new EventModel() { Id = ev.Id, Description = ev.Description, Id_category = ev.Id_category, Id_organizer= ev.Id_organizer, Id_type=ev.Id_type, Id_venue=ev.Id_venue, Name=ev.Name, Number_of_seats=ev.Number_of_seats, Poster=ev.Poster, Time=ev.Time });
            }

            Events1 = new List<EventModel> { };
            Events2 = new List<EventModel> { };

            int i = 0;
            while (i < Events.Count) 
            {
                if (i % 2 == 0)
                    Events1.Add(Events[i]);
                else
                    Events2.Add(Events[i]);
                i++;
            }

            Categories = new ObservableCollection<CategoryModel> { };
            foreach (CategoryModel c in allCategories.AllCategories)
            {
                Categories.Add(new CategoryModel() { Name_category = c.Name_category, Id_category = c.Id_category }) ;
            }

            Venues = new ObservableCollection<VenueModel> { };
            foreach (VenueModel v in allVenues.AllVenues)
            {
                Venues.Add(new VenueModel() { Id_venue = v.Id_venue, Id_city = v.Id_city, Address = v.Address });
            }

            Types = new ObservableCollection<TypeModel> { };
            foreach (TypeModel t in allTypes.AllTypes)
            {
                Types.Add(new TypeModel() { Name_type = t.Name_type, Id_type = t.Id_type });
            }

            Cities = new ObservableCollection<CityModel> { };
            foreach (CityModel c in allCities.AllCities)
            {
                Cities.Add(new CityModel() { Name_city = c.Name_city, Id_city = c.Id_city });
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
                      Авторизация login = new Авторизация(); //close window
                      WindowManager.CloseWindow(ViewID);
                      login.Show();
                  }));
            }
        }

        private RelayCommand cat1Command;
        public RelayCommand Cat1Command 
        {
            get
            {
                return cat1Command ??
                  (cat1Command = new RelayCommand(obj =>
                  {
                      selectedCategory = Categories.Where(i => i.Id_category == 1).FirstOrDefault();
                  }));
            }
        }

        private RelayCommand cat2Command;
        public RelayCommand Cat2Command 
        {
            get
            {
                return cat2Command ??
                  (cat2Command = new RelayCommand(obj =>
                  {
                      selectedCategory = Categories.Where(i => i.Id_category == 2).FirstOrDefault();
                  }));
            }
        }

        private RelayCommand cat3Command;
        public RelayCommand Cat3Command 
        {
            get
            {
                return cat3Command ??
                  (cat3Command = new RelayCommand(obj =>
                  {
                      selectedCategory = Categories.Where(i => i.Id_category == 3).FirstOrDefault();
                  }));
            }
        }

        private RelayCommand cat4Command;
        public RelayCommand Cat4Command 
        {
            get
            {
                return cat4Command ??
                  (cat4Command = new RelayCommand(obj =>
                  {
                      selectedCategory = Categories.Where(i => i.Id_category == 4).FirstOrDefault();
                  }));
            }
        }

        private RelayCommand cat5Command;
        public RelayCommand Cat5Command 
        {
            get
            {
                return cat5Command ??
                  (cat5Command = new RelayCommand(obj =>
                  {
                      selectedCategory = Categories.Where(i => i.Id_category == 5).FirstOrDefault();
                  }));
            }
        }

        private RelayCommand cat6Command;
        public RelayCommand Cat6Command 
        {
            get
            {
                return cat6Command ??
                  (cat6Command = new RelayCommand(obj =>
                  {
                      selectedCategory = Categories.Where(i => i.Id_category == 6).FirstOrDefault();
                  }));
            }
        }

        private RelayCommand cat7Command;
        public RelayCommand Cat7Command 
        {
            get
            {
                return cat7Command ??
                  (cat7Command = new RelayCommand(obj =>
                  {
                      selectedCategory = Categories.Where(i => i.Id_category == 7).FirstOrDefault();
                  }));
            }
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand //
        {
            get
            {
                return searchCommand ??
                  (searchCommand = new RelayCommand(obj =>
                  {
                      Events = new List<EventModel> { };
                      foreach (EventModel ev in allEvents.AllEvents)
                      {
                          Events.Add(new EventModel() { Id = ev.Id, Description = ev.Description, Id_category = ev.Id_category, Id_organizer = ev.Id_organizer, Id_type = ev.Id_type, Id_venue = ev.Id_venue, Name = ev.Name, Number_of_seats = ev.Number_of_seats, Poster = ev.Poster, Time = ev.Time });
                      }

                      Events = Events
                        .Join(Venues, e => e.Id_venue, v => v.Id_venue, (e, v) => new { e.Id, e.Description, e.Id_category, e.Id_organizer, e.Id_type, e.Id_venue, e.Name, e.Number_of_seats, e.Poster, e.Time, v.Id_city })
                        .Where(i => i.Id_type == selectedType.Id_type && i.Id_category == selectedCategory.Id_category && i.Id_city == selectedCity.Id_city)
                        .Select(i => new EventModel{ Id = i.Id, Description = i.Description, Id_category = i.Id_category, Id_organizer = i.Id_organizer, 
                            Id_type = i.Id_type, Id_venue = i.Id_venue, Name = i.Name, Number_of_seats = i.Number_of_seats, Poster = i.Poster, Time = i.Time })
                        .ToList();

                      Events1 = new List<EventModel> { };
                      Events2 = new List<EventModel> { };

                      int j = 0;
                      while (j < Events.Count)
                      {
                          if (j % 2 == 0)
                              Events1.Add(Events[j]);
                          else
                              Events2.Add(Events[j]);
                          j++;
                      }
                  }));
            }
        }

        private RelayCommand remCommand;
        public RelayCommand RemCommand //
        {
            get
            {
                return remCommand ??
                  (remCommand = new RelayCommand(obj =>
                  {
                      Напоминания r = new Напоминания(user);
                      r.Show();
                  }));
            }
        }

        private RelayCommand infoCommand;
        public RelayCommand InfoCommand
        {
            get
            {
                return infoCommand ??
                  (infoCommand = new RelayCommand(obj =>
                  {
                      //тут открываем окно мероприятия и добавляем туда информацию о выбранном мероприятии
                      Мероприятие ev = new Мероприятие(selectedEvent, user);
                      ev.Show();
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
